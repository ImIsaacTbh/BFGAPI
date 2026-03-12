using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;

namespace bfgshit
{
    //scope = https://www.googleapis.com/auth/spreadsheets.readonly
    public class api
    {
        public static SheetsService service = new SheetsService(new BaseClientService.Initializer()
        {
            ApiKey = File.ReadAllText(@"c:\key.txt"),
            ApplicationName = "BFG26"
        });

        public static void Main(String[] args)
        {
            Thread t = new Thread(() =>
            {
                var req = service.Spreadsheets.Values.Get("1GcXlpKxmSDN0DMDKpxXFI4UmshLNoxuo0X8Tu7KywJk", "API!B2:B3").Execute();
                //var output = req.Values.First().First().ToString();
                for (int i = 0; i < req.Values.Count; i++)
                {
                    Console.WriteLine("Team: " + req.Values.ElementAt(i).First().ToString());
                }
                var dataAsJson = JsonConvert.SerializeObject(req.Values);
            });

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("OverlayPolicy", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("OverlayPolicy");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}