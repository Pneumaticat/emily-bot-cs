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

        public static DiscordClient _client;
        public static commands _commands;
        public static logOn _logOn;

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
                x.HelpMode = HelpMode.Public;
            });

            _commands = new commands();
            _commands.CreateCommands();

            _logOn = new logOn();
            _logOn.LogOnDiscord();
        }

        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] [{e.Message}]");
        }

    }
}
