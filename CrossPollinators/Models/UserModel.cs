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

		string username = string.Empty;
		public string Username
		{
			get { return username; }
			set { SetProperty(ref username, value); }
		}

		string organization = string.Empty;
		public string Organization
		{
			get { return organization; }
			set { SetProperty(ref organization, value); }
		}

	}
}
