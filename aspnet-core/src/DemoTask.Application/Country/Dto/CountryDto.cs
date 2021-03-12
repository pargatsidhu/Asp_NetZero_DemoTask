using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.Country.Dto
{
   public class CountryDto : EntityDto<int>
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
