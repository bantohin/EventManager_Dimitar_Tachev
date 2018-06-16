using System;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string Location { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }
    }
}
