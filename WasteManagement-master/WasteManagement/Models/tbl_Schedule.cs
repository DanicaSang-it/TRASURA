using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WasteManagement.Models
{
    public class tbl_Schedule
    {
        dbcontrol s = new dbcontrol();
        public Int32 ID { get; set; }
        public String Schedule { get; set; }
        public string Description { get; set; }
        public tbl_user encBy { get; set; }
        public String encDate { get; set; }

        public tbl_Schedule()
        {
        }

        public tbl_Schedule(DataRow r)
        {
            ID = (Int32)r["ID"];
            Schedule = (String)r["Schedule"];
            Description = r["Description"].ToString();
            encBy = new tbl_user().Findtbl_user((Int32)r["encBy"]);
            encDate = r["encDate"].ToString();
        }

        public List<tbl_Schedule> Listtbl_Schedule()
        {
            var list = new List<tbl_Schedule>();
            s.Query("SELECT * FROM tbl_Schedule").ForEach(r =>
            {
                list.Add(new tbl_Schedule(r));
            });
            return list;
        }

        public tbl_Schedule Findtbl_Schedule(int ID)
        {
            var item = new tbl_Schedule();
            s.Query("SELECT * FROM tbl_Schedule WHERE ID = @ID", p => p.Add("@ID", ID)).ForEach(r =>
            {
                item = new tbl_Schedule(r);
            });
            return item;
        }

        public void Create(tbl_Schedule obj)
        {
            s.Insert("tbl_Schedule", p =>
            {
                p.Add("Schedule", obj.Schedule);
                p.Add("Description", obj.Description);
                p.Add("encBy", obj.encBy.ID);
            });
        }

        public void Update(tbl_Schedule obj)
        {
            s.Update("tbl_Schedule", obj.ID, p =>
            {
                p.Add("Schedule", obj.Schedule);
                p.Add("Description", obj.Description);
                p.Add("encBy", obj.encBy.ID);
            });
        }

        public void Delete(tbl_Schedule obj)
        {
            s.Query("delete from tbl_schedule where ID = @ID", p => p.Add("@ID", obj.ID));
        }
    }
}