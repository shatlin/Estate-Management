using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class PlanDetailVM
    {
        public int Id { get; set; }
        public int PlanMasterId { get; set; }
        public string PlanMasterName { get; set; }
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public int PlanFrequencyId { get; set; }
        public string PlanFrequencyName { get; set; }
        public decimal Amount { get; set; }

    }


}
