using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class EventVM
    {
        public int Id { get; set; }
        public string EventUniqueName { get; set; }
        public bool isInternal { get; set; }
        public int AddressId { get; set; }
        public int OrganizerId { get; set; }
        public string OrganizerName { get; set; }
        public string Title { get; set; }
        public int TimeZoneId { get; set; }
        public string TimeZoneName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime RegStartDate { get; set; }
        public DateTime RegEndDate { get; set; }
        public TimeSpan RegStartTime { get; set; }
        public TimeSpan RegEndTime { get; set; }
        public int MaxRegistrationsAllowed { get; set; }
        public bool IsCpdevent { get; set; }
        public bool IsChargableEvent { get; set; }
        public bool ShowMaxRegistrationsAllowed { get; set; }
        public bool? AllowGuestRegistrations { get; set; }
        public int? GuestLimitPerRegistrant { get; set; }
        public bool AllowCancellations { get; set; }
        public int? CancellationbeforeDays { get; set; }
        public string Description { get; set; }
        public bool AllowRegistration { get; set; }



    }


}
