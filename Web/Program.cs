#region Configure the web server host and services.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(); // add support for Razor Pages

#endregion 

#region Configure the HTTP request pipeline.

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts(); // stops the web server if the certificate is not valid
}

app.UseHttpsRedirection(); // redirect http to https

app.UseDefaultFiles(); // index.html, default.html, etc
app.UseStaticFiles();

app.MapRazorPages(); // map Razor Pages

app.MapGet("/hello", () => "Hello World!");

app.Run();

#endregion

Console.WriteLine("This executes after the web server has stopped");