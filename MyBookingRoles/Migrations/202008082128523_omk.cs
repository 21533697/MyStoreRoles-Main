namespace MyBookingRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class omk : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderDetails", name: "Product_ProductID", newName: "Prod_ProductID");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_Product_ProductID", newName: "IX_Prod_ProductID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderDetails", name: "IX_Prod_ProductID", newName: "IX_Product_ProductID");
            RenameColumn(table: "dbo.OrderDetails", name: "Prod_ProductID", newName: "Product_ProductID");
        }
    }
}
