namespace CallBackVKAPI.Models.DataBase
{
    public class Schedule
    {
        public int Id { get; set; }

        public int AuthorID { get; set; }

        public BotUser User { get; set; } = null!;

        public DateTime ScheduleDate { get; set; }

        public string ScheduleURL { get; set; } = null!;

        public byte[]? SheduleByteForm { get; set; } = null!;
    }
}
