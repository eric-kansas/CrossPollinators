using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System;
using Android.Support.Design.Widget;
using static Android.Support.Design.Widget.TabLayout;
using Android.Content;

namespace playground.Droid.UI
{
    public class BaseActivity : Android.Support.V7.App.AppCompatActivity, IOnTabSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(LayoutResource);
            Toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            if (Toolbar != null)
            {
                SetSupportActionBar(Toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                SupportActionBar.SetHomeButtonEnabled(false);
            }

            TabLayout toolbarBottom = FindViewById<TabLayout>(Resource.Id.tabs2);

            if (toolbarBottom != null)
            {
                toolbarBottom.AddTab(toolbarBottom.NewTab().SetText("Projects").SetIcon(Resource.Drawable.flower));
                toolbarBottom.AddTab(toolbarBottom.NewTab().SetText("Chat"));
                toolbarBottom.AddTab(toolbarBottom.NewTab().SetText("Me"));
                toolbarBottom.AddOnTabSelectedListener(this);
            }
        }

        public void OnTabReselected(Tab tab)
        {
            Console.WriteLine("tab reselected: " + tab.Text);
        }

        public void OnTabSelected(Tab tab)
        {
            Console.WriteLine("tab selected: " + tab.Text);

			Android.Support.V4.App.FragmentTransaction fragmentTx = this.SupportFragmentManager.BeginTransaction();

			
            switch (tab.Text) {
                case "Projects":
                    ProjectsFragment projectsFrag = new ProjectsFragment();
					fragmentTx.Replace(Resource.Id.fragment_container, projectsFrag);
					fragmentTx.Commit();
                    break;
				case "Chat":
                    AboutFragment chatFrag = new AboutFragment();
					fragmentTx.Replace(Resource.Id.fragment_container, chatFrag);
					fragmentTx.Commit();
					break;
				case "Me":
					MeFragment meFrag = new MeFragment();
					fragmentTx.Replace(Resource.Id.fragment_container, meFrag);
					fragmentTx.Commit();
					break;
            }
        }

        public void OnTabUnselected(Tab tab)
        {
            Console.WriteLine("tab unselected: " + tab.Text);
        }

        public Toolbar Toolbar
        {
            get;
            set;
        }

        protected virtual int LayoutResource
        {
            get;
        }

        protected int ActionBarIcon
        {
            set { Toolbar?.SetNavigationIcon(value); }
        }
    }
}
