using System.Collections;

namespace playground
{
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

        string headerText = string.Empty;
        public string HeaderText
        {
            get { return headerText; }
            set { SetProperty(ref headerText, value); }
        }

		string subHeader = string.Empty;
		public string SubHeader
		{
			get { return subHeader; }
			set { SetProperty(ref subHeader, value); }
		}

		string body = string.Empty;
		public string Body
		{
			get { return body; }
			set { SetProperty(ref body, value); }
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
