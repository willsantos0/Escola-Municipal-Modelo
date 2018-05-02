namespace EscolaMunicipalAPI.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CPF = c.String(nullable: false, maxLength: 15),
                        NomeAluno = c.String(nullable: false, maxLength: 255),
                        DataNascimento = c.DateTime(nullable: false),
                        NomeMae = c.String(nullable: false, maxLength: 255),
                        Endereco = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aluno");
        }
    }
}
