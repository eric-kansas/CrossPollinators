using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

namespace playground
{
    public class CrossPollinatorsAPI
    {
        HttpClient client;
        IEnumerable<ProjectModel> items;

        public CrossPollinatorsAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<ProjectModel>();
        }

        public async Task<String> Login(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var response = await client.GetStringAsync($"login/");
                return response;
            }

            return "";
        }
    }
}
