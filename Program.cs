using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Modules;
using Discord.Audio;

namespace emily_bot_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        private DiscordClient _client;

        public void Start()
        {
            _client = new DiscordClient(x =>
            {
                x.AppName = "Emily Bot";
                x.AppUrl = "http://nitroignika.github.io";
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            _client.UsingCommands(x =>
            {
                x.PrefixChar = '~';
                x.AllowMentionPrefix = true;
            });

            var token = "MjE4OTE5ODU5NDgyNzg3ODQw.Cr4uUQ.Fla_aKtnW7YDtP_QyXGsBxdGZWw";

            _client.ExecuteAndWait(async () => 
            {
                await _client.Connect(token);
            });
        }



        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] [{e.Message}]");
        }

    }
}
