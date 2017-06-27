using System;
using System.Threading.Tasks;

using UIKit;

namespace playground.iOS
{
    public partial class ItemNewViewController : UIViewController
    {
        public Item Item { get; set; }
        public ItemsViewModel viewModel { get; set; }
        public BaseViewModel baseModel { get; set; }

        public ItemNewViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            btnSaveItem.TouchUpInside += (sender, e) =>
            {
                var _item = new Item();
                _item.Text = txtTitle.Text;
                _item.Description = txtDesc.Text;
                MessagingCenter.Send(this, "AddItem", _item);
                NavigationController.PopToRootViewController(true);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
