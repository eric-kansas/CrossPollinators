using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using System;

namespace playground.Droid.UI
{
	[Activity(Label = "@string/app_name", Icon = "@mipmap/icon",
		LaunchMode = LaunchMode.SingleInstance,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : BaseActivity
	{
		protected override int LayoutResource => Resource.Layout.activity_main;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			Android.Support.V4.App.FragmentTransaction fragmentTx = this.SupportFragmentManager.BeginTransaction();
			ProjectsFragment detailsFrag = new ProjectsFragment();
			fragmentTx.Add(Resource.Id.fragment_container, detailsFrag);
			fragmentTx.Commit();

			Toolbar.MenuItemClick += (sender, e) =>
			{
				var intent = new Intent(this, typeof(AddItemActivity)); ;
				StartActivity(intent);
			};

			SupportActionBar.SetDisplayHomeAsUpEnabled(false);
			SupportActionBar.SetHomeButtonEnabled(false);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.top_menus, menu);
			return base.OnCreateOptionsMenu(menu);
		}
	}

	class TabsAdapter : FragmentStatePagerAdapter
	{
		string[] titles;

		public override int Count => titles.Length;

		public TabsAdapter(Context context, Android.Support.V4.App.FragmentManager fm) : base(fm)
		{
			titles = context.Resources.GetTextArray(Resource.Array.sections);
		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted(int position) =>
							new Java.Lang.String(titles[position]);

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			switch (position)
			{
				case 0: return BrowseFragment.NewInstance();
				case 1: return FollowingFragment.NewInstance();
				case 2: return MyProjectsFragment.NewInstance();
			}
			return null;
		}

		public override int GetItemPosition(Java.Lang.Object frag) => PositionNone;
	}
}


using System;
namespace playground.Droid.Activities
{
    public class CardsActivity : Activity
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        PhotoAlbumAdapter mAdapter;
        PhotoAlbum mPhotoAlbum;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Prepare the data source:
            mPhotoAlbum = new PhotoAlbum();

            // Instantiate the adapter and pass in its data source:
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);

            // Set our view from the "main" layout resource:
            SetContentView(Resource.Layout.Main);

            // Get our RecyclerView layout:
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(mAdapter);
        }
    }
}
