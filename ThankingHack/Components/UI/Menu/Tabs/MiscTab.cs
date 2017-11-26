﻿using SDG.Unturned;
using System;
using Thanking.Options;
using Thanking.Threads;
using UnityEngine;

namespace Thanking.Components.UI.Menu.Tabs
{
    public static class MiscTab
    {
        public static void Tab()
        {
            Prefab.MenuArea(new Rect(0, 0, 466, 436), "MISC", () =>
            {
                Prefab.Toggle("Vehicle Flight", ref MiscOptions.VehicleFly);
                GUILayout.Space(2);
                GUILayout.Label("Speed Multiplier: " + MiscOptions.SpeedMultiplier + "x", Prefab._TextStyle);
                GUILayout.Space(2);
                MiscOptions.SpeedMultiplier = (float)Math.Round(Prefab.Slider(0, 10, MiscOptions.SpeedMultiplier, 175), 2);

				GUILayout.Space(4);
				GUILayout.Label("Salvage Time", Prefab._TextStyle);
				GUILayout.Space(2);
				MiscOptions.SalvageTime = (float)Math.Round(Prefab.Slider(0, 10, MiscOptions.SalvageTime, 175));

				GUILayout.Space(4);
				Prefab.Toggle("Set Time", ref MiscOptions.SetTimeEnabled);
				GUILayout.Space(2);
				GUILayout.Label("Time of Day", Prefab._TextStyle);
				GUILayout.Space(2);
				MiscOptions.Time = (uint)Math.Round(Prefab.Slider(0, 1800, MiscOptions.Time, 175));

				GUILayout.Space(4);
				Prefab.Toggle("Freecam", ref Player.player.look.isOrbiting);

				GUILayout.Space(4);
				Prefab.Toggle("Crasher", ref CrashThread.CrashServerEnabled);

				Prefab.MenuArea(new Rect(10, 436 - 135 - 10, 220, 135), "SPAMMER", () =>
                {
                    Prefab.Toggle("Enabled", ref MiscOptions.SpammerEnabled);
                    GUILayout.Space(5);
                    MiscOptions.SpamText = Prefab.TextField(MiscOptions.SpamText, "Text: ", 150);
                    GUILayout.Space(10);
                    GUILayout.Label("Delay: " + MiscOptions.SpammerDelay + "ms", Prefab._TextStyle);
                    GUILayout.Space(5);
                    MiscOptions.SpammerDelay = (int)Prefab.Slider(0, 3000, MiscOptions.SpammerDelay, 175);
                });
                Prefab.MenuArea(new Rect(220 + 10 + 5, 436 - 135 - 10, 221, 135), "INTERACT", () =>
                {
                    Prefab.Toggle("Interact Through Walls", ref InteractionOptions.InteractThroughWalls);
                    Prefab.Toggle("Hit Structures", ref InteractionOptions.HitStructures);
                    Prefab.Toggle("Hit Barricades", ref InteractionOptions.HitBarricades);
                    Prefab.Toggle("Hit Items", ref InteractionOptions.HitItems);
                    Prefab.Toggle("Hit Vehicles", ref InteractionOptions.HitVehicles);
                    Prefab.Toggle("Hit Resources", ref InteractionOptions.HitResources);
                });
            });
        }
    }
}