namespace LibraryOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmptyMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books");
            RenameColumn(table: "dbo.BookAuthors", name: "Book_BookId", newName: "Book_Id");
            RenameColumn(table: "dbo.BookAuthors", name: "Author_AuthorId", newName: "Author_Id");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Book_BookId", newName: "IX_Book_Id");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Author_AuthorId", newName: "IX_Author_Id");
            DropPrimaryKey("dbo.Authors");
            DropPrimaryKey("dbo.Books");
            AddColumn("dbo.Authors", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Authors", "FirstName", c => c.String());
            AddColumn("dbo.Authors", "LastName", c => c.String());
            AddColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Books", "Title", c => c.String());
            AddColumn("dbo.Books", "Publisher", c => c.String());
            AddColumn("dbo.Books", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "CopiesSold", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Books", "Id");
            AddForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            DropColumn("dbo.Authors", "AuthorId");
            DropColumn("dbo.Authors", "Name");
            DropColumn("dbo.Authors", "Age");
            DropColumn("dbo.Books", "BookId");
            DropColumn("dbo.Books", "Name");
            DropColumn("dbo.Books", "ISBN");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ISBN", c => c.String());
            AddColumn("dbo.Books", "Name", c => c.String());
            AddColumn("dbo.Books", "BookId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Authors", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "Name", c => c.String());
            AddColumn("dbo.Authors", "AuthorId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Authors");
            DropColumn("dbo.Books", "CopiesSold");
            DropColumn("dbo.Books", "Rating");
            DropColumn("dbo.Books", "Publisher");
            DropColumn("dbo.Books", "Title");
            DropColumn("dbo.Books", "Id");
            DropColumn("dbo.Authors", "LastName");
            DropColumn("dbo.Authors", "FirstName");
            DropColumn("dbo.Authors", "Id");
            AddPrimaryKey("dbo.Books", "BookId");
            AddPrimaryKey("dbo.Authors", "AuthorId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Author_Id", newName: "IX_Author_AuthorId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Book_Id", newName: "IX_Book_BookId");
            RenameColumn(table: "dbo.BookAuthors", name: "Author_Id", newName: "Author_AuthorId");
            RenameColumn(table: "dbo.BookAuthors", name: "Book_Id", newName: "Book_BookId");
            AddForeignKey("dbo.BookAuthors", "Book_BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Author_AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
        }
    }
}
