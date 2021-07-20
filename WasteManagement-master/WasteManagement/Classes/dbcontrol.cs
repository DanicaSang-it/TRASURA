using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AAJdbController;
using System.Configuration;
namespace WasteManagement
{
    public class dbcontrol : AAJControl
    {
        public dbcontrol() : base(DatabaseType.SQLServer, ConfigurationManager.ConnectionStrings["TRASURA"].ConnectionString)
        {
            ErrorOccured += Dbcontrol_ErrorOccured;
        }

        private void Dbcontrol_ErrorOccured(ErrorMessage e)
        {
            HttpContext.Current.Response.Write(e.ExceptionMessage);
        }
    }
}