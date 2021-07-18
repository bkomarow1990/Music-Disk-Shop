using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ArtishId { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public int GanreId { get; set; }
        public int AuditionNumber { get; set; }

    }
}
