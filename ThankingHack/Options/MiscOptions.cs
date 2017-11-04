﻿using Thanking.Attributes;
using UnityEngine;

namespace Thanking.Options
{
	public static class MiscOptions
	{
		[Save] public static bool NoSnow = false;
		[Save] public static bool NoRain = false;
		[Save] public static float SalvageTime = 1f;

		[Save] public static bool SetTimeEnabled = true;
		[Save] public static float Time = 0f;

		[Save] public static bool SlowFall = false;
		[Save] public static bool AirStick = false;

		[Save] public static bool LogoEnabled = true;
		[Save] public static KeyCode LogoToggle = KeyCode.Slash;

		[Save] public static KeyCode ReloadConfig = KeyCode.Period;
		[Save] public static KeyCode SaveConfig = KeyCode.Comma;

		[Save] public static KeyCode PanicButton = KeyCode.RightAlt;
		[Save] public static bool VisualsEnabled = true;
	}
}
