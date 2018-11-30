using System;
using Android.Content;
using System.Collections.Generic;
using Android.Views;
using Android.Support.V7.Widget;
using Android.Widget;

namespace ExpandableRecyclerViewXamarin
{
	public class RecyclerAdapter : RecyclerView.Adapter
	{
		public const string TAG = "InvoiceItemAdapterPS";
		private List<DataType> listItems;
		private Context context;
		private LayoutInflater inflater;
		public event EventHandler<int> GroupClick;
        public event EventHandler<int> GroupClick2;
        public event EventHandler<int> BttGroupClick;
		public event EventHandler<int> BttEntryClick;
        RecyclerView.LayoutManager layoutManager;
        public static EntryHolder holderEntry;

        public RecyclerAdapter (Context context, List<DataType> listItems)
		{
			this.context = context;
			this.listItems = listItems;
			this.inflater = (LayoutInflater)context.GetSystemService (Context.LayoutInflaterService);
		}

		void GroupOnClick (int position)
		{
			if (GroupClick != null)
				GroupClick (this, position);
		}

        void GroupOnClick2(int position)
        {
            if (GroupClick2 != null)
                GroupClick2(this, position);
        }

        void BttGroupOnClick (int position)
		{
			if (BttGroupClick != null)
				BttGroupClick (this, position);
		}

		void BttEntryOnClick (int position)
		{
			if (BttEntryClick != null)
				BttEntryClick (this, position);
		}

		public override int ItemCount {
			get {
				return listItems.Count;
			}
		}

		public override int GetItemViewType (int position)
		{
			return listItems[position].GetItemType();
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			DataType itemNode = listItems [position];

			if (itemNode.GetItemType () == 0)
            {
				GroupData group = itemNode as GroupData;
				GroupHolder groupHolder = holder as GroupHolder;

				groupHolder.txtIdNo.Text = group.idNo + "";
			}
            else if (itemNode.GetItemType () == 1)
            {
				EntryData entry = itemNode as EntryData;
                holderEntry = holder as EntryHolder;

				holderEntry.txtEntryId.Text = entry.entryId + "";
				holderEntry.txtEntryName.Text = entry.entryName;


                layoutManager = new LinearLayoutManager(context, LinearLayoutManager.Vertical, false);
            }
            else if(itemNode.GetItemType() == 2)
            {
                GroupData2 group = itemNode as GroupData2;
                GroupHolder2 groupHolder = holder as GroupHolder2;

                groupHolder.txtIdNo.Text = group.idNo + "";

                layoutManager = new LinearLayoutManager(context, LinearLayoutManager.Vertical, false);
            }
        }

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			if (viewType == 0)
            {
				View entryView = inflater.Inflate (Resource.Layout.recycler_group, parent, false);
				return new GroupHolder (entryView, GroupOnClick, BttGroupOnClick);
			}
            else if (viewType == 1)
            {
                View sectionView = inflater.Inflate (Resource.Layout.recycler_entry, parent, false);
                return new EntryHolder (sectionView, BttEntryOnClick);
			}
            else if (viewType == 2)
            {
                View entryView = inflater.Inflate(Resource.Layout.recycler_group, parent, false);
                return new GroupHolder2(entryView, GroupOnClick2, BttGroupOnClick);
            }
            else
            {
				return null;
			}
		}
	}

	public class GroupHolder : RecyclerView.ViewHolder 
	{
		public TextView txtIdNo { set; get;}
		public Button bttGroup { set; get; }


        public GroupHolder(View view, Action<int> groupClickListener, Action<int> bttClickListener) : base(view)
		{
			this.txtIdNo = (TextView)view.FindViewById (Resource.Id.group_txtId);
			this.bttGroup = (Button)view.FindViewById (Resource.Id.group_bttClick);
			view.Click += (sender, e) => groupClickListener (base.AdapterPosition);
			bttGroup.Click += (sender, e) =>  bttClickListener(base.AdapterPosition);
		}
	}

    public class GroupHolder2 : RecyclerView.ViewHolder
    {
        public TextView txtIdNo { set; get; }
        public Button bttGroup { set; get; }


        public GroupHolder2(View view, Action<int> groupClickListener2, Action<int> bttClickListener) : base(view)
        {
            this.txtIdNo = (TextView)view.FindViewById(Resource.Id.group_txtId);
            this.bttGroup = (Button)view.FindViewById(Resource.Id.group_bttClick);
            view.Click += (sender, e) => groupClickListener2(base.AdapterPosition);
            //bttGroup.Click += (sender, e) => bttClickListener(base.AdapterPosition);
        }
    }

    public class EntryHolder : RecyclerView.ViewHolder
	{
		public TextView txtEntryId { set; get; }
		public TextView txtEntryName { set; get; }
		public Button bttEntry { set; get; }
        public RecyclerView recyclerviewEntry;

        public EntryHolder(View view, Action<int> bttEntryClickListener) : base(view)
		{
			this.txtEntryId = (TextView)view.FindViewById (Resource.Id.entry_txtId);
			this.txtEntryName = (TextView)view.FindViewById (Resource.Id.entry_txtName);
			this.bttEntry = (Button)view.FindViewById (Resource.Id.entry_bttClick);
            bttEntry.Click += (sender, e) =>  bttEntryClickListener(base.AdapterPosition);
		}
	}
}