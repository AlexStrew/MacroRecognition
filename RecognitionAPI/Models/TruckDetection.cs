using System;
using System.Collections.Generic;

namespace RecognitionAPI.Models;

public partial class TruckDetection
{
    public int IdReco { get; set; }

    public string? EventId { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? BinaryTimestamp { get; set; }

    public string? ZonedTimestamp { get; set; }

    public string? EventDescription { get; set; }

    public string? IsAlarmEvent { get; set; }

    public string? ChannelId { get; set; }

    public string? ChannelName { get; set; }

    public string? Comment { get; set; }

    public string? EventType { get; set; }

    public string? InitiatorName { get; set; }

    public string? IsIdentified { get; set; }

    public string? PlateText { get; set; }

    public string? Speed { get; set; }

    public string? Reliability { get; set; }

    public string? Left { get; set; }

    public string? Top { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public string? Carbrand { get; set; }

    public string? Carcolor { get; set; }

    public string? AdditionalInfo { get; set; }

    public string? Groups { get; set; }

    public string? Direction { get; set; }

    public string? ExternalId { get; set; }

    public string? ExternalOwnerId { get; set; }

    public string? Width { get; set; }

    public string? Height { get; set; }

    public string? Numberplate { get; set; }
}
