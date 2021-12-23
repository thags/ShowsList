using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shows.Models
{
    public class Show
    {
            public int Id { get; set; }
            [Required]
            public string Title { get; set; }
            [Range(0, 999, ErrorMessage ="Please input a number between 0 and 999")]
            public int TotalEpisodes { get; set; }
    }
}
