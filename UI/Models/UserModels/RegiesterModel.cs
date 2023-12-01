using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI.Models.UserModels
{
    public class RegiesterModel
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required, StringLength(maximumLength:50, MinimumLength = 6)]
        public string Password { get; set; }
        [Required, Compare(otherProperty: nameof(Password))]
        public string Confirm { get; set; }
    }
}