using BlazorApp1.Components;

var builder = WebApplication.CreateBuilder(args);

var url = "https://vmkispvezksajkwcrgwp.supabase.co";
var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InZta2lzcHZlemtzYWprd2NyZ3dwIiwicm9sZSI6ImFub24iLCJpYXQiOjE3NTg3NTg3NjMsImV4cCI6MjA3NDMzNDc2M30.rSGjo4ZPH_C2aONNVw7harUxe6QI7hppuoSsumJPckA";

var options = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = true
};

var supabase = new Supabase.Client(url, key, options);
await supabase.InitializeAsync();

builder.Services.AddSingleton(supabase);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
