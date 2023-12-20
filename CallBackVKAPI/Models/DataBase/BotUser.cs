using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CallBackVKAPI.Models.DataBase
{
    public class BotUser
    {
        public int Id { get; set; }

        public long VkId { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsSubscriber { get; set; }

        public ICollection<Schedule>? Schedules { get; set; }
    }
}
