using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

using GameSettings;

public class GUIManager : MonoBehaviour
{
    public GameObject mobileGUI;
    public GameObject standaloneGUI;

    void Start()
    {
        CrossPlatformInputManager.SwitchActiveInputMethod(Settings.activeInput);
        if (Settings.activeInput == CrossPlatformInputManager.ActiveInputMethod.Touch)
            mobileGUI.SetActive(true);
        else
            standaloneGUI.SetActive(true);
    }
    public void SwitchActiveInputMethod(bool isTouch)
    {
        Settings.activeInput = isTouch? 
        CrossPlatformInputManager.ActiveInputMethod.Touch : 
        CrossPlatformInputManager.ActiveInputMethod.Hardware;
        CrossPlatformInputManager.SwitchActiveInputMethod(Settings.activeInput);
    }
}
