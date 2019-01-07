using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    //public class ProposalMemoryService : IProposalService
    //{
    //    private readonly List<ProposalModel> proposals = new List<ProposalModel>();
    //    public ProposalMemoryService()
    //    {
    //        proposals.Add(new ProposalModel
    //                         {
    //                                Id =1,ConferenceId=1,
    //                                Speaker ="Roland Guijt",
    //                                Title ="Understanding ASP.Net Core security"
    //                         });
    //        proposals.Add(new ProposalModel
    //        {
    //            Id = 2,
    //            ConferenceId = 2,
    //            Speaker = "John Reynold",
    //            Title = "Starting Your Developer Career",
    //            Approved=true
    //        });
    //        proposals.Add(new ProposalModel
    //        {
    //            Id = 3,
    //            ConferenceId = 2,
    //            Speaker = "Stan Lipens",
    //            Title = "ASP.NET Core TagHelper"
    //        });
    //    }
    //    public Task Add(ProposalModel model)
    //    {
    //        model.Id = proposals.Max(p => p.Id) + 1;
    //        proposals.Add(model);
    //        return Task.CompletedTask;
    //    }

    //    public Task<ProposalModel> Approve(int proposalId)
    //    {
    //        return Task.Run(()=> 
    //        {
    //            var proposal = proposals.FirstOrDefault(p => p.Id == proposalId);
    //            proposal.Approved = true;
    //            return proposal;
    //        });
    //    }

    //    public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
    //    {
    //        return Task.Run(() => proposals.Where(p=>p.ConferenceId==conferenceId));
    //    }
    //}
}
