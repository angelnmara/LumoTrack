package md544eaa15befaf60b487f75557ac7b29b7;


public class AlertDialogHelper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.content.DialogInterface.OnDismissListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onDismiss:(Landroid/content/DialogInterface;)V:GetOnDismiss_Landroid_content_DialogInterface_Handler:Android.Content.IDialogInterfaceOnDismissListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("LumoTrack.App.Android.Helpers.AlertDialogHelper, LumoTrack.App.Android", AlertDialogHelper.class, __md_methods);
	}


	public AlertDialogHelper ()
	{
		super ();
		if (getClass () == AlertDialogHelper.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Helpers.AlertDialogHelper, LumoTrack.App.Android", "", this, new java.lang.Object[] {  });
	}

	public AlertDialogHelper (android.content.Context p0, java.lang.String p1, java.lang.String p2, java.lang.String p3, java.lang.String p4)
	{
		super ();
		if (getClass () == AlertDialogHelper.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Helpers.AlertDialogHelper, LumoTrack.App.Android", "Android.Content.Context, Mono.Android:System.String, mscorlib:System.String, mscorlib:System.String, mscorlib:System.String, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
	}


	public void onDismiss (android.content.DialogInterface p0)
	{
		n_onDismiss (p0);
	}

	private native void n_onDismiss (android.content.DialogInterface p0);

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
