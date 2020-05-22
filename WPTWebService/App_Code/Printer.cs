using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPTWebService.App_Code
{
    public class Printer
    {

        public int ID { get; set; }
        public string Tip { get; set; }
        public string Proizvodjac { get; set; }
        public int Godina { get; set; }
        public int KS { get; set; }

        public Printer()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}