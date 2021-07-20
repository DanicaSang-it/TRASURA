using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WasteManagement.Models
{
    public class tbl_Bin
    {
        dbcontrol s = new dbcontrol();
        public Int32 ID { get; set; }

        [Display(Name = "Bin ID")]
        public String BinID { get; set; }

        [Display(Name = "Max Capacity")]
        public Int32 MaxCapacity { get; set; }

        [Display(Name = "Current Capacity")]
        public Int32 CurrentCapacity { get; set; }

        [Display(Name = "Location")]
        public String Location { get; set; }

        [Display(Name = "Collector Phone No.")]
        public String CollectorPhone { get; set; }

        [Display(Name = "Deployment Date")]
        public String DeploymentDate { get; set; }

        public string Status { get { return "bg-green"; } }
        public tbl_Bin()
        {
        }
        public tbl_Bin(DataRow r)
        {
            ID = (Int32)r["ID"];
            BinID = (String)r["BinID"];
            MaxCapacity = (Int32)r["MaxCapacity"];
            CurrentCapacity = (Int32)r["CurrentCapacity"];
            Location = (String)r["Location"];
            CollectorPhone = (String)r["CollectorPhone"];
            DeploymentDate = r["DeploymentDate"].ToString();
        }
        public List<tbl_Bin> Listtbl_Bin()
        {
            var list = new List<tbl_Bin>();
            s.Query("SELECT * FROM tbl_Bin").ForEach(r =>
            {
                list.Add(new tbl_Bin(r));
            });
            return list;
        }
        public tbl_Bin Findtbl_Bin(int ID)
        {
            var item = new tbl_Bin();
            s.Query("SELECT * FROM tbl_Bin WHERE ID = @ID", p => p.Add("@ID", ID)).ForEach(r =>
            {
                item = new tbl_Bin(r);
            });
            return item;
        }
        public void Create(tbl_Bin obj)
        {
            s.Insert("tbl_Bin", p =>
            {
                p.Add("BinID", obj.BinID);
                p.Add("Location", obj.Location);
                p.Add("CollectorPhone", obj.CollectorPhone);
                p.Add("DeploymentDate", obj.DeploymentDate);
            });
        }
        public void Update(tbl_Bin obj)
        {
            s.Update("tbl_Bin", obj.ID, p =>
            {
                p.Add("BinID", obj.BinID);
                p.Add("MaxCapacity", obj.MaxCapacity);
                p.Add("CurrentCapacity", obj.CurrentCapacity);
                p.Add("Location", obj.Location);
                p.Add("CollectorPhone", obj.CollectorPhone);
                p.Add("DeploymentDate", obj.DeploymentDate);
            });
        }
    }
}