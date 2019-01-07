using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public class ConferenceAPIService : IConferenceService
    {
        private readonly HttpClient client;
        public ConferenceAPIService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:5000");
            client = httpClient;
        }
        public async Task Add(ConferenceModel model)
        {
            await client.PostAsJsonAsync("/v1/Conference", model);
        }

        public async Task<IEnumerable<ConferenceModel>> GetAll()
        {
            List<ConferenceModel> result;
            var response = await client.GetAsync("/v1/Conference");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<ConferenceModel>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);

            return result;
        }

        public async Task<ConferenceModel> GetByid(int id)
        {
            var result = new ConferenceModel();
            var response = await client.GetAsync($"/v1/Conference/{id}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<ConferenceModel>();

            return result;
        }

        public async Task<StatisticsModel> GetStatistics()
        {
            var result = new StatisticsModel();
            var response = await client.GetAsync($"/v1/Statistics");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<StatisticsModel>();

            return result;
        }
    }
}
