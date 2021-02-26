using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }

        [Required]
        public string CatName { get; set; }

        public virtual List<CategoryNote> Note { get; set; }
    }
}
