using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryNoteCreate
    {
        [Required]
        public int NoteId { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
    }
}
