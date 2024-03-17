# .NET | Domain-Driven Design(DDD) | CRUD


### Environment
- .NET 6.0
- MSSQL
    - Create a new database: **DDDCRUD**
    - Create a new table **Users** with _dbo.Users.sql_.


### 💡 CORS

Focus on _.\dotNetCRUDApplication\Program.cs_ line: 26
```
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
```

Or run a new browser with this command:
```
C:\Program Files\Google\Chrome\Application>chrome.exe --disable-web-security --user-data-dir="C:\tmpChromeSession
```
