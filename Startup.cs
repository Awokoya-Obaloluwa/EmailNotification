using EmailService;

namespace EmailNotification
{
    public class Startup
    {
            public IConfiguration configRoot
            {
                get;
            }
            public Startup(IConfiguration configuration)
            {
                configRoot = configuration;
            }
            public void ConfigureServices(IServiceCollection services)
            {
            var emailConfig = configRoot
                .GetSection("EmailCongirution")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddControllers();

            services.AddScoped<IEmailSender, EmailSender>();
                services.AddRazorPages();
            }
            public void Configure(WebApplication app, IWebHostEnvironment env)
            {
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseAuthorization();
                app.MapRazorPages();
                app.Run();
            }
        
    }
}
