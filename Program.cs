using CloudShopApp.Model;
using CloudShopApp.Model.Entity;
using CloudShopApp.Service;

var builder = WebApplication.CreateBuilder(args);

// ��������� �������� �� � ���������
builder.Services.AddDbContext<CloudShopDbContext>();

// �������
builder.Services.AddTransient<IOrderService, DbOrderService>(); 

var app = builder.Build();


// �������: 
// ����������� CRUD-�������� ��� ��������� ��������
// ������� DAO-��������� �������, � ��� �������������
// ������������ �������� ������������*
// ������� ������� ����������� � �������������� ������ CRUD-�
// + ������������� ��������� � ����� dev � �������� �� ������


// �����
app.MapGet("/", () => "pong");
app.MapGet("/ping", () => "pong from Nikolay");
app.MapGet("/status", () => "Server is running");


// ������� ����������� ��� ������������ CRUD-��������
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


// ������ �������� ���������� dataStr - ������, dataInt - �����

// ������ 1 - ��������� ������ ������� (get)
app.MapGet("/param-test", async (context) =>
{
    string dataStr = context.Request.Query["dataStr"];
    int dataInt = Convert.ToInt32(context.Request.Query["dataInt"]);
    Console.WriteLine($"�������� ���������: {dataStr} - {dataInt}");
    await context.Response.WriteAsync($"�������� ���������: {dataStr} - {dataInt}"); 
});

// ������ 2 - ��������� � ���� ������� (post)
app.MapPost("/post-param-test", async (context) =>
{
    string dataStr = context.Request.Form["dataStr"];
    int dataInt = Convert.ToInt32(context.Request.Form["dataInt"]);
    Console.WriteLine($"�������� ���������: {dataStr} - {dataInt}");
    await context.Response.WriteAsync($"�������� ���������: {dataStr} - {dataInt}");
});

// ������ 3 - JSON-������ (��������������� � ���� ������)
app.MapPost("/object-param-test", async (context) =>
{
    Order order = await context.Request.ReadFromJsonAsync<Order>();
    Console.WriteLine($"���� �������� ������: {order}");
    await context.Response.WriteAsJsonAsync(order);
});

// ������ CRUD-��������

app.Run();
