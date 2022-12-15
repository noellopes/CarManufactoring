﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManufactoring.Models
{
    public class Collaborator
    {

        [Key]
        public int CollaboratorId { get; set; }


        [StringLength(100, MinimumLength = 3,ErrorMessage = "Please Enter Collaborator's Full Name!")]
        [Required(ErrorMessage = "Please Enter Collaborator's Name!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Enter Collaborator's Birth Date!")]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime BirthDate { get; set; }
        //public DateOnly? BirthDate { get; set; }



        [Required(ErrorMessage = "Collaborator's Phone Number is Required!")]
        [StringLength(20)]
        [Phone(ErrorMessage = "Please Enter  a Valid Phone Number")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Collaborator's E-Mail! is Required!")]
        [EmailAddress(ErrorMessage = "Please Enter  a Valid Email Address!")]
        [StringLength(256)]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        public Gender? Genders { get; set; }
        //to be replaced with enum since the genders are limited

        public Task? Task { get; set; }

        public ICollection<CollaboratorShifts>? Shifts { get; set; }

        [Required]
        public bool OnDuty { get; set; }

        public string? Status { get; set; }
    }
}