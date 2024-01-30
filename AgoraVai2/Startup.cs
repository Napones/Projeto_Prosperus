using Entidade;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Negocio.Cadastro;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<IndicadoDbSettings>(Configuration.GetSection(nameof(IndicadoDbSettings)));
        services.AddSingleton<Negocio.Cadastro.NegIndicado>();
        services.AddSingleton<IIndicadoDbSettings>(sp => sp.GetRequiredService<IOptions<IndicadoDbSettings>>().Value);

        services.AddControllers();
        IMvcBuilder builder = services.AddRazorPages();

        services.Configure<Microsoft.AspNetCore.Identity.SecurityStampValidatorOptions>(options =>
        {
            // enables immediate logout, after updating the user's stat.
            options.ValidationInterval = TimeSpan.Zero;
        });

        services.AddControllersWithViews();

        #region DI NEGOCIO

        services.AddScoped<NegIndicado>();

        #endregion

        services.Configure<FormOptions>(o =>  // currently all set to max, configure it to your needs!
        {
            o.ValueLengthLimit = int.MaxValue;
            o.MultipartBodyLengthLimit = long.MaxValue; // <-- !!! long.MaxValue
            o.MultipartBoundaryLengthLimit = int.MaxValue;
            o.MultipartHeadersCountLimit = int.MaxValue;
            o.MultipartHeadersLengthLimit = int.MaxValue;
        });
        services.Configure<IISServerOptions>(options =>
        {
            options.MaxRequestBodySize = int.MaxValue;
        });

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(name:"default", pattern:"{controller=Home}/{action=Index}");
        });
    }
}