using System;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace playground.Droid
{
    public class MeFragment : Android.Support.V4.App.Fragment
    {
        public static MeFragment NewInstance() =>
            new MeFragment { Arguments = new Bundle() };

        public MeViewModel ViewModel { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        Button learnMoreButton;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.fragment_me, container, false);
            ViewModel = new MeViewModel();
            learnMoreButton = view.FindViewById<Button>(Resource.Id.button_learn_more);
            return view;
        }

        public override void OnStart()
        {
            base.OnStart();
            learnMoreButton.Click += LearnMoreButton_Click;
        }

        private void LearnMoreButton_Click(object sender, System.EventArgs e)
        {
            ViewModel.OpenWebCommand.Execute(null);
        }

        public override void OnStop()
        {
            base.OnStop();
            learnMoreButton.Click -= LearnMoreButton_Click;
        }

        public void BecameVisible()
        {

        }
    }
}
