﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Events;
using Version = System.Version;
using System.Reflection;

namespace AutoBot
{
    class Program
    {
        public static string Author = "devAkumetsu";
        public static string AddonName = "AutoBot";
        public static Menu Config;
        public static Random Rnd = new Random(Environment.TickCount);

        static void Main(string[] args)
        {          
          
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {

            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string scriptVersion = v.Major + "." + v.MajorRevision + "." + v.Minor + "." + v.MinorRevision;
            // version of addon
            Chat.Print(AddonName + " made by " + Author + " loaded!");            
            Chat.Print("Version Loaded" + scriptVersion); 

            // menu AutoBot
            Config = MainMenu.AddMenu("Auto Bot", "AutoBot");
            Config.Add("activeab", new CheckBox("Active the AutoBot?"));
            Config.Add("hacksab", new CheckBox("Active Texture? (f5 to load)"), false);
            Config.Add("chattingab", new CheckBox("Active Chatting BOT?"), false);

            Game.OnUpdate += On_Update;

        }

        private static void On_Update(EventArgs args)
        {
            // check if we need to active the addon ifself
            if (!Config["activeab"].Cast<CheckBox>().CurrentValue)
                return;

            // Setup hacks texture for BOTTING
            if (!Config["hacksab"].Cast<CheckBox>().CurrentValue)
                Hacks.Init();

            // Setup Chatting BOT
            if (!Config["chattingab"].Cast<CheckBox>().CurrentValue)
                Chatting.Init();
                      
        }      
        
    }
}
