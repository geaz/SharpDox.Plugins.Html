using System;
using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Log;
using Unosquare.Labs.EmbedIO.Modules;

namespace SharpDox.Plugins.Html.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:9196/";
            using (var server = new WebServer(url, new SimpleConsoleLog()))
            {
                server.RegisterModule(new LocalSessionModule());
                server.RegisterModule(new StaticFilesModule("./"));
                server.Module<StaticFilesModule>().UseRamCache = true;
                server.Module<StaticFilesModule>().DefaultExtension = ".html";
                server.RunAsync();

                var browser = new System.Diagnostics.Process()
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true }
                };
                browser.Start();
                Console.ReadKey(true);
            }
        }
    }
}
