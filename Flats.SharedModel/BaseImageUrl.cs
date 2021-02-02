using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flats.SharedModel
{
    public class BaseImageUrl
    {
        public Guid Id { get; set; }

        [Display(Name = "Image")]
        [Required]
        public string ImageUrl { get; set; }
    }
}
