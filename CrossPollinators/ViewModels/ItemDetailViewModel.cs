using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playground
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ProjectModel Item { get; set; }
        public ItemDetailViewModel(ProjectModel item = null)
        {
            if (item != null)
            {
                Title = item.HeaderText;
                Item = item;
            }
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
