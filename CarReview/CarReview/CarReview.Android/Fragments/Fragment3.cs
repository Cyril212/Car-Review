
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
using Android.Widget;
using Square.Picasso;

namespace CarReview.Droid
{
public class Fragment3 : Android.Support.V4.App.Fragment
	{
		private TextView textDescription;
		private TextView titleDescription;
		private ImageView image;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			View view = inflater.Inflate(Resource.Layout.AboutCar, container, false);
             textDescription = view.FindViewById<TextView>(Resource.Id.fulldescription);
			 image = view.FindViewById<ImageView>(Resource.Id.thumbnail);
			titleDescription = view.FindViewById<TextView>(Resource.Id.title);

			Picasso.With((MainActivity)Context)
			       .Load(((MainActivity)Context).info[((MainActivity)Context).indexPosition].Url)
                   .Resize(250, 250)
                   .CenterCrop()
			       .Into(image);
			textDescription.Text = ((MainActivity)Context).info[((MainActivity)Context).indexPosition].FullDescription;
			titleDescription.Text = ((MainActivity)Context).info[((MainActivity)Context).indexPosition].Name;
			return view;
		}
	}
}
