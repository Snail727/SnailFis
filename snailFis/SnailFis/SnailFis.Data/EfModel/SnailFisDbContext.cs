namespace SnailFis.Data.EfModel
{
    using SnailFis.Data.Models.BaseData;
    using SnailFis.Data.Models.SysData;
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

        /// <summary>
        /// 用户列表
        /// </summary>
        public virtual DbSet<SysUserDbModel> UserList { get; set; }
        /// <summary>
        /// 蜗居列表
        /// </summary>
        public virtual DbSet<SysSfDbModel> SfList { get; set; }
        /// <summary>
        /// 单位类别列表
        /// </summary>
        public virtual DbSet<UnitTypeDbModel> UnitTypeList { get; set; }
        /// <summary>
        /// 单位列表
        /// </summary>
        public virtual DbSet<UnitValueDbModel> UnitValueList { get; set; }
        /// <summary>
        /// 运动类别列表
        /// </summary>
        public virtual DbSet<SportTypeDbModel> SportTypeList { get; set; }
        /// <summary>
        /// 运动记录列表
        /// </summary>
        public virtual DbSet<SportValueDbModel> SportValueList { get; set; }
    }
}