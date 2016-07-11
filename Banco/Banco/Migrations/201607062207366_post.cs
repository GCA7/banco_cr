namespace Banco.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coment", "Image_id1", "dbo.Image");
            DropForeignKey("dbo.Image", "Image2_id", "dbo.Image");
            DropForeignKey("dbo.Post", "Image_id1", "dbo.Image");
            DropForeignKey("dbo.Post", "Coment_id1", "dbo.Coment");
            DropIndex("dbo.Coment", new[] { "Image_id1" });
            DropIndex("dbo.Image", new[] { "Image2_id" });
            DropIndex("dbo.Post", new[] { "Coment_id1" });
            DropIndex("dbo.Post", new[] { "Image_id1" });
            DropColumn("dbo.Post", "id_comment");
            RenameColumn(table: "dbo.Post", name: "Coment_id1", newName: "id_comment");
            DropPrimaryKey("dbo.Coment");
            AddColumn("dbo.Coment", "id_comment", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Post", "image", c => c.String());
            AddColumn("dbo.Post", "likes", c => c.Int());
            AlterColumn("dbo.Post", "id_comment", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Coment", "id_comment");
            CreateIndex("dbo.Post", "id_comment");
            AddForeignKey("dbo.Post", "id_comment", "dbo.Coment", "id_comment", cascadeDelete: true);
            DropColumn("dbo.Coment", "id");
            DropColumn("dbo.Coment", "Image_id");
            DropColumn("dbo.Coment", "Image_id1");
            DropColumn("dbo.Post", "Image_id");
            DropColumn("dbo.Post", "Coment_id");
            DropColumn("dbo.Post", "Image_id1");
            DropTable("dbo.Image");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_image = c.Int(nullable: false),
                        imagen_id = c.Int(),
                        image_path = c.String(),
                        Image2_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Post", "Image_id1", c => c.Int());
            AddColumn("dbo.Post", "Coment_id", c => c.Int());
            AddColumn("dbo.Post", "Image_id", c => c.Int());
            AddColumn("dbo.Coment", "Image_id1", c => c.Int());
            AddColumn("dbo.Coment", "Image_id", c => c.Int());
            AddColumn("dbo.Coment", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Post", "id_comment", "dbo.Coment");
            DropIndex("dbo.Post", new[] { "id_comment" });
            DropPrimaryKey("dbo.Coment");
            AlterColumn("dbo.Post", "id_comment", c => c.Int());
            DropColumn("dbo.Post", "likes");
            DropColumn("dbo.Post", "image");
            DropColumn("dbo.Coment", "id_comment");
            AddPrimaryKey("dbo.Coment", "id");
            RenameColumn(table: "dbo.Post", name: "id_comment", newName: "Coment_id1");
            AddColumn("dbo.Post", "id_comment", c => c.Int(nullable: false));
            CreateIndex("dbo.Post", "Image_id1");
            CreateIndex("dbo.Post", "Coment_id1");
            CreateIndex("dbo.Image", "Image2_id");
            CreateIndex("dbo.Coment", "Image_id1");
            AddForeignKey("dbo.Post", "Coment_id1", "dbo.Coment", "id");
            AddForeignKey("dbo.Post", "Image_id1", "dbo.Image", "id");
            AddForeignKey("dbo.Image", "Image2_id", "dbo.Image", "id");
            AddForeignKey("dbo.Coment", "Image_id1", "dbo.Image", "id");
        }
    }
}
