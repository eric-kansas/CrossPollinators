using System;
using System.Collections.Generic;

namespace playground
{
    public partial class App
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "http://localhost:5000";

        public App()
        {
        }

        public static void Initialize()
        {
            if (UseMockDataStore){
                Console.WriteLine("Kansas init mock");
                ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
            }else
                ServiceLocator.Instance.Register<IDataStore<Item>, CloudDataStore>();

#if __IOS__
			ServiceLocator.Instance.Register<IMessageDialog, iOS.MessageDialog>();
#else
            ServiceLocator.Instance.Register<IMessageDialog, Droid.MessageDialog>();
#endif
        }

        public static IDictionary<string, string> LoginParameters => null;
    }
}
