﻿using System.ComponentModel.DataAnnotations;

namespace CertStore.Models
{
    public class FullCategory
    {
        [Key]
        public int FullId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
