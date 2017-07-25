using System;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Widget;
using Android.App;
using Android.Content;

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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Console.WriteLine("here in OnCreateView");

            View view = inflater.Inflate(Resource.Layout.fragment_projects, container, false);
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
