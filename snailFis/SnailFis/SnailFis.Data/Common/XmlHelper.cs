using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace SnailFis.Data.Common
{
    public class XmlHelper
    {
        public XmlDocument GetXmlDocument(XmlName xmlName) 
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath($@"\Config\{GetXmlName(xmlName)}.xml"));
            return document;
        }
        private string GetXmlName(XmlName xmlName) {
            switch (xmlName) {
                case XmlName.BankData: return "BankData";
                default:return "";
            }
        }
    }

    public enum XmlName 
    {
        BankData
    }
}
