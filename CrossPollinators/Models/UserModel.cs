namespace playground
{
	public class UserModel : BaseDataObject
	{
		public UserModel() : base()
		{
		}

		string avatarURL = string.Empty;
		public string AvatarURL
		{
			get { return avatarURL; }
			set { SetProperty(ref avatarURL, value); }
		}

		string fullname = string.Empty;
		public string Full_Name
		{
			get { return fullname; }
			set { SetProperty(ref fullname, value); }
		}

		string organization = string.Empty;
		public string Organization
		{
			get { return organization; }
			set { SetProperty(ref organization, value); }
		}

	}
}
