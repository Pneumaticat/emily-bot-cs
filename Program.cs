using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Commands.Permissions.Levels;
using Discord.Modules;
using Discord.Audio;
using emily.Enums;
using emily.Modules.Basic_Commands;
using emily.Modules.memes;
using emily.Modules.summon;
using emily.Modules.admin;
namespace emily_bot_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        public static DiscordClient _client;
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

            _client.UsingModules();
            _client.UsingPermissionLevels((u, c) => (int)GetPermissions(u, c));

            _client.AddModule<BasicCommands>("Standard", ModuleFilter.None);
            _client.AddModule<Memes>("Standard", ModuleFilter.None);
            _client.AddModule<Summon>("Standard", ModuleFilter.None);

            _logOn = new logOn();
            _logOn.LogOnDiscord();
        }

        private static PermissionLevel GetPermissions(User u, Channel c)
        {
            if (u.Id == 8670)
                return PermissionLevel.BotOwner;

            if (!c.IsPrivate)
            {
                if (u == c.Server.Owner)
                    return PermissionLevel.ServerOwner;

                var serverPerms = u.ServerPermissions;
                if (serverPerms.ManageRoles || u.Roles.Select(x => x.Name.ToLower()).Contains("Emily Admin"))
                    return PermissionLevel.ServerAdmin;
                if (serverPerms.ManageMessages && serverPerms.KickMembers && serverPerms.BanMembers)
                    return PermissionLevel.ServerModerator;

                var channelPerms = u.GetPermissions(c);
                if (channelPerms.ManagePermissions)
                    return PermissionLevel.ChannelAdmin;
                if (channelPerms.ManageMessages)
                    return PermissionLevel.ChannelModerator;
            }
            return PermissionLevel.User;
        }


        public void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine($"[{e.Severity}] [{e.Source}] [{e.Message}]");
        }

    }
}
