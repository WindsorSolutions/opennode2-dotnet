#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

namespace Ionic.Utils.Zip
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class ZipContentsDialog : Form
    {
        public ZipContentsDialog()
        {
            InitializeComponent();
        }

        public ZipFile ZipFile
        {
            set
            {
                listView1.Clear();
                listView1.BeginUpdate();

                string[] columnHeaders = new string[] { "name", "lastmod", "original", "ratio", "compressed", "enc?", "CRC" };
                foreach (string label in columnHeaders)
                {
                    SortableColumnHeader ch = new SortableColumnHeader(label);
                    if (label != "name" && label != "lastmod")
                        ch.TextAlign = HorizontalAlignment.Right;
                    listView1.Columns.Add(ch);
                }

                foreach (ZipEntry e in value)
                {
                    ListViewItem item = new ListViewItem(e.FileName);

                    string[] subitems = new string[] { 
                        e.LastModified.ToString("yyyy-MM-dd HH:mm:ss"),
                        e.UncompressedSize.ToString(),
                        String.Format("{0,5:F0}%", e.CompressionRatio),
                        e.CompressedSize.ToString(),
                        (e.UsesEncryption) ? "Y" : "N",
                        String.Format("{0:X8}", e.Crc32)};

                    foreach (String s in subitems)
                    {
                        ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                        subitem.Text = s;
                        item.SubItems.Add(subitem);
                    }

                    this.listView1.Items.Add(item);
                }

                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.listView1.EndUpdate();
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Create an instance of the ColHeader class.
            SortableColumnHeader clickedCol = (SortableColumnHeader)this.listView1.Columns[e.Column];

            // Set the ascending property to sort in the opposite order.
            clickedCol.SortAscending = !clickedCol.SortAscending;

            // Get the number of items in the list.
            int numItems = this.listView1.Items.Count;

            // Turn off display while data is repoplulated.
            this.listView1.BeginUpdate();

            // Populate an ArrayList with a SortWrapper of each list item.
            List<ItemWrapper> list = new List<ItemWrapper>();
            for (int i = 0; i < numItems; i++)
            {
                list.Add(new ItemWrapper(this.listView1.Items[i], e.Column));
            }

            if (e.Column == 2 || e.Column == 4)
                list.Sort(new ItemWrapper.NumericComparer(clickedCol.SortAscending));
            else
                list.Sort(new ItemWrapper.StringComparer(clickedCol.SortAscending));

            // Clear the list, and repopulate with the sorted items.
            this.listView1.Items.Clear();
            for (int i = 0; i < numItems; i++)
                this.listView1.Items.Add(list[i].Item);

            // Turn display back on.
            this.listView1.EndUpdate();
        }

    }



    // The ColHeader class is a ColumnHeader object with an
    // added property for determining an ascending or descending sort.
    // True specifies an ascending order, false specifies a descending order.
    public class SortableColumnHeader : ColumnHeader
    {
        public bool SortAscending;
        public SortableColumnHeader(string text)
        {
            this.Text = text;
            this.SortAscending = true;
        }
    }


    // An instance of the SortWrapper class is created for
    // each item and added to the ArrayList for sorting.
    public class ItemWrapper
    {
        internal ListViewItem Item;
        internal int Column;

        // A SortWrapper requires the item and the index of the clicked column.
        public ItemWrapper(ListViewItem item, int column)
        {
            Item = item;
            Column = column;
        }

        // Text property for getting the text of an item.
        public string Text
        {
            get { return Item.SubItems[Column].Text; }
        }

        // Implementation of the IComparer
        public class StringComparer : IComparer<ItemWrapper>
        {
            bool ascending;

            // Constructor requires the sort order;
            // true if ascending, otherwise descending.
            public StringComparer(bool asc)
            {
                this.ascending = asc;
            }

            // Implemnentation of the IComparer:Compare
            // method for comparing two objects.
            public int Compare(ItemWrapper xItem, ItemWrapper yItem)
            {
                string xText = xItem.Item.SubItems[xItem.Column].Text;
                string yText = yItem.Item.SubItems[yItem.Column].Text;
                return xText.CompareTo(yText) * (this.ascending ? 1 : -1);
            }
        }

        public class NumericComparer : IComparer<ItemWrapper>
        {
            bool ascending;

            // Constructor requires the sort order;
            // true if ascending, otherwise descending.
            public NumericComparer(bool asc)
            {
                this.ascending = asc;
            }

            // Implemnentation of the IComparer:Compare
            // method for comparing two objects.
            public int Compare(ItemWrapper xItem, ItemWrapper yItem)
            {
                int x = 0, y = 0;
                try
                {
                    x = Int32.Parse(xItem.Item.SubItems[xItem.Column].Text);
                    y = Int32.Parse(yItem.Item.SubItems[yItem.Column].Text);
                }
                catch
                {
                }
                return (x - y) * (this.ascending ? 1 : -1);
            }
        }
    }

}
