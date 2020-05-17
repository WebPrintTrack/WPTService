using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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
            return "Lista printera";
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
