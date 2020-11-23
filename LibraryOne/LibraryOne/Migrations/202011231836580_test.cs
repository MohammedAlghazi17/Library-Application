namespace LibraryOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
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
            DropForeignKey("dbo.Books", "Publisher_PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
            DropIndex("dbo.Books", new[] { "Publisher_PublisherId" });
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Publishers");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
