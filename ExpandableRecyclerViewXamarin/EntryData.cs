using System;

namespace ExpandableRecyclerViewXamarin
{
	public class EntryData : DataType
	{
		public int entryId { set; get; }
		public string entryName { set; get; }

		public int GetItemType(){
			return 1;
		}

		public EntryData (int entryId, string entryName)
		{
			this.entryId = entryId;
			this.entryName = entryName;
		}
	}
}