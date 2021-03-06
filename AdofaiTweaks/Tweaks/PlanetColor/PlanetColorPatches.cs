﻿using AdofaiTweaks.Core.Attributes;
using HarmonyLib;
using UnityEngine;

using AdofaiPlanetColor = PlanetColor;

namespace AdofaiTweaks.Tweaks.PlanetColor
{
    internal static class PlanetColorPatches
    {
        [SyncTweakSettings]
        private static PlanetColorSettings Settings { get; set; }

        [HarmonyPatch(typeof(scrPlanet), "SetPlanetColor")]
        private static class SetPlanetColorPatch
        {
            public static void Prefix(scrPlanet __instance, ref Color color) {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    if (__instance.isRed) {
                        color = Settings.Color1;
                    } else {
                        color = Settings.Color2;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(scrPlanet), "SetCoreColor")]
        private static class SetCoreColorPatch
        {
            public static void Prefix(scrPlanet __instance, ref Color color) {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    if (__instance.isRed) {
                        color = Settings.Color1;
                    } else {
                        color = Settings.Color2;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(scrPlanet), "SetTailColor")]
        private static class SetTailColorPatch
        {
            public static void Prefix(scrPlanet __instance, ref Color color) {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    if (__instance.isRed) {
                        color = Settings.TailColor1;
                    } else {
                        color = Settings.TailColor2;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(scrPlanet), "SetRingColor")]
        private static class SetRingColorPatch
        {
            public static void Prefix(scrPlanet __instance, ref Color color) {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    if (__instance.isRed) {
                        color = Settings.Color1;
                    } else {
                        color = Settings.Color2;
                    }
                }
            }
        }

        [HarmonyPatch(typeof(scrPlanet), "SetColor")]
        private static class SetColorPatch
        {
            public static void Postfix(scrPlanet __instance, AdofaiPlanetColor planetColor) {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    __instance.RemoveGold();
                    __instance.SetRainbow(false);
                    Color color = planetColor.GetColor();
                    __instance.EnableCustomColor();
                    __instance.SetPlanetColor(color);
                    __instance.SetTailColor(color);
                }
            }
        }

        [HarmonyPatch(typeof(scrPlanet), "LoadPlanetColor")]
        private static class LoadPlanetColorPatch
        {
            public static void Prefix() {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    Settings.OriginalColor1 = Persistence.GetPlayerColor(true);
                    Settings.OriginalColor2 = Persistence.GetPlayerColor(false);
                    Persistence.SetPlayerColor(Settings.Color1, true);
                    Persistence.SetPlayerColor(Settings.Color2, false);
                }
            }

            public static void Postfix() {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    Persistence.SetPlayerColor(Settings.OriginalColor1, true);
                    Persistence.SetPlayerColor(Settings.OriginalColor2, false);
                }
            }
        }

        [HarmonyPatch(typeof(scrController), "RainbowMode")]
        private static class RainbowModePatch
        {
            public static void Postfix(scrController __instance) {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    __instance.redPlanet.SetRainbow(false);
                    __instance.redPlanet.LoadPlanetColor();
                    __instance.bluePlanet.SetRainbow(false);
                    __instance.bluePlanet.LoadPlanetColor();
                }
            }
        }

        [HarmonyPatch(typeof(scrController), "EnbyMode")]
        private static class EnbyModePatch
        {
            public static void Postfix(scrController __instance) {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    __instance.redPlanet.LoadPlanetColor();
                    __instance.bluePlanet.LoadPlanetColor();
                }
            }
        }

        [HarmonyPatch(typeof(scrController), "TransMode")]
        private static class TransModePatch
        {
            public static void Postfix(scrController __instance) {
                if (Settings.IsEnabled && AdofaiTweaks.IsEnabled) {
                    __instance.redPlanet.LoadPlanetColor();
                    __instance.bluePlanet.LoadPlanetColor();
                }
            }
        }
    }
}
