﻿using System.ComponentModel.DataAnnotations;

namespace CarManufactoring.Models
{
    public class Collaborator
    {

        [Key]
        public int CollaboratorId { get; set; }
        //to do : validation messages - mustafa
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly BirthDate { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        public Gender Genders { get; set; }
        //to be replaced with enum since the genders are limited

        public Task? Task { get; set; }

        //public ICollection<CollaboratorShift>? Shifts { get; set; }
        //To be added by Ana 

        [Required]
        public bool OnDuty { get; set; }

        public string? Status { get; set; }
    }
}