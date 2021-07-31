using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootMark.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Email is Required")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreateDate { get; set; }
    }
}
