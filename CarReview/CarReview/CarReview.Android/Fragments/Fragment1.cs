
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace CarReview.Droid
{
	public class Fragment1 : Android.Support.V4.App.Fragment
	{
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			View view = inflater.Inflate(Resource.Layout.Fragment1, container, false);
WebView localWebView = view.FindViewById<WebView>(Resource.Id.LocalWebView);
localWebView.SetWebViewClient (new WebViewClient());
			localWebView.Settings.JavaScriptEnabled = true;
localWebView.LoadUrl("http://www.carmagazine.co.uk/car-news/");

			return view;
			//return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}
