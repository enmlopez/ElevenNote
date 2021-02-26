﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryDetail
    {
        public int CatId { get; set; }
        public string Name { get; set; }
        public virtual List<NoteListItem> Notes { get; set; }
    }
}
