using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class DuplicatesVM
    {
        public int Id { get; set; }
        public string MemberGrade { get; set; }
        public string MemberType { get; set; }
        public string MemberStatus { get; set; }
        public string MemberNumber { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyName { get; set; }
        public string Branch { get; set; }
        public string RecordType { get; set; }
    }
}
