package md520cac9f868d189aa78aa132a8655ab1c;


public class NetworkChangeReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("Xamarin.InsightsCore.NetworkChangeReceiver, Xamarin.Insights", NetworkChangeReceiver.class, __md_methods);
	}


	public NetworkChangeReceiver ()
	{
		super ();
		if (getClass () == NetworkChangeReceiver.class)
			mono.android.TypeManager.Activate ("Xamarin.InsightsCore.NetworkChangeReceiver, Xamarin.Insights", "", this, new java.lang.Object[] {  });
	}

	public NetworkChangeReceiver (android.content.Context p0)
	{
		super ();
		if (getClass () == NetworkChangeReceiver.class)
			mono.android.TypeManager.Activate ("Xamarin.InsightsCore.NetworkChangeReceiver, Xamarin.Insights", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
