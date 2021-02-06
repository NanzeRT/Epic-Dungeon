using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetAxis("Cancel") > 0)
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
