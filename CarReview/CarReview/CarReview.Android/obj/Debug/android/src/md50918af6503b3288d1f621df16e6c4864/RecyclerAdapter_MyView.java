package md50918af6503b3288d1f621df16e6c4864;


public class RecyclerAdapter_MyView
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("CarReview.Droid.RecyclerAdapter+MyView, CarReview.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RecyclerAdapter_MyView.class, __md_methods);
	}


	public RecyclerAdapter_MyView (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == RecyclerAdapter_MyView.class)
			mono.android.TypeManager.Activate ("CarReview.Droid.RecyclerAdapter+MyView, CarReview.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
