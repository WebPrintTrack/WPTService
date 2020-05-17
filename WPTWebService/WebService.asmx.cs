using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;

namespace WPTWebService
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string SignUp(string username, string password)
        {
            return "Username: "+username+"   | Lozinka: "+password;
        }

        [WebMethod]
        public string Login(string username, string password)
        {
            return "Username: " + username + "   | Lozinka: " + password;
        }

        [WebMethod]
        public string GetPrinters(int organisationID)
        {
            DataTable dtPrinters = new DataTable();
        
            dtPrinters.Columns.Add("Serijski broj");
            dtPrinters.Columns.Add("Marka");
            dtPrinters.Columns.Add("Model");
            dtPrinters.Columns.Add("Datum prve instalacije");
            dtPrinters.Columns.Add("Tip tinte");

            dtPrinters.Rows.Add("222334","Videojet","1610","10.04.2010","V410");
            dtPrinters.Rows.Add("111334", "Videojet", "1620", "10.04.2013", "V410");
            dtPrinters.Rows.Add("223334", "Videojet", "1220", "10.04.2018", "V411");
            dtPrinters.Rows.Add("222356", "Videojet", "1210", "10.04.2019", "V411");


            return JsonConvert.SerializeObject(dtPrinters);
        }

        [WebMethod]
        public string RequestService(int printerID, string requestDescription)
        {
            return "Poslan zahtjev za servisom printera:" + printerID+ "  opis zahtjeva: "+ requestDescription;
        }

        [WebMethod]
        public string checkForServiceReports(int IDOrganisation)
        {
            return "Vraca listu radnih naloga";
        }
    }
}
