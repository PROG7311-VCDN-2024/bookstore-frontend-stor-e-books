using System.ComponentModel.DataAnnotations;


namespace Stor_E_Books.Models
{
    public class SignUpModel
    {
        public SignUpModel(int id, string name, string email, string password)
        {
            this.id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public String Name {  get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]    
        public String Password { get; set; }


    }
}
