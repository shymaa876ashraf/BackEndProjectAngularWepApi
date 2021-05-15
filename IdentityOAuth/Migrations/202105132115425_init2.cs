namespace IdentityOAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductWishLists", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.ProductWishLists", "WishList_ID", "dbo.Whichlists");
            DropIndex("dbo.ProductWishLists", new[] { "Product_ID" });
            DropIndex("dbo.ProductWishLists", new[] { "WishList_ID" });
            RenameColumn(table: "dbo.ProductWishLists", name: "Product_ID", newName: "ProductID");
            RenameColumn(table: "dbo.ProductWishLists", name: "WishList_ID", newName: "wishListID");
            AlterColumn("dbo.ProductWishLists", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductWishLists", "wishListID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductWishLists", "ProductID");
            CreateIndex("dbo.ProductWishLists", "wishListID");
            AddForeignKey("dbo.ProductWishLists", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProductWishLists", "wishListID", "dbo.Whichlists", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductWishLists", "wishListID", "dbo.Whichlists");
            DropForeignKey("dbo.ProductWishLists", "ProductID", "dbo.Products");
            DropIndex("dbo.ProductWishLists", new[] { "wishListID" });
            DropIndex("dbo.ProductWishLists", new[] { "ProductID" });
            AlterColumn("dbo.ProductWishLists", "wishListID", c => c.Int());
            AlterColumn("dbo.ProductWishLists", "ProductID", c => c.Int());
            RenameColumn(table: "dbo.ProductWishLists", name: "wishListID", newName: "WishList_ID");
            RenameColumn(table: "dbo.ProductWishLists", name: "ProductID", newName: "Product_ID");
            CreateIndex("dbo.ProductWishLists", "WishList_ID");
            CreateIndex("dbo.ProductWishLists", "Product_ID");
            AddForeignKey("dbo.ProductWishLists", "WishList_ID", "dbo.Whichlists", "ID");
            AddForeignKey("dbo.ProductWishLists", "Product_ID", "dbo.Products", "ID");
        }
    }
}
