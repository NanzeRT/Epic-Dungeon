using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class exit : MonoBehaviour
{
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonUp("Cancel"))
        {
            Debug.Log("Quit");
            Application.Quit();
            
        }
        if (CrossPlatformInputManager.GetButtonUp("Restart"))
        {
            Debug.Log("Restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}
