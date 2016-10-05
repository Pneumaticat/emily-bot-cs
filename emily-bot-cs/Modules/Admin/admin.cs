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

namespace emily.Modules.admin
{
    class admin : IModule
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

                #region ~kick
                cgb.CreateCommand("kick")
                    .Description("Kicks requested user off the server")
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
                cgb.CreateCommand("ban")
                    .Description("Bans requested user")
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

                        await e.Channel.SendMessage($":clap: :100: {mentionedUser}");
                        await e.Server.Ban(m);
                    });
                #endregion

                #region ~mute
                cgb.CreateCommand("mute")
                    .Description("Mutes requested use")
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

                        await e.Channel.SendMessage($":zip: {mentionedUser}");
                        await m.Edit(isMuted: true);
                    });
                #endregion

                #region ~unmute
                cgb.CreateCommand("unmute")
                    .Description("Unmute a user")
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

                        await e.Channel.SendMessage($":unlock: {mentionedUser}");
                        await m.Edit(isMuted: false);
                    });
                #endregion

                #region ~deafen
                cgb.CreateCommand("deafen")
                    .Description("Deafen requested user")
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

                        await e.Channel.SendMessage($":hear_no_evil: {mentionedUser}");
                        await m.Edit(isDeafened: true);
                    });
                #endregion

                #region ~undeafen
                cgb.CreateCommand("undeafen")
                    .Description("Undeafen requested user")
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

                        await e.Channel.SendMessage($":unlock: {mentionedUser}");
                        await m.Edit(isDeafened: false);
                    });
                #endregion

                #region ~prune
                cgb.CreateCommand("Purge")
                .MinPermissions((int)PermissionLevel.ServerAdmin)
                .Description("Deletes the last 100 messages")
                .Do(async e =>
                {
                    Message[] messagesToDelete;
                    messagesToDelete = await e.Channel.DownloadMessages(100);
                    await e.Channel.DeleteMessages(messagesToDelete);
                #endregion

                });
            });
        }
    }
}
