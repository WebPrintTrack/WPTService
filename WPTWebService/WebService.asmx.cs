using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using Newtonsoft.Json;
using Microsoft.ApplicationBlocks.Data;

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
        string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Login(string username, string password)
        {
            string loginResult = SqlHelper.ExecuteScalar(cs, "sqlLogin", username, password).ToString(); 
            return loginResult;
        }

        [WebMethod]
        public string GetAllPrinters(string username, string password)
        {
            return "Username: " + username + "   | Lozinka: " + password;
        }

        [WebMethod]
        public string GetOrganisationPrinters(int organisationID)
        {
            
            DataTable dtPrinters = new DataTable();

           

            dtPrinters.Columns.Add("IDPrinter");
            dtPrinters.Columns.Add("SerijskiBroj");
            dtPrinters.Columns.Add("ModelID");
            dtPrinters.Columns.Add("KorisnikID");
            dtPrinters.Columns.Add("TintaID");
            dtPrinters.Columns.Add("DatumPrveInstalacije");
            dtPrinters.Columns.Add("ServisniPeriod");
            dtPrinters.Columns.Add("ServisniPeriodDatumKraja");
            



            
            DataSet ds = SqlHelper.ExecuteDataset(cs, "ListPrintersForKorisnik", organisationID);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dtPrinters.Rows.Add(row["IDPrinter"].ToString(), row["SerijskiBroj"].ToString(), row["ModelID"].ToString(), row["KorisnikID"].ToString(), row["TintaID"].ToString(), row["DatumPrveInstalacija"].ToString(), row["ServisniPeriod"].ToString(), row["ServisniPeriodDatumKraja"].ToString());
               
            }


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
