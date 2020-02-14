namespace Financeiro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelasAtualizadas1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movimentacaos", "Tipo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movimentacaos", "Tipo");
        }
    }
}
