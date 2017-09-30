using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playground
{
    public class ProjectDetailViewModel : BaseViewModel
    {
        public ProjectModel Item { get; set; }

        public ProjectDetailViewModel(ProjectModel item = null)
        {
            if (item != null)
            {
                Title = item.Name;
                Item = item;
            }
        }

    }
}
