#region Configure the web server host and services.

using DataContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(); // add support for Razor Pages
builder.Services.AddNorthwindContext();

#endregion 

#region Configure the HTTP request pipeline.

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts(); // stops the web server if the certificate is not valid
}

app.Use(async (HttpContext context, Func<Task> next) =>
{
    RouteEndpoint? rep = context.GetEndpoint() as RouteEndpoint;

    if (rep is not null)
    {
        Console.WriteLine($"Endpoint Name: {rep.DisplayName}");
        Console.WriteLine($"Endpoint route pattern: {rep.RoutePattern.RawText}"); 
    }

    if (context.Request.Path == "/bonjour")
    {
        await context.Response.WriteAsync("Bonjour Monde!");
        return;
    }

    // could modify the request before calling the next delegate
    await next();
    // could modify the response after calling the next delegate
});

app.UseHttpsRedirection(); // redirect http to https

app.UseDefaultFiles(); // index.html, default.html, etc
app.UseStaticFiles();

app.MapRazorPages(); // map Razor Pages

app.MapGet("/hello", () => "Hello World!");

app.Run();

#endregion

Console.WriteLine("This executes after the web server has stopped");