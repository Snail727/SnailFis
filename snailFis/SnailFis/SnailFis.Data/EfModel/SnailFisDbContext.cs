namespace SnailFis.Data.EfModel
{
    using SnailFis.Data.Models.BaseData;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SnailFisDbContext : DbContext
    {
        public SnailFisDbContext() : base("name=SnailFis")
        {
            //解决团队开发中，多人迁移数据库造成的修改覆盖问题。
            Database.SetInitializer<SnailFisDbContext>(null);
        }

        public virtual DbSet<DicDbModel> DicList { get; set; }
    }
}