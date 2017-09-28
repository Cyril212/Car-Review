using System;
using System.Collections.Generic;
using System.Net;
using Android;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using CarReview.Droid;
using Square.Picasso;

namespace CarReview
{
	public class MyListViewAdapter : BaseAdapter<string>
	{
		private IList<string> mItems;
        private IList<string> mUrls;
		private Context mContext;
		public MyListViewAdapter()
		{
			
		}
		public MyListViewAdapter(Context context, IList<string> items,IList<string> urls)
		{
			mItems = items;
			mContext = context;			mUrls = urls;
		}
		public override string this[int position]
		{
			get
			{
				return mItems[position];
			}
		}

		public override int Count
		{
			get
			{
				return mItems.Count;

			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = convertView;
			if (row == null)
				row = LayoutInflater.From(mContext).Inflate(Droid.Resource.Layout.Listview_Row, null, false);

			TextView txtName = row.FindViewById<TextView>(Droid.Resource.Id.txtName);
			ImageView imageView = (ImageView)row.FindViewById(Droid.Resource.Id.ImageL);

			//imageView.SetImageBitmap(mUrls[position]);
			Picasso.With(mContext)
			       .Load(mUrls[position])
                   .Resize(50, 50)
                   .CenterCrop()
                   .Into(imageView);
			txtName.Text = mItems[position];

			return row;
		}
	}
}
