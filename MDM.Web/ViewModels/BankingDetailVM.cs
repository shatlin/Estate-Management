using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class BankingDetailVM
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountTypeName { get; set; }
        public int AccountTypeId { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
    }


}
