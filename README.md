# BaiTestAPI

## Mô tả
Project Web API với ASP.NET Core 8, Entity Framework Core 8, Code-first.

## Cách chạy project

1. Clone repo:
   ```bash
   git clone https://github.com/imminhthuan/BaiTest.git


   🔧 2. Công nghệ sử dụng
ASP.NET Core 8 Web API

Entity Framework Core 8 (code-first)

SQL Server LocalDB hoặc SQLite (có thể config trong appsettings.json)

AutoMapper

Swagger (Swashbuckle)


🏁 3. Hướng dẫn chạy project
⚙️ Yêu cầu
Visual Studio 2022 hoặc VS Code

.NET 8 SDK

SQL Server LocalDB (hoặc SQLite)

▶️ Các bước thực hiện

1. Clone project về:
   git clone https://github.com/your-username/your-repo-name.git

2. Mở bằng Visual Studio

3. Cấu hình chuỗi kết nối trong `appsettings.json` nếu cần:
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YourDbName;Integrated Security=True;"
   }

4. Mở Terminal/Package Manager Console:
   dotnet ef database update

5. Chạy project:
   dotnet run
