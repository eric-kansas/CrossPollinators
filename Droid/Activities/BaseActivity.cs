using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using System;
using Android.Support.Design.Widget;

namespace playground.Droid
{
    public class BaseActivity : AppCompatActivity
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
            }
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
