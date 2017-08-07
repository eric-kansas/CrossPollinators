
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace playground.Droid.UI
{
    [Activity(Label = "ChatActivity")]
    public class ChatActivity : BaseActivity
    {
        protected override int LayoutResource => Resource.Layout.chat;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
    }
}
