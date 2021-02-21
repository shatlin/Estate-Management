using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MM.ClientModels
{
    public partial class EmailTemplateContentVM
    {
        public int Id { get; set; }
        public string EmailContent { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }

    }


}
