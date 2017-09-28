
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Firebase.Xamarin.Database;

namespace CarReview.Droid
{
[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true)]
public class SplashActivity : AppCompatActivity
{
private String FirebaseURL = "https://database-6c8c1.firebaseio.com/";		
private IList<string> DataSet;
private IList<string> DataSetImages;
	static readonly string TAG = "X:" + typeof(SplashActivity).Name;

	public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
	{
		base.OnCreate(savedInstanceState, persistentState);
		Log.Debug(TAG, "SplashActivity.OnCreate");



	}

	// Launches the startup task
		protected async override void OnResume()
	{
		base.OnResume();
			DataSet = new List<string>();
			DataSetImages = new List<string>();
            await  LoadData();
		//Task startupWork = new Task(() => { SimulateStartup(); });
		
	}
public class Cars
{
	public String Name { get; set; }
	public String url { get; set; }
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

		DataSet.Add(acc.Name);
		DataSetImages.Add(acc.url);

	}
	//			mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
	//mLeftDrawer.Adapter = mLeftAdapter;
            SimulateStartup();
}
	// Simulates background work that happens behind the splash screen
	 void SimulateStartup()
		{
			Log.Debug(TAG, "Performing some startup work that takes a bit of time.");


			//await Task.Delay(16000); // Simulate a bit of startup work.
			//Log.Debug(TAG, "Startup work is finished - starting MainActivity.");
			var intent = new Intent(Application.Context, typeof(MainActivity));

			intent.PutStringArrayListExtra("DataSet", DataSet);
			intent.PutStringArrayListExtra("DataSetImages", DataSetImages);

	        StartActivity(intent);
		}


}
}
