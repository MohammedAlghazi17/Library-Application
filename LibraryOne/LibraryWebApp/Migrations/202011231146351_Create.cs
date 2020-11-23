namespace LibraryWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            RenameColumn(table: "dbo.BookAuthors", name: "Book_Id", newName: "Book_BookId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Book_Id", newName: "IX_Book_BookId");
            DropPrimaryKey("dbo.Books");
            DropColumn("dbo.Books", "Id");
            AddColumn("dbo.Books", "BookId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "BookId");
            AddForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books", "BookId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books");
            DropPrimaryKey("dbo.Books");
            DropColumn("dbo.Books", "BookId");
            AddPrimaryKey("dbo.Books", "Id");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Book_BookId", newName: "IX_Book_Id");
            RenameColumn(table: "dbo.BookAuthors", name: "Book_BookId", newName: "Book_Id");
            AddForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
