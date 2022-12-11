var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// ЗАДАНИЕ: 
// Реализовать CRUD-операции для созданной сущности
// Сделать DAO-интерфейс сервиса, и его имплементацию
// Использовать инекцию зависимостей*
// Сделать простые контроллеры и протестировать методы CRUD-а


app.MapGet("/", () => "Hello World!");

app.Run();
