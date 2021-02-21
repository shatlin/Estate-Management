using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class EventCostVM
    {
        public int Id { get; set; }
        public int EventCostItemId { get; set; }
        public string EventCostItemName { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public decimal Amount { get; set; }
        public bool? IsActive { get; set; }
        

    }


}
