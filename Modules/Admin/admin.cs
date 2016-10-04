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
                cgb.PublicOnly();

                #region ~kick
                cgb.CreateCommand("kick")
                    .Description("Kicks requested user")
                    .Parameter("user")
                    .MinPermissions((int)PermissionLevel.ServerAdmin)
                    .Do(async e =>
                    {
                        ulong id;                                           
                        User m = null;                                      
                        string mentionedUser = e.Args[0];                       
                        if (!string.IsNullOrWhiteSpace(mentionedUser))           
                        {
                            if (e.Message.MentionedUsers.Count() == 1)     
                                m = e.Message.MentionedUsers.FirstOrDefault();
                            else if (e.Server.FindUsers(mentionedUser).Any())   
                                m = e.Server.FindUsers(mentionedUser).FirstOrDefault();
                            else if (ulong.TryParse(mentionedUser, out id))      
                                m = e.Server.GetUser(id);
                        }

                        if (m == null)                                      
                        {
                            await e.Channel.SendMessage($"The user `{mentionedUser}` was not found! ");
                            return;
                        }
                        
                        await e.Channel.SendMessage($":wave: {mentionedUser}");
                        await m.Kick();
                    });
                #endregion
                
                #region ~ban
                #endregion

                #region ~mute
                #endregion

                #region ~unmute
                #endregion

                #region ~defean
                #endregion

                #region ~cleanupmsg
                #endregion

            });
        }
    }
}
