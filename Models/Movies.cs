using System;
using System.ComponentModel.DataAnnotations;
namespace Assignment9_2.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public string Edited { get; set; }
        
        public string LentTo { get; set; }

        public string Notes { get; set; }

    }
}
