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

namespace emily.Modules.memes
{
    class Memes : IModule
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

                Random rand;
                rand = new Random();

                string[] memes;

                memes = new string[]
                {
                    @"Modules\Memes\memeImages\meme1.jpg",
                    @"Modules\Memes\memeImages\meme2.jpg",
                    @"Modules\Memes\memeImages\meme3.jpg"

                };

                #region ~meme
                cgb.CreateCommand("meme")
                .MinPermissions((int)PermissionLevel.User)
                .Description("Posts the dankest of memes!")
                .Do(async e =>
                {
                    int randomFile = rand.Next(memes.Length);
                    string fileToSend = memes[randomFile];
                    await e.Channel.SendFile(fileToSend);
                });
                #endregion

            });
        }
    }
}
