var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// �������: 
// ����������� CRUD-�������� ��� ��������� ��������
// ������� DAO-��������� �������, � ��� �������������
// ������������ ������� ������������*
// ������� ������� ����������� � �������������� ������ CRUD-�


app.MapGet("/", () => "Hello World!");

app.Run();
