using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Set Cursor Lock Mode/State to Locked at Start
        Cursor.visible = false; //Turn Cursor Visibility to off

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //If you hit escape you can toggle between Cursor Locked and Unlocked
        {
            if (Cursor.visible == false) //If Cursor is currently not visible
            {
                Cursor.lockState = CursorLockMode.None; //Turn off the Cursor Lock Mode/State
                Cursor.visible = true; //Turn Cursor to visible
            }
            else if (Cursor.visible == true) //If Cursor is currently visible
            {
                Cursor.lockState = CursorLockMode.Locked; //Set Cursor Lock Mode/Sate to Locked
                Cursor.visible = false; //Turn Cursor visibility to off
            }
        }

    }
}
