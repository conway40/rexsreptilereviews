using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace RexsReptileReviews.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        public string Author { get; set; }

        //public DateTime DateTime { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Review titles are limited to 100 characters.")]
        public string Title { get; set; }

        [Required]
        public ReptileType Reptile { get; set; }

        [Required]
        [Range(1,5, ErrorMessage = "Rating must be an integer between 1 and 5.")]
        public int Rating { get; set; }

        [Required]
        [Display(Name = "Experience Level")]
        public ExperienceLevelType ExperienceLevel { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage ="Review bodies are limited to 1,000 characters.")]
        public string Body { get; set; }
    }
}