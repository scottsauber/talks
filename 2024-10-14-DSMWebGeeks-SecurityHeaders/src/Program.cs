using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();
app.Use(async (context, next) =>
{
    // context.Response.Headers.Add("x-frame-options", "DENY");
    
    // context.Response.Headers.Add("content-security-policy", "script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline'; img-src 'self' www.google.com; media-src 'none'");
    // context.Response.Headers.Add("content-security-policy-report-only", "script-src 'self'; style-src 'none'; img-src 'self' www.google.com; media-src 'none'");
    
    // context.Response.Headers.Add("feature-policy", "camera 'none'");

    await next();
});
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapRazorPages();
app.Run();