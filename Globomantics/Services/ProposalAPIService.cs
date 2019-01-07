using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public class ProposalAPIService : IProposalService
    {
        private readonly HttpClient client;
        public ProposalAPIService(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("GlobomanticAPI");
        }
        public async Task Add(ProposalModel model)
        {
            await client.PostAsJsonAsync("v1/Proposal", model);
        }

        public async Task<ProposalModel> Approve(int proposalId)
        {
            var response = await client.PutAsync($"/v1/Proposal/{proposalId}",null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ProposalModel>();

            }
            throw new ArgumentException($"Error retrieving proposal {proposalId}" +
                $" Response: {response.ReasonPhrase}");
        }

        public async Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            var result = new List<ProposalModel>();
            var response = await client.GetAsync($"/v1/Proposal/{conferenceId}");
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsAsync<List<ProposalModel>>();
            else
                throw new HttpRequestException(response.ReasonPhrase);
            return result;
        }
    }
}
