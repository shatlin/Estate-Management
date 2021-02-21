using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class CpdmemberTeamSetUpVM
    {
        public int Id { get; set; }
        public int RelatedToId { get; set; }
        public string RelatedToName { get; set; }
        public int RelatedRecordId { get; set; }
        public int? MemberTeamlId { get; set; }
        public string MemberTeamName { get; set; }
        public int Cpdcount { get; set; }

    }


}
