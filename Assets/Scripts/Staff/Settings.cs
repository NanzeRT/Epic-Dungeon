using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityStandardAssets.CrossPlatformInput;

namespace GameSettings
{
    public static class Settings
    {
        public static CrossPlatformInputManager.ActiveInputMethod activeInput =
#if MOBILE_INPUT
        CrossPlatformInputManager.ActiveInputMethod.Touch;
#else
        CrossPlatformInputManager.ActiveInputMethod.Hardware;
#endif
    }
}