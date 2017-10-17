using System.Collections;

namespace playground
{
	public class DiscoverQueryResult
	{
		public ProjectModel[] Discover { get; set; }
	}

    public class ProjectModel : BaseDataObject
    {
        public ProjectModel() : base()
        {
        }

        string headerImageURL = string.Empty;
        public string HeaderImageURL
        {
            get { return headerImageURL; }
            set { SetProperty(ref headerImageURL, value); }
        }

        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        string description = string.Empty;
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value); }
		}

		string objective = string.Empty;
		public string Objective
		{
			get { return objective; }
			set { SetProperty(ref objective, value); }
		}

        UserModel author = new UserModel();
		public UserModel Author
		{
			get { return author; }
			set { SetProperty(ref author, value); }
		}

		ArrayList tags = new ArrayList();
		public ArrayList Tags
		{
			get { return tags; }
			set { SetProperty(ref tags, value); }
		}



	}
}
