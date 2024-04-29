namespace LanguageResource
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using LanguageResource.Modal;
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=IShopDBContext")
        {
        }

        public virtual DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
