package md5469011e5511c418a66b486739ead845b;


public class MapFragment
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer,
		com.google.android.gms.maps.OnMapReadyCallback,
		com.google.android.gms.maps.GoogleMap.InfoWindowAdapter,
		com.google.android.gms.maps.GoogleMap.OnInfoWindowClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onActivityCreated:(Landroid/os/Bundle;)V:GetOnActivityCreated_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onDestroyView:()V:GetOnDestroyViewHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"n_onRequestPermissionsResult:(I[Ljava/lang/String;[I)V:GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler\n" +
			"n_onMapReady:(Lcom/google/android/gms/maps/GoogleMap;)V:GetOnMapReady_Lcom_google_android_gms_maps_GoogleMap_Handler:Android.Gms.Maps.IOnMapReadyCallbackInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"n_getInfoContents:(Lcom/google/android/gms/maps/model/Marker;)Landroid/view/View;:GetGetInfoContents_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IInfoWindowAdapterInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"n_getInfoWindow:(Lcom/google/android/gms/maps/model/Marker;)Landroid/view/View;:GetGetInfoWindow_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IInfoWindowAdapterInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"n_onInfoWindowClick:(Lcom/google/android/gms/maps/model/Marker;)V:GetOnInfoWindowClick_Lcom_google_android_gms_maps_model_Marker_Handler:Android.Gms.Maps.GoogleMap/IOnInfoWindowClickListenerInvoker, Xamarin.GooglePlayServices.Maps\n" +
			"";
		mono.android.Runtime.register ("LumoTrack.App.Android.Fragments.MapFragment, LumoTrack.App.Android", MapFragment.class, __md_methods);
	}


	public MapFragment ()
	{
		super ();
		if (getClass () == MapFragment.class)
			mono.android.TypeManager.Activate ("LumoTrack.App.Android.Fragments.MapFragment, LumoTrack.App.Android", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onActivityCreated (android.os.Bundle p0)
	{
		n_onActivityCreated (p0);
	}

	private native void n_onActivityCreated (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onDestroyView ()
	{
		n_onDestroyView ();
	}

	private native void n_onDestroyView ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();


	public void onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2)
	{
		n_onRequestPermissionsResult (p0, p1, p2);
	}

	private native void n_onRequestPermissionsResult (int p0, java.lang.String[] p1, int[] p2);


	public void onMapReady (com.google.android.gms.maps.GoogleMap p0)
	{
		n_onMapReady (p0);
	}

	private native void n_onMapReady (com.google.android.gms.maps.GoogleMap p0);


	public android.view.View getInfoContents (com.google.android.gms.maps.model.Marker p0)
	{
		return n_getInfoContents (p0);
	}

	private native android.view.View n_getInfoContents (com.google.android.gms.maps.model.Marker p0);


	public android.view.View getInfoWindow (com.google.android.gms.maps.model.Marker p0)
	{
		return n_getInfoWindow (p0);
	}

	private native android.view.View n_getInfoWindow (com.google.android.gms.maps.model.Marker p0);


	public void onInfoWindowClick (com.google.android.gms.maps.model.Marker p0)
	{
		n_onInfoWindowClick (p0);
	}

	private native void n_onInfoWindowClick (com.google.android.gms.maps.model.Marker p0);

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
