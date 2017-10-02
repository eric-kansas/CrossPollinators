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
    public class DiscoverFragment : Android.Support.V4.App.Fragment
    {
        public static DiscoverFragment NewInstance() => new DiscoverFragment { Arguments = new Bundle() };

        DiscoverItemsAdapter adapter;
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
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ViewModel = new ItemsViewModel();

            ServiceLocator.Instance.Register<GraphQLClient, GraphQLClient>();

            View view = inflater.Inflate(Resource.Layout.fragment_list, container, false);
            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            recyclerView.HasFixedSize = true;

            // set adapter
            recyclerView.SetAdapter(adapter = new DiscoverItemsAdapter(Activity, ViewModel));

            refresher = view.FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);

            refresher.SetColorSchemeColors(Resource.Color.accent);

            progress = view.FindViewById<ProgressBar>(Resource.Id.progressbar_loading);
            progress.Visibility = ViewStates.Gone;

            return view;
        }

        public override void OnStart()
        {
            base.OnStart();

            // Add event handlers
            refresher.Refresh += Refresher_Refresh;
            adapter.ItemClick += Adapter_ItemClick;

            if (ViewModel.Items.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }

        public override void OnStop()
        {
            base.OnStop();
            refresher.Refresh -= Refresher_Refresh;
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
    }

	class DiscoverItemsAdapter : BaseRecycleViewAdapter
	{
		ItemsViewModel viewModel;
		Activity activity;

		public DiscoverItemsAdapter(Activity activity, ItemsViewModel viewModel)
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
            var id = Resource.Layout.item_discover;
			itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

			var vh = new DiscoverItemViewHolder(itemView, OnClick, OnLongClick);
			return vh;
		}

		// Replace the contents of a view (invoked by the layout manager)
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var item = viewModel.Items[position];

			// Replace the contents of the view with that element
			var itemViewHolder = holder as DiscoverItemViewHolder;
			itemViewHolder.HeaderView.Text = item.Name;
			itemViewHolder.SubHeaderView.Text = item.Description;
            itemViewHolder.DetailTextView.Text = item.Objective;

			itemViewHolder.FullNameTextView.Text = item.Author.Full_Name;
            itemViewHolder.OrganizationTextView.Text = item.Author.Organization;
		}

		public override int ItemCount => viewModel.Items.Count;
	}

	public class DiscoverItemViewHolder : RecyclerView.ViewHolder
	{
		public TextView HeaderView { get; set; }
		public TextView SubHeaderView { get; set; }
		public TextView DetailTextView { get; set; }
		public TextView FullNameTextView { get; set; }
		public TextView OrganizationTextView { get; set; }

		public DiscoverItemViewHolder(View itemView, Action<RecyclerClickEventArgs> clickListener,
							Action<RecyclerClickEventArgs> longClickListener) : base(itemView)
		{
			HeaderView = itemView.FindViewById<TextView>(Resource.Id.header1);
			SubHeaderView = itemView.FindViewById<TextView>(Resource.Id.subheader1);

            DetailTextView = itemView.FindViewById<TextView>(Resource.Id.objective);

            FullNameTextView = itemView.FindViewById<TextView>(Resource.Id.full_name);
            OrganizationTextView = itemView.FindViewById<TextView>(Resource.Id.organization);

            // Add event handlers
			itemView.Click += (sender, e) => clickListener(new RecyclerClickEventArgs { View = itemView, Position = AdapterPosition });
			itemView.LongClick += (sender, e) => longClickListener(new RecyclerClickEventArgs { View = itemView, Position = AdapterPosition });
		}
	}
}
