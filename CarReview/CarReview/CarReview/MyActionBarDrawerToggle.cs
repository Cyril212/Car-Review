using Android.Support.V4.Widget;
using Android.Support.V7.App;
using System;
using System.Collections.Generic;
using System.Text;
using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using Android.Views;

namespace CarReview
{
    class MyActionBarDrawerToggle : SupportActionBarDrawerToggle
    {
        private AppCompatActivity mHostActivity;
        private int mOpendedResource;
        private int mClosedResource;
        public MyActionBarDrawerToggle(AppCompatActivity host, DrawerLayout drawerLayout, int opendedResource, int closedResource) : base(host,drawerLayout,opendedResource,closedResource)
        {
            mHostActivity = host;
            mOpendedResource = opendedResource;
            mClosedResource = closedResource;
        }

        public override void OnDrawerOpened(Android.Views.View drawerView)
        {
            base.OnDrawerOpened(drawerView);
            mHostActivity.SupportActionBar.SetTitle(mOpendedResource);
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
            mHostActivity.SupportActionBar.SetTitle(mClosedResource);
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }
    }
}
