﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Events;
using System.Reflection;

namespace AutoBot
{
    class Hacks
    {
      
     
        public static void Init()
        {

            Hacks.DisableTextures = true;
            Hacks.AntiAFK = true;
            Hacks.RenderWatermark = false;

            ManagedTexture.OnLoad += ManagedTexture_OnLoad;
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            

        }

        private static void ManagedTexture_OnLoad(OnLoadTextureEventArgs args)
        {

            args.Process = false;
        }
    }
}
