using Android.OS;
using Android.Views;
using Android.Support.V4.View;
using Android.Support.Design.Widget;

namespace playground.Droid.UI
{
    public class ProjectsFragment : Android.Support.V4.App.Fragment
    {
        public static ProjectsFragment NewInstance() =>
            new ProjectsFragment { Arguments = new Bundle() };

        public ItemsViewModel ViewModel
        {
            get;
            set;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

		ViewPager pager;
		TabsAdapter tabsAdapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_project, container, false);
			tabsAdapter = new TabsAdapter(Activity, Activity.SupportFragmentManager);
			pager = view.FindViewById<ViewPager>(Resource.Id.project_pager);

			TabLayout tabs = view.FindViewById<TabLayout>(Resource.Id.tabs);
			pager.Adapter = tabsAdapter;
			tabs.SetupWithViewPager(pager);
			pager.OffscreenPageLimit = 3;

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
    }
}
