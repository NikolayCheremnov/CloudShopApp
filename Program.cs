using CloudShopApp.Model;
using CloudShopApp.Service;

var builder = WebApplication.CreateBuilder(args);

// добавляем контекст БД в контейнер
builder.Services.AddDbContext<CloudShopDbContext>();

// сервисы
builder.Services.AddTransient<IOrderService, DbOrderService>(); 

var app = builder.Build();


// ЗАДАНИЕ: 
// Реализовать CRUD-операции для созданной сущности
// Сделать DAO-интерфейс сервиса, и его имплементацию
// Использовать инъекцию зависимостей*
// Сделать простые контроллеры и протестировать методы CRUD-а


// пинги
app.MapGet("/", () => "pong");
app.MapGet("/ping", () => "pong");


// простые контроллеры для тестирования CRUD-операций
app.MapGet("/all", async (HttpContext context, IOrderService service) =>
{
    await context.Response.WriteAsJsonAsync(service.GetAllOrders());  
});

// ПРОЧИЕ CRUD-операции

app.Run();
