using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.HttpOverrides;

namespace E_Voting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // load config
            Config.Load();

            // start evaluation thread
            Thread evaluationThread = new Thread(DafnyWrapper.Check);
            evaluationThread.IsBackground = true;
            evaluationThread.Start();

            // start cleaner thread
            Thread cleanerThread = new Thread(Cleaner.Check);
            cleanerThread.IsBackground = true;
            cleanerThread.Start();

            // start reminder thread
            Thread reminderThread = new Thread(Reminder.Check);
            reminderThread.IsBackground = true;
            reminderThread.Start();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor()
            .AddHubOptions(options =>
            {
                options.ClientTimeoutInterval = TimeSpan.FromSeconds(90); // default 30
                options.KeepAliveInterval = TimeSpan.FromSeconds(45);     // default 15
            });


            var app = builder.Build();

            app.UsePathBase("/superior");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            // Enable static files with unknown MIME types
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true
            });

            app.UseAntiforgery();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}