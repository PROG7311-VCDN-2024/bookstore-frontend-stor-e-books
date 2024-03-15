namespace Stor_E_Books.Models
{
    public class AdminReg
    {
        public AdminReg(int adminID, string adminName, string adminSurname, string adminEmail, string adminPassword)
        {
            this.adminID = adminID;
            this.adminName = adminName;
            this.adminSurname = adminSurname;
            this.adminEmail = adminEmail;
            this.adminPassword = adminPassword;
        }

        public int adminID { get; set; }
        public string adminName { get; set; }
        public string  adminSurname { get; set; }
        public string adminEmail { get; set; }
        public string adminPassword { get; set; }
       
    }
}
