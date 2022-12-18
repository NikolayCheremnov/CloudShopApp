using CloudShopApp.Model;
using CloudShopApp.Model.Entity;
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
// + зафиксировать изменения в ветке dev и запушить на сервер


// пинги
app.MapGet("/", () => "pong");
app.MapGet("/ping", () => "pong from Nikolay");
app.MapGet("/status", () => "Server is running");


// простые контроллеры для тестирования CRUD-операций
app.MapGet("/all", async (HttpContext context, IOrderService service) =>
{
    await context.Response.WriteAsJsonAsync(service.GetAllOrders());  
});


app.MapPost("/add", async (HttpContext context, IOrderService service) =>
{
    Order order = new Order();
    order.FeedbackContact = context.Request.Form["feedbackContact"];
    order.Description = context.Request.Form["description"];
    Order newOrder = service.AddOrder(order);
    await context.Response.WriteAsJsonAsync(newOrder);
});


// пример передачи параметров dataStr - строка, dataInt - число

// способ 1 - параметры строки запроса (get)
app.MapGet("/param-test", async (context) =>
{
    string dataStr = context.Request.Query["dataStr"];
    int dataInt = Convert.ToInt32(context.Request.Query["dataInt"]);
    Console.WriteLine($"Получены параметры: {dataStr} - {dataInt}");
    await context.Response.WriteAsync($"Получены параметры: {dataStr} - {dataInt}"); 
});

// способ 2 - параметры в теле запроса (post)
app.MapPost("/post-param-test", async (context) =>
{
    string dataStr = context.Request.Form["dataStr"];
    int dataInt = Convert.ToInt32(context.Request.Form["dataInt"]);
    Console.WriteLine($"Получены параметры: {dataStr} - {dataInt}");
    await context.Response.WriteAsync($"Получены параметры: {dataStr} - {dataInt}");
});

// способ 3 - JSON-объект (сериализованный в теле объект)
app.MapPost("/object-param-test", async (context) =>
{
    Order order = await context.Request.ReadFromJsonAsync<Order>();
    Console.WriteLine($"были получены данные: {order}");
    await context.Response.WriteAsJsonAsync(order);
});

// ПРОЧИЕ CRUD-операции

app.Run();
