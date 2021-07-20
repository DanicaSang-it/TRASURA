using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace WasteManagement.Models
{
    public class tbl_Remarks
    {
        dbcontrol s = new dbcontrol();
        public Int32 ID { get; set; }
        [Required]
        public String Remarks { get; set; }
        public tbl_user encBy { get; set; }
        public String encDate { get; set; }
        public tbl_Remarks()
        {
        }
        public tbl_Remarks(DataRow r)
        {
            ID = (Int32)r["ID"];
            Remarks = (String)r["Remarks"];
            encBy = new tbl_user().Findtbl_user((Int32)r["encBy"]);
            encDate = r["encDate"].ToString();
        }

        public List<tbl_Remarks> Listtbl_Remarks()
        {
            var list = new List<tbl_Remarks>();
            s.Query("SELECT * FROM tbl_Remarks ORDER BY ID DESC").ForEach(r =>
            {
                list.Add(new tbl_Remarks(r));
            });
            return list;
        }

        public List<tbl_Remarks> Listtbl_RemarksUser(int userID)
        {
            var list = new List<tbl_Remarks>();
            s.Query("SELECT * FROM tbl_Remarks WHERE encBy = @ID", p => p.Add("@ID", userID)).ForEach(r =>
            {
                list.Add(new tbl_Remarks(r));
            });
            return list;
        }

        public tbl_Remarks Findtbl_Remarks(int ID)
        {
            var item = new tbl_Remarks();
            s.Query("SELECT * FROM tbl_Remarks WHERE ID = @ID", p => p.Add("@ID", ID)).ForEach(r =>
            {
                item = new tbl_Remarks(r);
            });
            return item;
        }
        public void Create(tbl_Remarks obj)
        {
            s.Insert("tbl_Remarks", p =>
            {
                p.Add("Remarks", obj.Remarks);
                p.Add("encBy", obj.encBy.ID);
            });
        }
        public void Update(tbl_Remarks obj)
        {
            s.Update("tbl_Remarks", obj.ID, p =>
            {
                p.Add("Remarks", obj.Remarks);
                p.Add("encBy", obj.encBy.ID);
            });
        }
    }
}