package md53a05107447f03a01fa6514e02eb31e3a;


public class GroupHolder2
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ExpandableRecyclerViewXamarin.GroupHolder2, ExpandableRecyclerViewXamarin", GroupHolder2.class, __md_methods);
	}


	public GroupHolder2 (android.view.View p0)
	{
		super (p0);
		if (getClass () == GroupHolder2.class)
			mono.android.TypeManager.Activate ("ExpandableRecyclerViewXamarin.GroupHolder2, ExpandableRecyclerViewXamarin", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
