using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpanseTrackingSystem.Context
{
    public class ExpanseCategory
    {
        public int Id { get; set; }
        [Display(Name = "Category Name")]
        [Required]
        public string CategoryName { get; set; }
        public string Details { get; set; }
        public virtual ICollection<Expanse> Expanses { get; set; }
    }
}
