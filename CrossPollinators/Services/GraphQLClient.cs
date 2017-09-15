using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace playground.Services
{
    public class GraphResult<T>
	{
		public T Data { get; set; }
	}

	public class GraphClient
	{
		private const string crossPollinatorsHost = "https://api.github.com/graphql";

		private readonly HttpClient _client;

		public GraphClient()
		{
			_client = new HttpClient();
			//_client.DefaultRequestHeaders.Add("Authorization", "Bearer your-bearer-token-goes-here");
			//_client.DefaultRequestHeaders.Add("User-Agent", "Xamarin-GraphQL-Demo");
		}

		public async Task<T> Query<T>(string query)
		{
			var graphQuery = new { query };
			var content = new StringContent(JsonConvert.SerializeObject(graphQuery), Encoding.UTF8, "application/json");

			var response = await _client.PostAsync("https://api.github.com/graphql", content);
			var json = await response.Content.ReadAsStringAsync();

			var graphResult = JsonConvert.DeserializeObject<GraphResult<T>>(json);

			return graphResult.Data;
		}
	}
}
