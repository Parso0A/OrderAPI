using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddOptions();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterValidators();
builder.Services.RegisterDependencies();
builder.Services.ApplyPendingMigrations();

var app = builder.Build();

app.UseExceptionHandler(opts => opts.Run(async context =>
{
    var pathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    var exception = pathFeature.Error;

    await context.Response.WriteAsync(exception.Message);
}));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/producttypes", async (IProductTypeService service, CancellationToken cancellationToken) =>
{
    return Results.Ok(await service.GetAllAsync(cancellationToken));
})
.WithName("GetProductTypesAsync");

app.MapPost("/order", async (IOrderService service, CreateOrderRequest request, CancellationToken cancellationToken) =>
{
    var result = await service.CreateAsync(request, cancellationToken);

    if (result.Equals(Guid.Empty))
    {
        return Results.BadRequest();
    }

    return Results.Ok(result);
})
.WithName("CreateOrderAsync");

app.MapGet("/order/{id}", async (IOrderService service, Guid id, CancellationToken cancellationToken) =>
{
    if (id.Equals(Guid.Empty))
    {
        return Results.BadRequest();
    }

    var response = await service.GetByIdAsync(id, cancellationToken);

    if(response is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(response);
})
.WithName("GetOrderById");

app.Run();