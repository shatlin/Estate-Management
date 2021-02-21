using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class EventEquipmentVM
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public int RequiredCount { get; set; }
       
        

    }


}
