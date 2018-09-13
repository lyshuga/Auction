CREATE Table tblAuthors
(
   Id int identity primary key,
   Author_name nvarchar(50),
   country nvarchar(50)
)
CREATE Table tblBooks
(
   Id int identity primary key,
   Auhthor_id int foreign key references tblAuthors(Id),
   Price int,
   Edition int
)
go
Declare @Id int
Set @Id = 1

While @Id <= 120000
Begin 
   Insert Into tblAuthors values ('Author - ' + CAST(@Id as nvarchar(10)),
              'Country - ' + CAST(@Id as nvarchar(10)) + ' name')
   Print @Id
   Set @Id = @Id + 1
END

SELECT * FROM dbo.tblAuthors WHERE Author_name = 'Author - 1002'  AND country = 'Country - 1002 name'

SET STATISTICS TIME ON;  

TRUNCATE TABLE dbo.tblAuthors
TRUNCATE TABLE dbo.tblBooks
DROP TABLE dbo.tblBooks
CREATE INDEX FF ON dbo.tblAuthors(Author_name)

 Insert Into tblAuthors values ('Author - 1111111',
              'Country - dsadsad name')