using System;
using System.Windows.Forms;
using System.Collections;

namespace Mp3Player.UI
{
	class ListViewWrapper:ListView
	{
		private int _lastColumnIndex;
		private enum Order
		{ 			
			Asc,
			Desc
		}
		private class ListViewItemComparer : IComparer
		{
			private int col;
			public Order order { get; set; }
			public ListViewItemComparer()
			{
				col = 0;
			}
			public ListViewItemComparer(int column)
			{
				col = column;
			}			
			public int Compare(object x, object y)
			{
				int returnVal = -1;
				returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
				((ListViewItem)y).SubItems[col].Text);
				if (order == Order.Desc) return 0 - returnVal;
				return returnVal;
			}
		}
		public ListViewWrapper()
		{
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
		}
		protected override void OnColumnClick(ColumnClickEventArgs e)
		{			
			var comp = new ListViewItemComparer(e.Column);
			if (_lastColumnIndex == e.Column) comp.order = Order.Desc;
			this.ListViewItemSorter = comp;
			
			_lastColumnIndex = e.Column;
			this.Sort();
			base.OnColumnClick(e);
		}
	}
}
