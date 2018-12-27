using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetByid(int id);
        Task<StatisticsModel> GetStatistics();
        Task Add(ConferenceModel model);
    }
}
