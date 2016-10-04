using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Modules;
using Discord.Commands;
using Discord.Commands.Permissions.Levels;
using Discord.Commands.Permissions.Visibility;
using Discord.Commands.Permissions.Userlist;
using emily.Enums;

namespace emily.Modules.Admin
{
    class Admin : IModule
    {
        private DiscordClient _client;
        private ModuleManager _manager;

        void IModule.Install(ModuleManager manager)
        {
            _manager = manager;
            _client = manager.Client;

            manager.CreateCommands("", cgb =>
            {
                cgb.MinPermissions((int)PermissionLevel.ServerAdmin);

                #region ~kick
                #endregion

                #region ~ban
                #endregion

                #region ~mute
                #endregion

                #region ~unmute
                #region

                #region ~defean
                #endregion

                #region ~cleanupmsg
                #endregion

            });
        }
    }
}
