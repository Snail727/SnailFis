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
        public XmlDal(int sfId, int userSn) : base(sfId, userSn)
        {
            xmlHelper = new XmlHelper();
        }

        public List<BankModel> GetBankList() 
        {
using (var snailFisDbContext = new SnailFisDbContext()) {
    snailFisDbContext.DicList.Add(new DicDbModel() {SfId=1,DicId=1,DicName="新华字典" });
    snailFisDbContext.DicList.Add(new DicDbModel() {SfId=2,DicId=2,DicName="新华大字典" });
    snailFisDbContext.SaveChanges();
}
using (var snailFisDbContext = new SnailFisDbContext())
{
    var sql = snailFisDbContext.DicList.SqlQuery("select * from [DicList] where [SfId] > 1");
    snailFisDbContext.DicList.RemoveRange(sql);
    var delList = snailFisDbContext.DicList.Where(v=>v.SfId>1);
    snailFisDbContext.DicList.RemoveRange(delList);
    snailFisDbContext.SaveChanges();
}

using (var snailFisDbContext = new SnailFisDbContext())
{
    var tempModel = snailFisDbContext.DicList.FirstOrDefault(v => v.SfId == 1);//修改需要把对应的数据先拿出来
                if (tempModel != null) {
        tempModel.DicName = "新华词典";
    }
    var updateList = snailFisDbContext.DicList.Where(v => v.SfId > 1);//当然也可以批量修改
    updateList.ToList().ForEach(v => {
        v.DicName = "待定";
    });
    snailFisDbContext.SaveChanges();
}

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
