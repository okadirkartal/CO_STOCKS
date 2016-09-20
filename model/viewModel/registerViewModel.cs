using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model.viewModel
{
   public class registerViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "Username can be maximum 20 length")]
        public string username { get; set; }

        [StringLength(20, ErrorMessage = "Name can be maximum 50 length")]
        public string name { get; set; }

        [StringLength(20, ErrorMessage = "Surname can be maximum 50 length")]
        public string surname { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "Password can be maximum 20 length")]
        public string password { get; set; }

        [Required]
        public string passwordRepeat { get; set; }
    }
}
