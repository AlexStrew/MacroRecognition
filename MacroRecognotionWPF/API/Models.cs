using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroRecognotionWPF.API
{
    public class Models
    {
        public class NumMain
        {
            [JsonProperty("idReco")]
            public int idReco { get; set; }
         
            [JsonProperty("EventId")]
            public string EventId { get; set; }

            public DateTime? Timestamp { get; set; }

            [JsonProperty("BinaryTimestamp")]
            public string BinaryTimestamp { get; set; }

            [JsonProperty("ZonedTimestamp")]
            public string ZonedTimestamp { get; set; }

            [JsonProperty("EventDescription")]
            public string EventDescription { get; set; }

            [JsonProperty("IsAlarmEvent")]
            public string IsAlarmEvent { get; set; }

            [JsonProperty("ChannelId")]
            public string ChannelId { get; set; }

            [JsonProperty("ChannelName")]
            public string ChannelName { get; set; }

            [JsonProperty("Comment")]
            public string Comment { get; set; }

            [JsonProperty("EventType")]
            public string EventType { get; set; }

            [JsonProperty("InitiatorName")]
            public string InitiatorName { get; set; }

            [JsonProperty("IsIdentified")]
            public string IsIdentified { get; set; }

            [JsonProperty("plateText")]
            public string PlateText { get; set; }

            [JsonProperty("Speed")]
            public string Speed { get; set; }

            [JsonProperty("Reliability")]
            public string Reliability { get; set; }

            [JsonProperty("Left")]
            public string Left { get; set; }

            [JsonProperty("Top")]
            public string Top { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("patronymic")]
            public string Patronymic { get; set; }

            [JsonProperty("carbrand")]
            public string Carbrand { get; set; }

            [JsonProperty("carcolor")]
            public string Carcolor { get; set; }

            [JsonProperty("additionalInfo")]
            public string AdditionalInfo { get; set; }

            [JsonProperty("groups")]
            public string Groups { get; set; }

            [JsonProperty("direction")]
            public List<string> Direction { get; set; }

            [JsonProperty("ExternalId")]
            public string ExternalId { get; set; }

            [JsonProperty("ExternalOwnerId")]
            public string ExternalOwnerId { get; set; }

            [JsonProperty("Width")]
            public string Width { get; set; }

            [JsonProperty("Height")]
            public string Height { get; set; }

            [JsonProperty("Numberplate")]
            public string Numberplate { get; set; }
        }
    }
}
