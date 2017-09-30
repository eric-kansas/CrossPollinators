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
    public class FollowingFragment : Android.Support.V4.App.Fragment
    {
        public static FollowingFragment NewInstance() =>
            new FollowingFragment { Arguments = new Bundle() };

        FollowingItemsAdapter adapter;
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
            ViewModel = new ItemsViewModel();

            ServiceLocator.Instance.Register<MockDataStore, MockDataStore>();

            View view = inflater.Inflate(Resource.Layout.fragment_list, container, false);
            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            recyclerView.HasFixedSize = true;
            recyclerView.SetAdapter(adapter = new FollowingItemsAdapter(Activity, ViewModel));

            refresher = view.FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);

            refresher.SetColorSchemeColors(Resource.Color.accent);

            progress = view.FindViewById<ProgressBar>(Resource.Id.progressbar_loading);
            progress.Visibility = ViewStates.Gone;

			return view;
        }

        public override void OnStart()
        {
            base.OnStart();

            refresher.Refresh += Refresher_Refresh;
            //ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            adapter.ItemClick += Adapter_ItemClick;

            if (ViewModel.Items.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }

        public override void OnStop()
        {
            base.OnStop();
            refresher.Refresh -= Refresher_Refresh;
            //ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            adapter.ItemClick -= Adapter_ItemClick;
        }

        private void Adapter_ItemClick(object sender, RecyclerClickEventArgs e)
        {
            var item = ViewModel.Items[e.Position];
            var intent = new Intent(Activity, typeof(ProjectDetailActivity));

            intent.PutExtra("data", Newtonsoft.Json.JsonConvert.SerializeObject(item));
            Activity.StartActivity(intent);
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }

        private void Refresher_Refresh(object sender, EventArgs e)
        {
            ViewModel.LoadItemsCommand.Execute(null);
            refresher.Refreshing = false;
        }

        public void BecameVisible()
        {

        }
    }

    class FollowingItemsAdapter : BaseRecycleViewAdapter
    {
        ItemsViewModel viewModel;
        Activity activity;

        public FollowingItemsAdapter(Activity activity, ItemsViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.activity = activity;

            this.viewModel.Items.CollectionChanged += (sender, args) =>
            {
                this.activity.RunOnUiThread(NotifyDataSetChanged);
            };
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Setup your layout here
            View itemView = null;
            var id = Resource.Layout.item_following;
            itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new FollowingItemViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = viewModel.Items[position];

            // Replace the contents of the view with that element
            var itemViewHolder = holder as FollowingItemViewHolder;
            itemViewHolder.HeaderView.Text = item.Name;
            itemViewHolder.SubHeaderView.Text = item.Description;
			itemViewHolder.TextView.Text = item.Author.Username;
			itemViewHolder.DetailTextView.Text = item.Author.Organization;
        }

        public override int ItemCount => viewModel.Items.Count;
    }

    public class FollowingItemViewHolder : RecyclerView.ViewHolder
    {
        public TextView TextView { get; set; }
        public TextView HeaderView { get; set; }
        public TextView SubHeaderView { get; set; }
        public TextView DetailTextView { get; set; }

        public FollowingItemViewHolder(View itemView, Action<RecyclerClickEventArgs> clickListener,
                            Action<RecyclerClickEventArgs> longClickListener) : base(itemView)
        {
            HeaderView = itemView.FindViewById<TextView>(Resource.Id.header1);
            SubHeaderView = itemView.FindViewById<TextView>(Resource.Id.subheader1);
            TextView = itemView.FindViewById<TextView>(Android.Resource.Id.Text1);
            DetailTextView = itemView.FindViewById<TextView>(Android.Resource.Id.Text2);
            itemView.Click += (sender, e) => clickListener(new RecyclerClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new RecyclerClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }
}
