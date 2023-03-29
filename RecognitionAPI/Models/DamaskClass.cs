namespace RecognitionAPI.Models
{
    public partial class DamaskClass
    {
        public int id { get; set; }

        public string? ChannelName { get; set; }
        public DateTime? arrival_time { get; set; }

        public DateTime? departure_time { get; set; }

        public DateTime? Timestamp { get; set; }

        public string? truck_number { get; set; }

        public int? truck_id { get; set; }

        public DateTime? reg_time { get; set; }

        public DateTime? begin_service_time { get; set; }

        public DateTime? last_begin_service_time { get; set; }

        public DateTime? end_service_time { get; set; }

        public int? ticket_id { get; set; }

        public string? ticket_text { get; set; }      
    }
}
