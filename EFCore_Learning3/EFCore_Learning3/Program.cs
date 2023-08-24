using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class ECommerceDbContext : DbContext
{
    private object optionsBuilder;

    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ECommerceDb;TrustServerCertificate=True;Encrypt=False;Trusted_Connection=True;Trusted_Connection=True");
    }
    
   }

//Entity 

public class Product
{

    public  int Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public float Price { get; set; }

    

}

//Entity 

public class Customer
{

    public int Id { get; set; }

    public string  FirstName { get; set; }

    public int LastName { get; set; }

}




