using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Modules;
using Discord.Commands;
using Discord.Commands.Permissions.Levels;
using emily.Enums;

namespace emily.Modules.summon
{
    class Summon : IModule
    {
        private DiscordClient _client;
        private ModuleManager _manager;

        void IModule.Install(ModuleManager manager)
        {
            _manager = manager;
            _client = manager.Client;

            manager.CreateCommands("", cgb =>
            {
                cgb.MinPermissions((int)PermissionLevel.User);
                
                //STILL IN PROGRESS

                #region ~summon doge
                cgb.CreateCommand("summon")
                .MinPermissions((int)PermissionLevel.User)
                .Alias(new string[] {"sm"})
                .Description("Summons a requested creature")
                .Parameter("RequestedCreature", ParameterType.Required)
                .Do(async e =>
                {
                    await e.Channel.SendMessage($"Summoned a {e.GetArg("RequestedCreature")}");
                });
                #endregion

            });
        }
    }
}
