namespace EscolaMunicipalAPI.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EscolaMunicipalAPI.Models.Aluno;
    using System.Web.Configuration;
    using System.Configuration;

    public partial class Context : DbContext
    {
        public Context()
            : base("data source=willian\\sqlserver;initial catalog=escolamunicipal;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
    }
}
