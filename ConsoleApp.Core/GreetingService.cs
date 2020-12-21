using ConsoleApp.Core.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Threading.Tasks;

// DI, Serilog, Settings

namespace ConsoleApp.Core
{
    partial class Program
    {
        public class GreetingService : IGreetingService
        {
            private readonly ILogger<GreetingService> _log;
            private readonly IConfiguration _config;
            private readonly IDapper _dapper;

            public GreetingService(ILogger<GreetingService> log, IConfiguration config, IDapper dapper)
            {
                _log = log;
                _config = config;
                _dapper = dapper;
            }
            public async Task<bool> RunAsync()
            {
                //for (int i = 0; i < _config.GetValue<int>("LoopTimes"); i++)
                //{
                //    _log.LogInformation("Run Number {runNumber}", i);
                //}
                try
                {
                    var result = await Task.FromResult(_dapper.Get<Greeting>($"SELECT * FROM [Greetings] WHERE Id = 1", null, commandType: CommandType.Text));
                }
                catch (Exception ex)
                {
                    _log.LogInformation("An error has occured", ex.Message);
                    throw ex;
                }
                return true;
            }
        }
    }
}
