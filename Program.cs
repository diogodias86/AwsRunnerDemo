var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(
        name: "DefaultCors",
        policy =>
        {
            policy
                .WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
   );
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("DefaultCors");

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/api/health", () =>
{
    return Results.Ok(
        new
        {
            Ok = true
        });
});

app.Run();
