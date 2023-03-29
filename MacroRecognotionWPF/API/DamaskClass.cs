using System;

namespace MacroRecognotionWPF.API
{
    public partial class DamaskClass
    {
        public long id { get; set; }

        public DateTime? arrival_time { get; set; }

        public DateTime? arrivalHour
        {
            get
            {
                return arrival_time;
            }
        }
        public DateTime? arrivalMinutes
        {
            get
            {
                return arrival_time;
            }
        }
        public DateTime? Timestamp { get; set; }

        public DateTime? arrivalHourT
        {
            get
            {
                return Timestamp;
            }
        }
        public DateTime? arrivalMinutesT
        {
            get
            {
                return Timestamp;
            }
        }
        public DateTime? departure_time { get; set; }

        public string? truck_number { get; set; }

        public int? truck_id { get; set; }

        private DateTime? _reg_time;

        public DateTime? reg_time { 
            get
            {
                if (_reg_time != null)
                {
                    return _reg_time.Value.AddHours(5);
                }
                return _reg_time;
            }
            set
            {
                _reg_time = value;
            }
        }

        public DateTime? regHour
        {
            get
            {
                return reg_time;
            }
        }
        public DateTime? regMinutes
        {
            get
            {
                return reg_time;
            }
        }

        public DateTime? begin_service_time { get; set; }

        public DateTime? last_begin_service_time { get; set; }

        public DateTime? end_service_time { get; set; }

        public int? ticket_id { get; set; }

        public string? ticket_text { get; set; }      
    }
}
