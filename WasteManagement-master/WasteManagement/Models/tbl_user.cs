using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WasteManagement.Models
{
    public class tbl_user
    {
        dbcontrol s = new dbcontrol();
        public Int32 ID { get; set; }

        [Required]
        public String Username { get; set; }

        [Required]
        public String Password { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        public String Email { get; set; }

        [Display(Name = "Given name")]
        [Required]
        public String Fname { get; set; }

        [Display(Name = "Middle name")]
        [Required]
        public String Mn { get; set; }

        [Display(Name = "Surname")]
        [Required]
        public String Lname { get; set; }

        [Required]
        public String Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        public String Bday { get; set; }
        public bool isAdmin { get; set; }
        public String encDate { get; set; }
        public string Fullname { get { return $"{Lname}, {Fname} {Mn}"; } }
        public tbl_user()
        {
        }
        public tbl_user(DataRow r)
        {
            ID = (Int32)r["ID"];
            Username = (String)r["Username"];
            Password = (String)r["Password"];
            Email = (String)r["Email"];
            Fname = (String)r["Fname"];
            Mn = (String)r["Mn"];
            Lname = (String)r["Lname"];
            Gender = (String)r["Gender"];
            Bday = r["Bday"].ToString();
            isAdmin = (bool)r["isAdmin"];
            encDate = r["encDate"].ToString();
        }
        public List<tbl_user> Listtbl_user()
        {
            var list = new List<tbl_user>();
            s.Query("SELECT * FROM tbl_user").ForEach(r =>
            {
                list.Add(new tbl_user(r));
            });
            return list;
        }
        public tbl_user Findtbl_user(int ID)
        {
            var item = new tbl_user();
            s.Query("SELECT * FROM tbl_user WHERE ID = @ID", p => p.Add("@ID", ID)).ForEach(r =>
            {
                item = new tbl_user(r);
            });
            return item;
        }

        public tbl_user Login(string username, string password)
        {
            var item = new tbl_user();
            s.Query("Login", p =>
            {
                p.Add("@username", username);
                p.Add("@password", password);
            }, CommandType.StoredProcedure).ForEach(r =>
            {
                var result = (bool)r["isValid"];
                if (result)
                {
                    item = new tbl_user(r);
                }
            });
            return item;
        }

        public bool Create(tbl_user obj)
        {
            var output = false;
            s.Query("Register", p =>
            {
                p.Add("@Username", obj.Username);
                p.Add("@Password", obj.Password);
                p.Add("@Email", obj.Email);
                p.Add("@Fname", obj.Fname);
                p.Add("@Mn", obj.Mn);
                p.Add("@Lname", obj.Lname);
                p.Add("@Gender", obj.Gender);
                p.Add("@Bday", obj.Bday);
            }, CommandType.StoredProcedure).ForEach(r => 
            {
                var result = (bool)r["isValid"];
                if (result)
                {
                    output = result;
                }
            });
            return output;
        }

        public void Update(tbl_user obj)
        {
            s.Update("tbl_user", obj.ID, p =>
            {
                p.Add("ID", obj.ID);
                p.Add("Username", obj.Username);
                p.Add("Password", obj.Password);
                p.Add("Email", obj.Email);
                p.Add("Fname", obj.Fname);
                p.Add("Mn", obj.Mn);
                p.Add("Lname", obj.Lname);
                p.Add("Gender", obj.Gender);
                p.Add("Bday", obj.Bday);
            });
        }
    }
}