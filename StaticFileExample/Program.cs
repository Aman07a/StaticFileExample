using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});

var app = builder.Build();

// Works the web root path (myroot)
app.UseStaticFiles();

// Works with "mywebroot"
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "mywebroot"))
});

// C:\StaticFileExample\StaticFileExample
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello\n");
    });
});

app.Run();
