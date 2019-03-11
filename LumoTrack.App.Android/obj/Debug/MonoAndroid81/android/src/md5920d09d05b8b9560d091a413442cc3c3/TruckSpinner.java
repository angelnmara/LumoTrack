package md5920d09d05b8b9560d091a413442cc3c3;


public class TruckSpinner
	extends android.widget.ArrayAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItem:(I)Ljava/lang/Object;:GetGetItem_IHandler\n" +
			"n_getCount:()I:GetGetCountHandler\n" +
			"";
		mono.android.Runtime.register ("LumoTrack.App.Android.Adapters.TruckSpinner, LumoTrack.App.Android", TruckSpinner.class, __md_methods);
	}


	public TruckSpinner (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == TruckSpinner.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Adapters.TruckSpinner, LumoTrack.App.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public TruckSpinner (android.content.Context p0, int p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == TruckSpinner.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Adapters.TruckSpinner, LumoTrack.App.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public TruckSpinner (android.content.Context p0, int p1, int p2, java.util.List p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == TruckSpinner.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Adapters.TruckSpinner, LumoTrack.App.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib:System.Collections.IList, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public TruckSpinner (android.content.Context p0, int p1, int p2, java.lang.Object[] p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == TruckSpinner.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Adapters.TruckSpinner, LumoTrack.App.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib:Java.Lang.Object[], Mono.Android", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public TruckSpinner (android.content.Context p0, int p1, java.util.List p2)
	{
		super (p0, p1, p2);
		if (getClass () == TruckSpinner.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Adapters.TruckSpinner, LumoTrack.App.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:System.Collections.IList, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public TruckSpinner (android.content.Context p0, int p1, java.lang.Object[] p2)
	{
		super (p0, p1, p2);
		if (getClass () == TruckSpinner.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Adapters.TruckSpinner, LumoTrack.App.Android", "Android.Content.Context, Mono.Android:System.Int32, mscorlib:Java.Lang.Object[], Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public java.lang.Object getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native java.lang.Object n_getItem (int p0);


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();

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
