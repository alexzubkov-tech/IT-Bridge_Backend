using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationService.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public List<string> UserIds { get; set; }

        public Notification(int id,int questionId, List<string> userIds)
        {
            Id = id; 
            QuestionId = questionId;
            UserIds = userIds;
        }
    }
}
