﻿using System.Reflection;
using Newtonsoft.Json.Bson;
using SDG.Unturned;
using Thanking.Attributes;
using Thanking.Coroutines;
using Thanking.Options;
using Thanking.Options.AimOptions;
using Thanking.Utilities;
using Thanking.Variables;
using UnityEngine;

namespace Thanking.Overrides
{
	public static class OV_Input
	{
		public static bool InputEnabled;

		[OnSpy]
		public static void OnSpied() =>
			InputEnabled = false;
		
		[OffSpy]
		public static void OnEndSpy() =>
			InputEnabled = true;	
		
		[Override(typeof(Input), "GetKey", BindingFlags.Public | BindingFlags.Static, 1)]
        public static bool OV_GetKey(KeyCode key)
		{
			if (!DrawUtilities.ShouldRun())
				return (bool) OverrideUtilities.CallOriginal(null, key);

			if (key == ControlsSettings.primary && TriggerbotOptions.IsFiring)
				return true;

			if ((key == ControlsSettings.left ||
			     key == ControlsSettings.right ||
			     key == ControlsSettings.up ||
			     key == ControlsSettings.down) &&
			    MiscOptions.SpectatedPlayer != null)
				return false;
			
			return (bool) OverrideUtilities.CallOriginal(null, key);
		}
    }
}
