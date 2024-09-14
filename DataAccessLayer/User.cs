using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(100, ErrorMessage = "Input valid name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Invalid email address.")]
        [StringLength(70, ErrorMessage = "Enter valid address.")]
        public string Email { get; set; }

        [Display(Name = "Phone No.")]
        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression("^\\(?([0-9]{3})\\)?[- ]?([0-9]{3})[- ]?([0-9]{4})$", ErrorMessage = "Invalid phone number.")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [StringLength(250, ErrorMessage = "Enter valid address.")]
        public string Address { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required.")]
        public int StateId { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        public int CityId { get; set; }
    }
}
