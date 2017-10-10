using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

using Plugin.Connectivity;

namespace playground
{
    public class GraphResult<T>
	{
		public T Data { get; set; }
	}

	public class GraphQLClient : IDataStore<ProjectModel>
	{
		private const string crossPollinatorsHost = "http://192.168.1.133:3030/graphql";

		private readonly HttpClient _client;

        private IEnumerable<ProjectModel> items;

        private const string DiscoverQuery = "{ \"query\": \"{ discover (first: 15) { name description objective author { id full_name organization } } }\" }";


		public GraphQLClient()
		{
			_client = new HttpClient();
			//_client.DefaultRequestHeaders.Add("Authorization", "Bearer your-bearer-token-goes-here");
			//_client.DefaultRequestHeader s.Add("User-Agent", "Xamarin-GraphQL-Demo");
		}

		public async Task<IEnumerable<ProjectModel>> GetItemsAsync(bool forceRefresh = false)
		{
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var content = new StringContent(DiscoverQuery, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(crossPollinatorsHost, content);
                var json = await response.Content.ReadAsStringAsync();

                var graphResult = JsonConvert.DeserializeObject<GraphResult<DiscoverQueryResult>>(json);

                items = graphResult.Data.Discover;
            }
			return items;
		}

		public async Task<ProjectModel> GetItemAsync(string id)
		{
			return null;
		}

	}
}
