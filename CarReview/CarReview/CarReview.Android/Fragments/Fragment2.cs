
using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views.Animations;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Square.Picasso;

namespace CarReview.Droid
{
	public class Fragment2 : Android.Support.V4.App.Fragment
	{
		private RecyclerView mRecyclerView;
		private Models currentModel;
		private RecyclerView.LayoutManager mLayoutManager;
		private RecyclerView.Adapter mAdapter;

	
		public String test { get; set; }
		private TextView text;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}


private async Task LoadData()
{
var firebase = new FirebaseClient("https://database-6c8c1.firebaseio.com/");
	var items = await firebase
				.Child(((MainActivity)this.Context).choosenAuto)
		.OnceAsync<Models>();

	foreach (var item in items)
	{

        	((MainActivity)this.Context).info.Add(new Info() { Name = item.Key, Description = item.Object.Description, Url = item.Object.url, FullDescription = item.Object.FullDescription});
			//	acc.models = item.Object.models;
		//mFragment2.test = acc.Name;
		
		

	}
			mAdapter = new RecyclerAdapter(((MainActivity)this.Context).info, mRecyclerView, this.Context);
			mRecyclerView.SetAdapter(mAdapter);

}
public class Models
{
	//public String Name { get; set; }
	public String url { get; set; }
	public String Description { get; set; }
	public String FullDescription { get; set; }
}
		public override  View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			
			View view = inflater.Inflate(Resource.Layout.Fragment2, container, false);
		
			mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);
			((MainActivity)this.Context).info = new List<Info>();
			//info.Add(new Info() { Name = "BMW", Description = "This is German car brand." });
			//info.Add(new Info() { Name = "Mercedes", Description = "This is also German car." });

			mLayoutManager = new LinearLayoutManager(this.Activity);
			mRecyclerView.SetLayoutManager(mLayoutManager);
                LoadData();
			//mRecyclerView.SetAdapter(new RecyclerAdapter(info,mRecyclerView));

			text = view.FindViewById<TextView>(Resource.Id.Id1);
			text.SetText(test, TextView.BufferType.Normal);

		

			return view;
		}

	}

		public class RecyclerAdapter : RecyclerView.Adapter
		{
            private int mCurrentPosition = -1;
		    public bool isNextFragment = false;
		    private List<Info> minfo;
			private RecyclerView mRecyclerView;
		private ImageView imgBrand;
		    private Context mContext;
public int indexPosition;
		public RecyclerAdapter(List<Info> information, RecyclerView recyclerView, Context context)
			{
				minfo = information;
				mRecyclerView = recyclerView;
			    mContext = context;
			}
		 
			public class MyView : RecyclerView.ViewHolder
			{
				public View mMainView { get; set; }
				public TextView mName { get; set; }
				public TextView mDescription { get; set; }
			    
			public MyView(View view) : base(view)
				{
					mMainView = view;
				}
			}
		/*public class MyView2 : RecyclerView.ViewHolder
		{
			public View mMainView { get; set; }

			public MyView2(View view) : base(view)
			{
				mMainView = view;
			}

		}*/
				public override int GetItemViewType(int position)
				{
					/*if ((position % 2) == 0)
					{
						return Resource.Layout.row;
					}
					else
					{*/
						return Resource.Layout.test;
					//}

				}
				public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
				{
					//if (viewType == Resource.Layout.row)
					//{
                        View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.test, parent, false);

			TextView txtBrand = row.FindViewById<TextView>(Resource.Id.title);
			TextView txtDescription = row.FindViewById<TextView>(Resource.Id.description);
			imgBrand = row.FindViewById<ImageView>(Resource.Id.thumbnail);
		
						MyView view = new MyView(row)
						{
							mName = txtBrand,
							mDescription = txtDescription
						};
						return view;
				/*	}
					else
					{
						View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.test, parent, false);
				     MyView2 view = new MyView2(row);
				     return view;
					}*/


				}

		private void SetAnimation(View view)
		{
			Animation anim = AnimationUtils.LoadAnimation(mContext, Resource.Animation.slide_up);
			view.StartAnimation(anim);
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			
				MyView myHolder = holder as MyView;
				// indexPosition = (minfo.Count - 1) - position;
				myHolder.mMainView.Click += mMainView_Click;
				myHolder.mName.Text = minfo[position].Name;
				myHolder.mDescription.Text = minfo[position].Description;

				Picasso.With(mContext)
			           .Load(minfo[position].Url)
                   .Resize(250, 250)
                   .CenterCrop()
                   .Into(imgBrand);

				if (position > mCurrentPosition)
				{
					SetAnimation(myHolder.mMainView);
					mCurrentPosition = position;
				}
			
			/*else
			{

                    MyView2 myHolder = holder as MyView2;  
				    SetAnimation(myHolder.mMainView);
					mCurrentPosition = position;


			}*/
				}

				void mMainView_Click(object sender, EventArgs e)
				{
					int position = mRecyclerView.GetChildPosition((View)sender);
				 indexPosition = (minfo.Count - 1) - position;

			((MainActivity)mContext).indexPosition = indexPosition;
			        
			((MainActivity)mContext).ReplaceFragment(((MainActivity)mContext).mFragment3);
		
			       
				}

				public override int ItemCount
				{
					get
					{
						return minfo.Count;
					}
				}

			}



}
	