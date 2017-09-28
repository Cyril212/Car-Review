using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;
using SupportFragment = Android.Support.V4.App.Fragment;
using com.refractored;
using Android.Support.V4.View;
using Android.Util;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using Firebase.Xamarin.Auth;
using Android.Support.V7.View;
using Android.Views;
using Android.Graphics;
using System.Net;
using Square.Picasso;
using Android.Support.Design.Widget;
using Android.Views.Animations;
using Android.Webkit;

namespace CarReview.Droid
{

	[Activity (Label = "Car Review",  Icon = "@drawable/icon",  Theme ="@style/MyTheme")]

	public class MainActivity : Android.Support.V7.App.AppCompatActivity
	  {
        private SupportToolbar mToolbar;
        private MyActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
		private ArrayAdapter mLeftAdapter;
		private IList<string> mLeftDataSet;
		private IList<string> mLeftDataSetImages;
		private MyListViewAdapter adapter;
		private SupportFragment mCurrentFragment;
		private Fragment1 mFragment1;
        private Fragment2 mFragment2;
		public  Fragment3 mFragment3;
		private Stack<SupportFragment> mStackFragment;
        private int count = 1;
        private String FirebaseURL = "https://database-6c8c1.firebaseio.com/";
		public String choosenAuto = "";
        private TabLayout tabLayout;
        public List<Info> info;
        public int indexPosition;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			//	tabLayout=FindViewById<TabLayout>(Resource.Id.sliding_tabs); 

			info = new List<Info>();
        var Tabtitles = CharSequence.ArrayFromStringArray(new[] {
	    "Economy car",
	    "Family car",
	    "Saloons / sedans", 
		"Luxury vehicle",
		"Sprots cars",
		"Off-roaders",
		"Commercial vehicle"
   	   	});	
			var fragments = new Android.Support.V4.App.Fragment[]{
		    new Fragment1(),
		    new Fragment2()
			};

			mFragment1 = new Fragment1();
mFragment2 = new Fragment2();
mFragment3 = new Fragment3();
//var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
//viewpager holding fragment array and tab title text
//viewPager.Adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, Tabtitles);
// Give the TabLayout the ViewPager 
//tabLayout.SetupWithViewPager(viewPager);


			mLeftDataSet = new List<string>();
			mLeftDataSetImages = new List<string>();

            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
		
		            string[] titles = new string[]
				{
					"Fragment1",
					"Fragment2"
                };



			mStackFragment = new Stack<SupportFragment>();
           
			var trans = SupportFragmentManager.BeginTransaction();
			//trans.Add(Resource.Id.fragmentContainer, mFragment3, "Fragment3");
			//trans.Hide(mFragment3);
			//trans.Add(Resource.Id.fragmentContainer, mFragment2, "Fragment2");
			//trans.Hide(mFragment2);
			trans.Add(Resource.Id.fragmentContainer, mFragment1, "Fragment1");
	
			trans.Commit();




			mCurrentFragment = mFragment1;

             SetSupportActionBar(mToolbar);
			//LoadData();
			mLeftDataSet = Intent.GetStringArrayListExtra("DataSet");
			mLeftDataSetImages = Intent.GetStringArrayListExtra("DataSetImages");

			adapter = new MyListViewAdapter(this, mLeftDataSet, mLeftDataSetImages);

            mLeftDrawer.Adapter = adapter;
			//mLeftDataSet = new List<string>();
			//mLeftDataSet.Add("Left Item 1");
			//mLeftDataSet.Add("Left Item 2");
			//adapter = new MyListViewAdapter(this, mLeftDataSet);


			//mLeftDrawer.Adapter = adapter;
            mDrawerToggle = new MyActionBarDrawerToggle(
                this, //Host Activity
                mDrawerLayout, //Drawer Layout
                Resource.String.openDrawer, //Opened Message
                Resource.String.closeDrawer //Closed Message
                );

            mDrawerLayout.AddDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToggle.SyncState();

			mLeftDrawer.ItemClick +=  (object sender, AdapterView.ItemClickEventArgs e) =>
			{

				for (int i = 0; i < mLeftDataSet.Count; i++)
				{
					if (mLeftDataSet[e.Position].Equals(mLeftDataSet[i]))
					{
						mFragment2 = new Fragment2();
						choosenAuto = mLeftDataSet[i];
						// await LoadData();

						//mFragment2.test = "GS";
						ReplaceFragment(mFragment2);
					}
				}

				mDrawerLayout.CloseDrawer(mLeftDrawer);
			};
            if(bundle != null)
            {
                if(bundle.GetString("DrawerState") == "Opened")
                {
                    SupportActionBar.SetTitle(Resource.String.openDrawer);
                }
                else
                {
                    SupportActionBar.SetTitle(Resource.String.closeDrawer);
                }
            }
            else
            {
                SupportActionBar.SetTitle(Resource.String.closeDrawer);
            }

			//tabLayout.Animate().ScaleY(0).SetInterpolator(new AccelerateInterpolator()).Start();
		}

        
public void OnClick(IDialogInterface dialog, int which)
{
	dialog.Dismiss();
}
 
private async Task LoadData()
{
	int i = 0;
	var firebase = new FirebaseClient(FirebaseURL);
	var items = await firebase
				.Child("cars")
		.OnceAsync<Cars>();

	foreach (var item in items)
	{
		Cars acc = new Cars();

				acc.Name = item.Object.Name;
				acc.url = item.Object.url;

		        mLeftDataSet.Add(acc.Name);
				mLeftDataSetImages.Add(acc.url);
			
	}
//			mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
//mLeftDrawer.Adapter = mLeftAdapter;
			adapter = new MyListViewAdapter(this, mLeftDataSet, mLeftDataSetImages);

mLeftDrawer.Adapter = adapter;

}

public class Cars
{
	public String Name { get; set; }
	public String url { get; set; }
}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
           switch (item.ItemId)
			{

			case Android.Resource.Id.Home:
				//The hamburger icon was clicked which means the drawer toggle will handle the event
				//all we need to do is ensure the right drawer is closed so the don't overlap
  
				mDrawerToggle.OnOptionsItemSelected(item);
				return true;
					/*
			case Resource.Id.action_help:
				if (mDrawerLayout.IsDrawerOpen(mRightDrawer))
				{
					//Right Drawer is already open, close it
					mDrawerLayout.CloseDrawer(mRightDrawer);
				}

				else
				{
					//Right Drawer is closed, open it and just in case close left drawer
					mDrawerLayout.OpenDrawer (mRightDrawer);
					mDrawerLayout.CloseDrawer (mLeftDrawer);
				}

				return true;

			case Resource.Id.action_fragment1:				
				ShowFragment(mFragment1);
				return true;

			case Resource.Id.action_fragment2:
				ShowFragment(mFragment2);
				return true;

			case Resource.Id.action_fragment3:
				ShowFragment(mFragment3);
				return true;
					*/
			default:
				return base.OnOptionsItemSelected (item);
			}
		}
		public override bool OnCreateOptionsMenu(IMenu menu)
		 {
			MenuInflater.Inflate(Resource.Menu.action_menu,menu);
		   return base.OnCreateOptionsMenu(menu);
	   }

		public void ReplaceFragment(SupportFragment fragment)
		{
			if (fragment.IsVisible)
				return;

			var trans = SupportFragmentManager.BeginTransaction();
			trans.Replace(Resource.Id.fragmentContainer, fragment);
			trans.AddToBackStack(null);
			trans.Commit();

			mCurrentFragment = fragment;

		}
	
		private void ShowFragment(SupportFragment fragment)
		{
			if (fragment.IsVisible){
				return;
			}
			var trans = SupportFragmentManager.BeginTransaction();

			trans.SetCustomAnimations(Resource.Animation.slide_in, Resource.Animation.slide_out,Resource.Animation.slide_in, Resource.Animation.slide_out);
			trans.Hide(mCurrentFragment);
			trans.Show(fragment);
			trans.AddToBackStack(null);
			mStackFragment.Push(mCurrentFragment);
			trans.Commit();

			mCurrentFragment = fragment;
		}
		public override void OnBackPressed()
		{
			/*
			if (SupportFragmentManager.BackStackEntryCount > 0)
			{
				SupportFragmentManager.PopBackStack();
				mCurrentFragment = mStackFragment.Pop();
			}
			else
			{
				base.OnBackPressed();
			}
			*/
			base.OnBackPressed();
		}
        protected override void OnSaveInstanceState(Bundle outState)
        {
			if (mDrawerLayout.IsDrawerOpen((int)GravityFlags.Left))
				{
					outState.PutString("DrawerState", "Opened");
				}
				else
				{
					outState.PutString("DrawerState", "Closed");
				}
		 
            base.OnSaveInstanceState(outState);
					
        }

		protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);

            mDrawerToggle.SyncState();
        }
    }
}


