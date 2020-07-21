using SnailFis.Data.Common;
using SnailFis.Data.Dals.Common;
using SnailFis.Data.EfModel;
using SnailFis.Data.Models.BaseData;
using SnailFis.Model.BusinessModels.XmlData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SnailFis.Data.Dals.BaseData
{
    /// <summary>
    /// Xml数据层
    /// </summary>
    public class XmlDal : BaseDal
    {
        XmlHelper xmlHelper;
        public XmlDal(int userSn) : base(userSn)
        {
            xmlHelper = new XmlHelper();
        }

        public List<BankModel> GetBankList() 
        {
            var list = new List<BankModel>();
            XmlDocument document = xmlHelper.GetXmlDocument(XmlName.BankData);
            XmlElement element = document.DocumentElement;
            XmlNodeList xmlList = element.ChildNodes;
            foreach (XmlElement nodeList in xmlList) 
            {
                var name = nodeList.SelectNodes("name")[0].InnerText;
                var code = Convert.ToInt32(nodeList.SelectNodes("code")[0].InnerText);
                list.Add(new BankModel() { BankName=name,BankId=code});
            }
            return list;
        }
    }
}
