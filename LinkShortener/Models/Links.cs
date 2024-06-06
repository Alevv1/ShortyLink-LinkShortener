using System;
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Models
{
    public class Links
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The original URL is required.")]
        [Url(ErrorMessage = "The original URL is not a valid URL.")]
        public string? OriginalUrl { get; set; }

        public string? ShortUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
