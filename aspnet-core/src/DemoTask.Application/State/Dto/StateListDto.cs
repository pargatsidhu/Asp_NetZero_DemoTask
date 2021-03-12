using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask.State.Dto
{
    public class GetStateInput
    {
        public string Filter { get; set; }
    }
    public class StateListDto : EntityDto
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
