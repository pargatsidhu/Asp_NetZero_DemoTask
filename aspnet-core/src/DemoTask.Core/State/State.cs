using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.State
{
    [Table("tblState")]
    public class State : FullAuditedEntity
    {

        public const int MaxCountryNameLength = 255;
         
        [Required]
        [MaxLength(MaxCountryNameLength)]
        public virtual string Name { get; set; }
        
        [MaxLength(MaxCountryNameLength)]
        public virtual string Descreption { get; set; }
        
        [MaxLength(MaxCountryNameLength)]
        public virtual string CountryName { get; set; }

       
    }
}
