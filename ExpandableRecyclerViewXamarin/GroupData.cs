using System;
using System.Collections.Generic;

namespace ExpandableRecyclerViewXamarin
{
	public class GroupData : DataType
	{
		public int idNo { set; get; }
		public List<DataType> items { set; get; }
        public List<DataType> items_child { set; get; }

        public int GetItemType(){
			return 0;
		}
			
		public GroupData (int idNo)
		{
			this.idNo = idNo;
			this.items = new List<DataType> ();
            this.items_child = new List<DataType>();
        }
	}
    public class GroupData2 : DataType
    {
        public int idNo { set; get; }
        public List<DataType> items { set; get; }
        public List<DataType> items_child { set; get; }

        public int GetItemType()
        {
            return 2;
        }

        public GroupData2(int idNo)
        {
            this.idNo = idNo;
            this.items = new List<DataType>();
            this.items_child = new List<DataType>();
        }
    }
}