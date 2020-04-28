﻿using LeagueBot.Api;
using LeagueBot.IO;
using NLua;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeagueBot.Patterns
{
    public class PatternScript
    {
        public string Filename
        {
            get;
            set;
        }
        private string Description
        {
            get;
            set;
        }
        private Lua Lua
        {
            get;
            set;
        }
        public PatternScript(string fileName, Lua lua)
        {
            this.Filename = fileName;

            lua["bot"] = new BotApi();
            lua["client"] = new ClientApi();
            lua["game"] = new GameApi();

            this.Description = lua.GetString("Description");
            this.Lua = lua;
        }

        public void Execute()
        {
            Logger.Write("Running " + Filename);
            LuaFunction functionMain = Lua.GetFunction("Execute");
            functionMain.Call();
        }
        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(Filename) + " \"" + Description + "\"";
        }
    }
}
