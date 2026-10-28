using Microsoft.AspNetCore.DataProtection;
using Takyon.Content.Interfaces;
using Takyon.Content.Mock;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure DataProtection to store keys in local project folder
var keysFolder = Path.Combine(builder.Environment.ContentRootPath, "obj", "DataProtection-Keys");
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keysFolder));

// Register the mock content provider for Phase 1/Phase 2
builder.Services.AddSingleton<ITakyonContentProvider, MockTakyonContentProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
