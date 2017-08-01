using System;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.App;
using Android.Content;
using Android.Support.V4.View;
using Android.Support.Design.Widget;

namespace playground.Droid.UI
{
    public class ProjectsFragment : Android.Support.V4.App.Fragment, IFragmentVisible
    {
        public static ProjectsFragment NewInstance() =>
            new ProjectsFragment { Arguments = new Bundle() };

        BrowseItemsAdapter adapter;
        SwipeRefreshLayout refresher;

        ProgressBar progress;
        public ItemsViewModel ViewModel
        {
            get;
            set;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
		ViewPager pager;
		TabsAdapter tabsAdapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Console.WriteLine("here in OnCreateView");

            View view = inflater.Inflate(Resource.Layout.fragment_project, container, false);
			tabsAdapter = new TabsAdapter(Activity, Activity.SupportFragmentManager);
			pager = view.FindViewById<ViewPager>(Resource.Id.project_pager);

			TabLayout tabs = view.FindViewById<TabLayout>(Resource.Id.tabs);
			pager.Adapter = tabsAdapter;
			tabs.SetupWithViewPager(pager);
			pager.OffscreenPageLimit = 3;

			pager.PageSelected += (sender, args) =>
			{
				var fragment = tabsAdapter.InstantiateItem(pager, args.Position) as IFragmentVisible;

				fragment?.BecameVisible();
			};
			return view;
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public override void OnStop()
        {
            base.OnStop();
        }

        public void BecameVisible()
        {

        }
    }
}
