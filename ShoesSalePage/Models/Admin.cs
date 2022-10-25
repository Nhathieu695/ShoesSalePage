//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoesSalePage.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminID { get; set; }
        [Required(ErrorMessage = "This can not be null")]
        [Display(Name = "Account")]
        public string AdminName { get; set; }
        [Required(ErrorMessage = "This can not be null")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "This can not be null")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string AdminPassword { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [NotMapped] // not create corresponding columns in the database
        [Required(ErrorMessage = "This can not be null")]
        [Compare("AdminPassword", ErrorMessage = "Password is incorrect")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string ConfirmPass { get; set; }
    }
}
