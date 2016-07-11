namespace Banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coment", "id_post", "dbo.Post");
            DropPrimaryKey("dbo.Coment");
            DropPrimaryKey("dbo.Post");
            AlterColumn("dbo.Coment", "id_comment", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Post", "id_post", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Coment", "id_comment");
            AddPrimaryKey("dbo.Post", "id_post");
            AddForeignKey("dbo.Coment", "id_post", "dbo.Post", "id_post", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coment", "id_post", "dbo.Post");
            DropPrimaryKey("dbo.Post");
            DropPrimaryKey("dbo.Coment");
            AlterColumn("dbo.Post", "id_post", c => c.Int(nullable: false));
            AlterColumn("dbo.Coment", "id_comment", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Post", "id_post");
            AddPrimaryKey("dbo.Coment", "id_comment");
            AddForeignKey("dbo.Coment", "id_post", "dbo.Post", "id_post", cascadeDelete: true);
        }
    }
}
