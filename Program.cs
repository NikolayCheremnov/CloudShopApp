using CloudShopApp.Model;
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


// �����
app.MapGet("/", () => "pong");
app.MapGet("/ping", () => "pong");


// ������� ����������� ��� ������������ CRUD-��������
app.MapGet("/all", async (HttpContext context, IOrderService service) =>
{
    await context.Response.WriteAsJsonAsync(service.GetAllOrders());  
});

// ������ CRUD-��������

app.Run();
