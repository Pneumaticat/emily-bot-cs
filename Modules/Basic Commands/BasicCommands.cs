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

namespace emily.Modules.Basic_Commands
{
    class BasicCommands : IModule
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

                #region ~say
                cgb.CreateCommand("say")
                .MinPermissions((int)PermissionLevel.ServerAdmin)
                .Description("Make the bot speak!")
                .Parameter("text", ParameterType.Unparsed)
                .Do(async e =>
                {
                    Message[] messagesToDelete;
                    messagesToDelete = await e.Channel.DownloadMessages(1);
                    await e.Channel.DeleteMessages(messagesToDelete);
                    await e.Channel.SendMessage(e.GetArg("text"));
                });
                #endregion

                #region ~ping
                cgb.CreateCommand("ping")
                .MinPermissions((int)PermissionLevel.User)
                .Description("Returns 'Pong!'")
                .Do(async e =>
                {
                    await e.Channel.SendMessage("Pong!");
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
                });
                #endregion

                #region ~greet
                _client.GetService<CommandService>().CreateCommand("greet")
                .MinPermissions((int)PermissionLevel.User)
                .Alias(new string[] { "gr", "sayhi" })
                .Description("Greets a person.")
                .Parameter("GreetedPerson", ParameterType.Required)
                .Do(async e =>
                {
                    await e.Channel.SendMessage($"{e.User.Name} greets {e.GetArg("GreetedPerson")}");
                });
                #endregion

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
            });
        }
    }
}
