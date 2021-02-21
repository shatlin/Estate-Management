using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class EventMinuteVM
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int MinuteStatusId { get; set; }
        public string MinuteStatusName { get; set; }
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string Minute { get; set; }
        public int RaisedBy { get; set; }
        public int AssignedTo { get; set; }
        public bool? IsActive { get; set; }
        

    }


}
