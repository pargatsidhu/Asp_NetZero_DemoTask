using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.Country
{
    [Table("tblCountry")]
    public class Country : FullAuditedEntity
    {
        
        public const int MaxCountryNameLength = 255;

        [Required]
        [MaxLength(MaxCountryNameLength)]
        public virtual string Name { get; set; }
 
    }
}
