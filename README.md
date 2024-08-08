# Amandus, 20240808:
# Binar Job Connect
# Backend .NET

- First clone this repository by:
git clone "https://github.com/Zaq3287/BinarTestMandiri"
- Make sure you have .NET 8 installed
- Make sure you have Microsoft SQL Server installed, e.g. SQL Server 2014
- Then open the 'BinarTestMandiri.sln' file, here I use Visual Studio 2022.
- Then open Package Manager Console, write 'Update-Database'
- Then just run the program.

- For web api testing, you can use Swagger.
![Screenshot 2024-08-08 143624](https://github.com/user-attachments/assets/27ac1b25-0784-4a53-81a1-0231e1985dd7)

- If you want to check manually, you can use the following url:<br />
  BOOK<br />
  GET -> displays all data books in the list<br />
  http://localhost:{port}/api/Book<br />
  GET -> displays data based on Id<br />
  http://localhost:{port}/api/Book/{id}<br />
  POST -> insert new data into the list<br />
  http://localhost:{port}/api/Book<br />
  PULL -> update data based on Id<br />
  http://localhost:{port}/api/Book<br />
  DELETE -> delete data based on Id<br />
  http://localhost:{port}/api/Book/{id}<br />
  USER<br />
  GET -> displays all data users in the list<br />
  http://localhost:{port}/api/User<br />
  TRANSACTION<br />
  GET -> displays all data transaction in the list<br />
  http://localhost:{port}/api/Transaction<br />
  GET -> displays data based on Id<br />
  http://localhost:{port}/api/Transaction/{id}<br />
  POST -> insert new data into the list<br />
  http://localhost:{port}/api/Transaction<br />
  PULL -> update data based on Id<br />
  http://localhost:{port}/api/Transaction<br />
  DELETE -> delete data based on Id<br />
  http://localhost:{port}/api/Transaction/{id}<br />
  
