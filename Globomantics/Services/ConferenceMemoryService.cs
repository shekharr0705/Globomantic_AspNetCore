using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models;

namespace Globomantics.Services
{
    public class ConferenceMemoryService : IConferenceService
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();
        public ConferenceMemoryService()
        {
            conferences.Add(new ConferenceModel { Id = 1, Name = "NDC", Location = "Oslo" ,AttendeeTotal=100});
            conferences.Add(new ConferenceModel { Id = 2, Name = "IT/DevConnections", Location = "London" ,AttendeeTotal=150});
            conferences.Add(new ConferenceModel { Id = 2, Name = "Re:Invent", Location = "NewYork", AttendeeTotal = 200 });
        }
        public Task Add(ConferenceModel model)
        {
            model.Id = conferences.Max(_c => _c.Id) + 1;
            conferences.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(() => conferences.AsEnumerable());
        }

        public Task<ConferenceModel> GetByid(int id)
        {
            return Task.Run(() => conferences.FirstOrDefault(_c => _c.Id == id));
        }

        public Task<StatisticsModel> GetStatistics()
        {
            return Task.Run(() =>
            {   
                return new StatisticsModel
                {
                    NumberOfAttendees = conferences.Sum(c => c.AttendeeTotal),
                    AverageConferenceAttendees = (int)conferences.Average(c => c.AttendeeTotal)
                };
            });
        }
    }
}
