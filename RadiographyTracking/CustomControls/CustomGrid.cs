﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.ServiceModel.DomainServices.Client;
using System.Linq;

namespace Vagsons.Controls
{
    public class CustomGrid : DataGrid
    {
        bool mouseDown = false;
        Dictionary<DataGridCell, Brush> selectedCells = new Dictionary<DataGridCell, Brush>();
        String copiedText = String.Empty;

        static bool isEditAllowed = true;
        static bool isDeleteAllowed = true;
        private bool setVisiblity = false;

        public static bool IsEditAllowed
        {
            get
            {
                return isEditAllowed;
            }
            set
            {
                isEditAllowed = value;
                isDeleteAllowed = value;
            }
        }

        public static bool IsDeleteAllowed
        {
            get { return isDeleteAllowed; }
            set
            {
                isDeleteAllowed = value;
            }
        }

        /// <summary>
        /// Properties included here will be excluded from change tracking. This is exceptionally needed for parent-child
        /// relations where the parent cannot be set for the child-clone (otherwise it tries to attach the child to the 
        /// parent again and throws errors)
        /// </summary>
        public static List<String> ExcludePropertiesFromTracking = new List<String>();


        private Dictionary<int, Object> _originalEntities;

        /// <summary>
        /// tracks the changed entities in the item source for this grid along with their ids
        /// </summary>
        public Dictionary<int, Object> OriginalEntities
        {
            get
            {
                if (_originalEntities == null)
                    _originalEntities = new Dictionary<int, object>();

                return _originalEntities;
            }
        }

        /// <summary>
        /// Clears all the changes, use when you cancel changes, otherwise changes will remain in the table
        /// </summary>
        public void ClearOriginalEntities()
        {
            this.OriginalEntities.Clear();
        }
        

        public CustomGrid()
            : base()
        {
            //no point in adding these event handlers if the grid is readonly
            if (!this.IsReadOnly)
            {
                this.RowEditEnded += new EventHandler<DataGridRowEditEndedEventArgs>(CustomGrid_RowEditEnded);
                this.BeginningEdit += new EventHandler<DataGridBeginningEditEventArgs>(CustomGrid_BeginningEdit);
                this.MouseLeave += new MouseEventHandler(CustomGrid_MouseLeave);
                this.MouseEnter += new MouseEventHandler(CustomGrid_MouseEnter);
                this.MouseLeftButtonUp += new MouseButtonEventHandler(CustomGrid_MouseLeftButtonUp);
                this.LoadingRow += new EventHandler<DataGridRowEventArgs>(CustomGrid_LoadingRow);
                this.GotFocus += new RoutedEventHandler(CustomGrid_GotFocus);
            }
            this.AutoGenerateColumns = false;
        }


        private void setEditDeleteVisibility()
        {
            //if edit is not allowed, first make edit and delete columns disappear
            if (!isEditAllowed)
            {
                foreach (var column in this.Columns)
                {
                    if (column.Header.ToString().ToLower() == "edit" || column.Header.ToString().ToLower() == "delete")
                    {
                        column.Visibility = System.Windows.Visibility.Collapsed;                        
                    }
                    setVisiblity = true;                    
                }
            }
        }

        void CustomGrid_RowEditEnded(object sender, DataGridRowEditEndedEventArgs e)
        {
            CustomGrid_LoadingRow(sender, new DataGridRowEventArgs(e.Row));
        }


        void CustomGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //done here since when row enters edit mode, the textblock cannot capture the mouseup event
            mouseDown = false;
            clearAllSelection();
            //track the original value of this item before it is edited
            TrackItem(this.SelectedItem);
        }

        void TrackItem(object item)
        {
            var original = item.Clone(CustomGrid.ExcludePropertiesFromTracking);          
            var originalID = getID(original);
            var obj = new Object();

            //add only if not exists already, no point adding the same entity again and again
            if (!OriginalEntities.TryGetValue(originalID, out obj))
                OriginalEntities.Add(originalID, original);
        }

        private int getID(object item)
        {
            int itemID = 0;
            Type t = item.GetType();
            var property = t.GetProperty("ID");
            if (property != null)
            {
                Int32.TryParse(property.GetValue(item, null).ToString(), out itemID);
            }
            return itemID;
        }

        void CustomGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //do this if not already done
            if(!setVisiblity) setEditDeleteVisibility();

            int itemID = getID(e.Row.DataContext);
            
            foreach (var column in this.Columns)
            {
                FrameworkElement cellContent = column.GetCellContent(e.Row);
                addCellEventHandlers(cellContent);
                
                //only for combobox or textblocks disable
                if (!CustomGrid.isEditAllowed && itemID != 0 
                    && (cellContent.GetType() == typeof(TextBlock) || cellContent.GetType() == typeof(ComboBox))) // Only for new items with id zero, allow editing if editing is disallowed
                {
                    if (this.Name == "filmTransactionsDataGrid")
                    {
                        //for others this behavior is not needed
                        e.Row.IsEnabled = false;
                    }
                    (cellContent.Parent as DataGridCell).IsEnabled = false;
                }

                //set a tag in the cell to make it readonly if column is readonly.
                //this will be used to allow copying to this cell 
                (cellContent.Parent as DataGridCell).Tag = column.IsReadOnly ? "1" : "0";
            }            
        }

        void addCellEventHandlers(FrameworkElement cellContent)
        {
            cellContent.MouseEnter += new MouseEventHandler(cellContent_MouseEnter);
            cellContent.MouseLeftButtonDown += new MouseButtonEventHandler(cellContent_MouseLeftButtonDown);
            cellContent.MouseLeftButtonUp += new MouseButtonEventHandler(cellContent_MouseLeftButtonUp);
        }

        void CustomGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
            ReleaseMouseCapture();
        }

        void CustomGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            ReleaseMouseCapture();
        }

        /// <summary>
        /// Capture the mouse if it is leaving when down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CustomGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mouseDown)
                CaptureMouse();
        }

        void cellContent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
        }


        void cellContent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if ctrl button is not held down, clear all selection
            if ((Keyboard.Modifiers & ModifierKeys.Control) == 0)
                clearAllSelection();

            //if this is not textblock, it means it is in edit mode, so do not proceed further
            if (e.OriginalSource.GetType() != typeof(TextBlock))
                return;

            mouseDown = true;
            selectCell(e.OriginalSource);
        }

        /// <summary>
        /// Clears all the selected cells and reverts them back to their original state
        /// </summary>
        void clearAllSelection()
        {
            //clear all the selected cells
            foreach (var item in selectedCells)
            {
                //make the background its original value
                item.Key.Background = item.Value;
            }

            selectedCells.Clear();
        }

        void cellContent_MouseEnter(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                selectCell(e.OriginalSource);
            }
        }

        void selectCell(Object c)
        {
            if (c.GetType() != typeof(TextBlock))
                return;

            TextBlock tblock = (TextBlock)c;

            if (tblock.Parent.GetType() != typeof(DataGridCell))
                return;

            DataGridCell cell = (DataGridCell)tblock.Parent;

            //if already added, return
            if (selectedCells.ContainsKey(cell)) return;

            //if the selected cell is of a column is bound in mode oneway, return without adding cell.
            if (cell.Tag.ToString() == "1") return;

            selectedCells.Add(cell, cell.Background);
            cell.Background = new SolidColorBrush(Colors.Purple);

            //since there is a good change this item will change, track the old value
            TrackItem(cell.DataContext);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (this.IsReadOnly)
            {
                base.OnKeyDown(e);
            }
            else if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                string text = copiedText;

                //cleanup the escape characters
                text = text.Replace("\t", "").Replace("\r", "").Replace("\n", "");
                foreach (var item in selectedCells)
                {
                    //this applies to only textblocks within cells
                    if (item.Key.Content.GetType() != typeof(TextBlock))
                        continue;

                    TextBlock txt = (TextBlock)item.Key.Content;
                    string originalText = txt.Text;
                    //if there is any exception, only for that cell revert to old value
                    try
                    {
                        txt.Text = text;
                        txt.GetBindingExpression(TextBlock.TextProperty).UpdateSource();
                    }
                    catch
                    {
                        txt.Text = originalText;
                    }
                }
                e.Handled = true;
            }
            // handle copying so that entire row does not get copied even if a row is selected
            else if (e.Key == Key.C && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                if (this.CurrentColumn.GetCellContent(this.CurrentItem).GetType() == typeof(TextBlock))
                    copiedText = ((TextBlock)this.CurrentColumn.GetCellContent(this.CurrentItem)).Text;
                else
                    base.OnKeyDown(e);
            }
            else if (!(new List<Key>(){Key.Enter, Key.Escape, Key.F2, Key.Escape, Key.Right, Key.Left, Key.Up, 
                                       Key.Down, Key.Ctrl, Key.Shift, Key.Alt, Key.Unknown, Key.Tab,
                                        Key.Back, Key.Insert, Key.Home, Key.End, Key.PageDown, Key.PageUp,
                                        Key.Delete, Key.CapsLock}).Contains(e.Key) && e.OriginalSource.GetType() != typeof(TextBox))
            {
                //any other key, start editing
                bool isShifty = ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift);
                string letter = e.Key.ToString();
                letter = letter.Replace("numpad", "").Replace("NUMPAD", "") ; //remove 'numpad' if it appears
                letter = letter.Replace("space", " ").Replace("SPACE", " ");
                //if D+ number (d9 for eg) appears, replace it
                if (letter.Length > 1) letter = letter.Replace("d", "").Replace("D", "");

                letter = (isShifty ? letter.ToUpper() : letter);
                this.Tag = letter;

                //beginedit will fire the focus event
                //if we try to access the textbox here its text will not be set
                this.BeginEdit();
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        /// <summary>
        /// handle cell begin editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CustomGrid_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.Tag != null)
            {
                var box = this.CurrentColumn.GetCellContent(CurrentItem);
                if (box.GetType() == typeof(TextBox))
                {
                    ((TextBox)box).Text = this.Tag.ToString();
                    ((TextBox)box).SelectionStart = 1; //move editing cursor to end of text
                }
                this.Tag = null;
            }
        }
    }
}
