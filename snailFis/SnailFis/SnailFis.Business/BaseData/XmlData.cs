using SnailFis.Business.Common;
using SnailFis.Data.Dals.BaseData;
using SnailFis.Model.BusinessModels.XmlData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnailFis.Business.BaseData
{
    /// <summary>
    /// Xml逻辑层
    /// </summary>
    public class XmlData : BaseBusiness
    {
        XmlDal _dal;
        public XmlData(int sfId, int userSn) : base(sfId, userSn)
        {
            _dal = new XmlDal(SfId, UserSn);
        }

        public List<BankModel> GetBankList()
        {
            return _dal.GetBankList();
        }
    }
}
