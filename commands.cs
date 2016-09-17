using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Commands.Permissions.Levels;

namespace emily_bot_cs
{
    class commands
    {
        public void CreateCommands()
        {
            var _commands = Program._client.GetService<CommandService>();

            #region ~ping
            _commands.CreateCommand("ping")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("pong!");
                });
            #endregion
        }
    }
}
