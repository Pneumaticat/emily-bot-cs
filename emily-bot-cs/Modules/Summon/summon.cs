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

                Random rand;
                rand = new Random();

                //Kittens
                string[] kittens;
                kittens = new string[]
                {
                    @"Modules\Summon\kittenImages\kitten1.jpg",
                    @"Modules\Summon\kittenImages\kitten2.jpg",
                    @"Modules\Summon\kittenImages\kitten3.jpg"
                };

                //Puppies
                string[] puppies;
                puppies = new string[]
                {
                    @"Modules\Summon\puppyImages\puppy1.jgp",
                    @"Modules\Summon\puppyImages\puppy2.jgp",
                    @"Modules\Summon\puppyImages\puppy3.jgp"
                };

                #region ~summon
                cgb.CreateCommand("summon")
                .MinPermissions((int)PermissionLevel.User)
                .Description("Summons a requested creature")
                .Parameter("RequestedCreature", ParameterType.Required)
                .Do(async e =>
                {

                    string creature = e.Args[0];

                    if(creature == "doge")
                    {
                        await e.Channel.SendFile(@"Modules\Summon\dogeImages\doge.png");
                        await e.Channel.SendMessage("Summoned a doge!");
                    }
                    if(creature == "puppy")
                    {
                        int randomFilePuppy = rand.Next(puppies.Length);
                        string puppyToSummon = puppies[randomFilePuppy];

                        await e.Channel.SendFile(puppyToSummon);
                        await e.Channel.SendMessage("Summoned a puppy!");
                    }
                    if(creature == "kitten")
                    {
                        int randomFileKitten = rand.Next(puppies.Length);
                        string kittenToSummon = kittens[randomFileKitten];

                        await e.Channel.SendFile(kittenToSummon);
                        await e.Channel.SendMessage("Summoned a kitten!");
                    }
                    if(creature == "pepe")
                    {
                        await e.Channel.SendFile(@"Modules\Summon\pepeImages\pepe.png");
                        await e.Channel.SendMessage("Summoned a pepe!");
                    }

                });
                #endregion

            });
        }
    }
}
