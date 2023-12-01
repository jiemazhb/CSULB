using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playlistify.DatabaseContext
{
    public class User:BaseEntity
    {

        [StringLength(60), Column(TypeName ="varchar")]
        public string Name { get; set; }
        [Required, StringLength(60), Column(TypeName = "varchar")]
        public string Email { get; set; }
        [Required, StringLength(60), Column(TypeName = "varchar")]
        public string Password { get; set; }
        //[StringLength(60), Column(TypeName = "int")]
        //public int PhoneNumber { get; set; }

    }
}
