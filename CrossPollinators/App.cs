﻿using System;
using System.Collections.Generic;

namespace playground
{
    public partial class App
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "http://192.168.1.222:3030";

        public App()
        {
        }

        public static void Initialize()
        {
            Settings.UserId = "";

            if (UseMockDataStore){
                ServiceLocator.Instance.Register<IDataStore<ProjectModel>, GraphQLClient>();
            }else
                ServiceLocator.Instance.Register<IDataStore<ProjectModel>, CrossPollinatorsAPI>();



#if __IOS__
			ServiceLocator.Instance.Register<IMessageDialog, iOS.MessageDialog>();
#else
            ServiceLocator.Instance.Register<IMessageDialog, Droid.MessageDialog>();
#endif
        }

        public static IDictionary<string, string> LoginParameters => null;
    }
}
