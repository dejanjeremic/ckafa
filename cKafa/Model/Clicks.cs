using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cKafa.Model
{
    [Table("clicks")]

    public class Clicks
    {
        [Key]
        public Guid uid { get; set; }
        public DateTime create_date { get; set; }
        public DateTime time1 { get; set; }
        public DateTime time2 { get; set; }
        public int? misclicks1 { get; set; }
        public int? misclicks2 { get; set; }
        public int? window_width { get; set; }
    }
}
