﻿using System.Reflection;
using SDG.Unturned;
using UnityEngine;
using Thanking.Attributes;
using Thanking.Utilities;
using Thanking.Options;
using Thanking.Variables;
using Thanking.Coroutines;

namespace Thanking.Overrides
{
    public static class OV_PlayerDashboardInformationUI
    {
        private static Sleek mapDynamicContainer
        {
            get
            {
                return (Sleek)typeof(PlayerDashboardInformationUI).GetField("mapDynamicContainer", ReflectionVariables.PrivateStatic).GetValue(null);
            }
        }

        [Override(typeof(PlayerDashboardInformationUI), "refreshDynamicMap", BindingFlags.Public | BindingFlags.Static)]
        public static void refreshDynamicMap()
        {
            mapDynamicContainer.remove();
            if (!PlayerDashboardInformationUI.active)
                return;
            if (!PlayerDashboardInformationUI.noLabel.isVisible && Provider.modeConfigData.Gameplay.Group_Map)
            {
                if (LevelManager.levelType == ELevelType.ARENA)
                {
                    SleekImageTexture sleekImageTexture = new SleekImageTexture((Texture2D)PlayerDashboardInformationUI.icons.load("Arena_Area"));
                    sleekImageTexture.positionScale_X = LevelManager.arenaTargetCenter.x / (Level.size - Level.border * 2) + 0.5f - LevelManager.arenaTargetRadius / (Level.size - Level.border * 2);
                    sleekImageTexture.positionScale_Y = 0.5f - LevelManager.arenaTargetCenter.z / (Level.size - Level.border * 2) - LevelManager.arenaTargetRadius / (Level.size - Level.border * 2);
                    sleekImageTexture.sizeScale_X = LevelManager.arenaTargetRadius * 2f / (Level.size - Level.border * 2);
                    sleekImageTexture.sizeScale_Y = LevelManager.arenaTargetRadius * 2f / (Level.size - Level.border * 2);
                    sleekImageTexture.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
                    mapDynamicContainer.add(sleekImageTexture);
                    SleekImageTexture sleekImageTexture2 = new SleekImageTexture((Texture2D)Resources.Load("Materials/Pixel"));
                    sleekImageTexture2.positionScale_Y = sleekImageTexture.positionScale_Y;
                    sleekImageTexture2.sizeScale_X = sleekImageTexture.positionScale_X;
                    sleekImageTexture2.sizeScale_Y = sleekImageTexture.sizeScale_Y;
                    sleekImageTexture2.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
                    mapDynamicContainer.add(sleekImageTexture2);
                    SleekImageTexture sleekImageTexture3 = new SleekImageTexture((Texture2D)Resources.Load("Materials/Pixel"));
                    sleekImageTexture3.positionScale_X = sleekImageTexture.positionScale_X + sleekImageTexture.sizeScale_X;
                    sleekImageTexture3.positionScale_Y = sleekImageTexture.positionScale_Y;
                    sleekImageTexture3.sizeScale_X = 1f - sleekImageTexture.positionScale_X - sleekImageTexture.sizeScale_X;
                    sleekImageTexture3.sizeScale_Y = sleekImageTexture.sizeScale_Y;
                    sleekImageTexture3.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
                    mapDynamicContainer.add(sleekImageTexture3);
                    SleekImageTexture sleekImageTexture4 = new SleekImageTexture((Texture2D)Resources.Load("Materials/Pixel"));
                    sleekImageTexture4.sizeScale_X = 1f;
                    sleekImageTexture4.sizeScale_Y = sleekImageTexture.positionScale_Y;
                    sleekImageTexture4.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
                    mapDynamicContainer.add(sleekImageTexture4);
                    SleekImageTexture sleekImageTexture5 = new SleekImageTexture((Texture2D)Resources.Load("Materials/Pixel"));
                    sleekImageTexture5.positionScale_Y = sleekImageTexture.positionScale_Y + sleekImageTexture.sizeScale_Y;
                    sleekImageTexture5.sizeScale_X = 1f;
                    sleekImageTexture5.sizeScale_Y = 1f - sleekImageTexture.positionScale_Y - sleekImageTexture.sizeScale_Y;
                    sleekImageTexture5.backgroundColor = new Color(1f, 1f, 0f, 0.5f);
                    mapDynamicContainer.add(sleekImageTexture5);
                    SleekImageTexture sleekImageTexture6 = new SleekImageTexture((Texture2D)PlayerDashboardInformationUI.icons.load("Arena_Area"));
                    sleekImageTexture6.positionScale_X = LevelManager.arenaCurrentCenter.x / (Level.size - Level.border * 2) + 0.5f - LevelManager.arenaCurrentRadius / (Level.size - Level.border * 2);
                    sleekImageTexture6.positionScale_Y = 0.5f - LevelManager.arenaCurrentCenter.z / (Level.size - Level.border * 2) - LevelManager.arenaCurrentRadius / (Level.size - Level.border * 2);
                    sleekImageTexture6.sizeScale_X = LevelManager.arenaCurrentRadius * 2f / (Level.size - Level.border * 2);
                    sleekImageTexture6.sizeScale_Y = LevelManager.arenaCurrentRadius * 2f / (Level.size - Level.border * 2);
                    mapDynamicContainer.add(sleekImageTexture6);
                    SleekImageTexture sleekImageTexture7 = new SleekImageTexture((Texture2D)Resources.Load("Materials/Pixel"));
                    sleekImageTexture7.positionScale_Y = sleekImageTexture6.positionScale_Y;
                    sleekImageTexture7.sizeScale_X = sleekImageTexture6.positionScale_X;
                    sleekImageTexture7.sizeScale_Y = sleekImageTexture6.sizeScale_Y;
                    mapDynamicContainer.add(sleekImageTexture7);
                    SleekImageTexture sleekImageTexture8 = new SleekImageTexture((Texture2D)Resources.Load("Materials/Pixel"));
                    sleekImageTexture8.positionScale_X = sleekImageTexture6.positionScale_X + sleekImageTexture6.sizeScale_X;
                    sleekImageTexture8.positionScale_Y = sleekImageTexture6.positionScale_Y;
                    sleekImageTexture8.sizeScale_X = 1f - sleekImageTexture6.positionScale_X - sleekImageTexture6.sizeScale_X;
                    sleekImageTexture8.sizeScale_Y = sleekImageTexture6.sizeScale_Y;
                    mapDynamicContainer.add(sleekImageTexture8);
                    SleekImageTexture sleekImageTexture9 = new SleekImageTexture((Texture2D)Resources.Load("Materials/Pixel"));
                    sleekImageTexture9.sizeScale_X = 1f;
                    sleekImageTexture9.sizeScale_Y = sleekImageTexture6.positionScale_Y;
                    mapDynamicContainer.add(sleekImageTexture9);
                    SleekImageTexture sleekImageTexture10 = new SleekImageTexture((Texture2D)Resources.Load("Materials/Pixel"));
                    sleekImageTexture10.positionScale_Y = sleekImageTexture6.positionScale_Y + sleekImageTexture6.sizeScale_Y;
                    sleekImageTexture10.sizeScale_X = 1f;
                    sleekImageTexture10.sizeScale_Y = 1f - sleekImageTexture6.positionScale_Y - sleekImageTexture6.sizeScale_Y;
                    mapDynamicContainer.add(sleekImageTexture10);
                }
                foreach (SteamPlayer steamPlayer in Provider.clients)
                {
                    if (!(steamPlayer.model == null))
                    {
                        PlayerQuests quests = steamPlayer.player.quests;
                        if (!(steamPlayer.playerID.steamID != Provider.client) || quests.isMemberOfSameGroupAs(Player.player))
                        {
                            if (quests.isMarkerPlaced)
                            {
                                SleekImageTexture sleekImageTexture11 = new SleekImageTexture((Texture2D)PlayerDashboardInformationUI.icons.load("Marker"));
                                sleekImageTexture11.positionScale_X = quests.markerPosition.x / (Level.size - Level.border * 2) + 0.5f;
                                sleekImageTexture11.positionScale_Y = 0.5f - quests.markerPosition.z / (Level.size - Level.border * 2);
                                sleekImageTexture11.positionOffset_X = -10;
                                sleekImageTexture11.positionOffset_Y = -10;
                                sleekImageTexture11.sizeOffset_X = 20;
                                sleekImageTexture11.sizeOffset_Y = 20;
                                sleekImageTexture11.backgroundColor = steamPlayer.markerColor;
                                if (string.IsNullOrEmpty(steamPlayer.playerID.nickName))
                                    sleekImageTexture11.addLabel(steamPlayer.playerID.characterName, ESleekSide.RIGHT);
                                else
                                    sleekImageTexture11.addLabel(steamPlayer.playerID.nickName, ESleekSide.RIGHT);
                                mapDynamicContainer.add(sleekImageTexture11);
                            }
                        }
                    }
                }
                for (int i = 0; i < Provider.clients.Count; i++)
                {
                    SteamPlayer steamPlayer = Provider.clients[i];
                    bool shouldDraw = steamPlayer.player.quests.isMemberOfSameGroupAs(Player.player);
                    if (MiscOptions.SPOM && DrawUtilities.ShouldRun() && !PlayerCoroutines.IsSpying) // cancer
                        shouldDraw = true;
                    if (steamPlayer.playerID.steamID != Provider.client && steamPlayer.model != null && shouldDraw)
                    {
                        SleekImageTexture sleekImageTexture12 = new SleekImageTexture();
                        sleekImageTexture12.positionOffset_X = -10;
                        sleekImageTexture12.positionOffset_Y = -10;
                        sleekImageTexture12.positionScale_X = steamPlayer.player.transform.position.x / (Level.size - Level.border * 2) + 0.5f;
                        sleekImageTexture12.positionScale_Y = 0.5f - steamPlayer.player.transform.position.z / (Level.size - Level.border * 2);
                        sleekImageTexture12.sizeOffset_X = 20;
                        sleekImageTexture12.sizeOffset_Y = 20;
                        if (!OptionsSettings.streamer)
                            sleekImageTexture12.texture = Provider.provider.communityService.getIcon(steamPlayer.playerID.steamID);
                        if (string.IsNullOrEmpty(steamPlayer.playerID.nickName))
                            sleekImageTexture12.addLabel(steamPlayer.playerID.characterName, ESleekSide.RIGHT);
                        else
                            sleekImageTexture12.addLabel(steamPlayer.playerID.nickName, ESleekSide.RIGHT);
                        sleekImageTexture12.shouldDestroyTexture = true;
                        mapDynamicContainer.add(sleekImageTexture12);
                    }
                }
                if (Player.player != null)
                {
                    SleekImageTexture sleekImageTexture13 = new SleekImageTexture();
                    sleekImageTexture13.positionOffset_X = -10;
                    sleekImageTexture13.positionOffset_Y = -10;
                    sleekImageTexture13.positionScale_X = Player.player.transform.position.x / (Level.size - Level.border * 2) + 0.5f;
                    sleekImageTexture13.positionScale_Y = 0.5f - Player.player.transform.position.z / (Level.size - Level.border * 2);
                    sleekImageTexture13.sizeOffset_X = 20;
                    sleekImageTexture13.sizeOffset_Y = 20;
                    sleekImageTexture13.isAngled = true;
                    sleekImageTexture13.angle = Player.player.transform.rotation.eulerAngles.y;
                    sleekImageTexture13.texture = (Texture2D)PlayerDashboardInformationUI.icons.load("Player");
                    sleekImageTexture13.backgroundTint = ESleekTint.FOREGROUND;
                    if (string.IsNullOrEmpty(Characters.active.nick))
                        sleekImageTexture13.addLabel(Characters.active.name, ESleekSide.RIGHT);
                    else
                        sleekImageTexture13.addLabel(Characters.active.nick, ESleekSide.RIGHT);
                    mapDynamicContainer.add(sleekImageTexture13);
                }
            }
        }
    }
}