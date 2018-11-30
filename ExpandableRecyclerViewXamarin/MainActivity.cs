using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views;

namespace ExpandableRecyclerViewXamarin
{
	[Activity (Label = "ExpandableRecyclerViewXamarin", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@android:style/Theme.Holo.Light")]
	public class MainActivity : Activity
	{
        public static RecyclerView recyclerView;
		public static RecyclerAdapter recyclerAdapter;
		private List<DataType> listItems;
		private LinearLayoutManager  mLayoutManager;

		private void initWidget()
		{
			recyclerView = FindViewById<RecyclerView> (Resource.Id.recyclerview);
        }

		private void initData()
        {
			this.listItems = new List<DataType> ();

            GroupData g1 = new GroupData (1);
            GroupData2 g111111 = new GroupData2(111111);
            GroupData2 g111222 = new GroupData2(111222);
            EntryData e11 = new EntryData(11, "Apple");
            EntryData e12 = new EntryData(12, "Samsung");
            g111111.items.Add (e11);
            g111222.items.Add(e12);
            g1.items.Add (g111111);
            g1.items.Add(g111222);

            GroupData g2 = new GroupData (2);
            GroupData2 g21212 = new GroupData2(22222);
            EntryData e21 = new EntryData (21,"Sony");
			EntryData e22 = new EntryData (22,"HTC");
            g21212.items.Add(e21);
            g21212.items.Add(e22);
            g2.items.Add (g21212);

            GroupData g3 = new GroupData(3);
            GroupData2 g333333 = new GroupData2(3333);
            EntryData e31 = new EntryData(31, "Panasonic");
            EntryData e32 = new EntryData(32, "Xiaomi");
            g333333.items.Add(e31);
            g333333.items.Add(e32);
            g3.items.Add(g333333);

            GroupData g4 = new GroupData(4);
            GroupData2 g444444 = new GroupData2(4444);
            EntryData e41 = new EntryData(41, "Meizu");
            EntryData e42 = new EntryData(42, "BlackView");
            g444444.items.Add(e41);
            g444444.items.Add(e42);
            g4.items.Add(g444444);

            GroupData g5 = new GroupData(5);
            GroupData2 g555555 = new GroupData2(5555);
            EntryData e51 = new EntryData(41, "Nokia");
            EntryData e52 = new EntryData(42, "Motorola");
            g555555.items.Add(e51);
            g555555.items.Add(e52);
            g5.items.Add(g555555);

            GroupData g6 = new GroupData(6);
            GroupData2 g666666 = new GroupData2(6666);
            EntryData e61 = new EntryData(41, "Sony Ericsson");
            EntryData e62 = new EntryData(42, "Siemens");
            g666666.items.Add(e61);
            g666666.items.Add(e62);
            g6.items.Add(g666666);

            listItems.Add (g1);
			listItems.Add (g2);
			listItems.Add (g3);
            listItems.Add(g4);
            listItems.Add(g5);
            listItems.Add(g6);

            recyclerAdapter = new RecyclerAdapter (this,listItems);
            recyclerAdapter.GroupClick += OnGroupClick;
            recyclerAdapter.GroupClick2 += OnGroupClick2;
            recyclerAdapter.BttGroupClick += OnBttGroupClick;
			recyclerAdapter.BttEntryClick += OnBttEntryClick;
			this.mLayoutManager = new LinearLayoutManager (this);
            recyclerView.SetLayoutManager (mLayoutManager);
			recyclerView.SetAdapter(recyclerAdapter);
        }

		void OnGroupClick (object sender, int pos)
		{
			GroupData groupSelect = (GroupData) listItems [pos];
            #region closing all subitems
            if(groupSelect.items.Count == 0)
            {
                bool is_cur_header_item11111 = true;
                //loop to close EntryData items
                for (int i = pos; i < listItems.Count; i++)
                {
                    try
                    {
                        var current_item = (GroupData)listItems[i];
                        if (!is_cur_header_item11111)
                            break;
                        is_cur_header_item11111 = false;
                    }
                    catch
                    {
                        try
                        {
                            var current_item = (GroupData2)listItems[i];
                        }
                        catch
                        {
                            recyclerView.FindViewHolderForAdapterPosition(i - 1).ItemView.PerformClick();
                            i--;
                        }
                    }
                }

                var indexes_to_remove = new List<int>();
                bool is_cur_header_item = true;
                //loop to close GreoupData2 items
                for (int i = pos; i < listItems.Count; i++)
                {
                    try
                    {
                        var current_item = (GroupData)listItems[i];
                        if (!is_cur_header_item)
                            break;
                        is_cur_header_item = false;
                    }
                    catch
                    {
                        try
                        {
                            var current_item = (GroupData2)listItems[i];
                            groupSelect.items.Add(listItems[pos + 1]);
                            listItems.RemoveAt(pos + 1);
                            recyclerAdapter.NotifyItemRemoved(pos + 1);
                            i--;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            #endregion closing closing all subitems

            #region opening GroupData2 group items (they are subitems to main group (GroupData) items)
            else
            {
				int index = pos + 1;
				foreach (GroupData2 entryNode in groupSelect.items)
                {
					listItems.Insert(index, entryNode);
					recyclerAdapter.NotifyItemInserted(index);
					index++;
				}
				groupSelect.items.Clear();
			}
            #endregion opening GroupData2 group items (they are subitems to main group (GroupData) items)
        }
        void OnGroupClick2(object sender, int pos)
        {
            GroupData2 groupSelect = (GroupData2)listItems[pos];
            #region closing EntryData items 
            if (groupSelect.items.Count == 0)
            {
                int count = 0;
                while (listItems.Count > pos + 1 && listItems[pos + 1].GetItemType() == 1)
                {
                    groupSelect.items.Add(listItems[pos + 1]);
                    listItems.RemoveAt(pos + 1);
                    recyclerAdapter.NotifyItemRemoved(pos + 1);
                    count++;
                }
            }
            #endregion closing EntryData items 

            #region opening EntryData items
            else
            {
                int index = pos + 1;
                foreach (EntryData entryNode in groupSelect.items)
                {
                    listItems.Insert(index, entryNode);
                    recyclerAdapter.NotifyItemInserted(index);
                    index++;
                }
                groupSelect.items.Clear();
            }
            #endregion opening EntryData items
        }
        void OnBttGroupClick (object sender, int pos)
		{
			GroupData groupSelect = (GroupData) listItems [pos];
			Toast.MakeText (this, "button of groupId " + groupSelect.idNo+ " clicked", ToastLength.Short).Show();
		}

		void OnBttEntryClick (object sender, int pos)
		{
			EntryData entrySelect = (EntryData) listItems [pos];
			Toast.MakeText (this, "button of entryName " + entrySelect.entryName+ " clicked", ToastLength.Short).Show();
		}
		protected override void OnCreate (Bundle savedInstanceState)
		{
			Xamarin.Insights.Initialize (XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);

			initWidget ();
			initData ();
		}
	}
}