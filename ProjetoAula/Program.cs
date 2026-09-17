var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddMvcOptions(
    opcoes_mvc => opcoes_mvc.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((valor_campo, nome_campo) => "Valor inválido")
);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
