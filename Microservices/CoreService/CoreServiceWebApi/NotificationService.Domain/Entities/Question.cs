using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Entities
{
    public class Question
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<string> SpecializationNames { get; set; }

        public Question(string id, string title, List<string> specializationNames)
        {
            Id = id;
            Title = title;
            SpecializationNames = specializationNames;
        }
    }
}
