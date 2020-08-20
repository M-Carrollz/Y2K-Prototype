using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bSOD;
    public GameObject y2KTitle;
    public GameObject credits;
    private bool isFirstYPress;
    public GameObject keyboardPressAudio;

    private bool isFirstEnter;
    public GameObject startScreen;
    public GameObject keyboardPressAudio2;
    public GameObject pCStartup;
    public GameObject shutdownAudio;
    public GameObject animatedLights;
    private float animatedLightTimer;
    public float animatedLightDisplayLength;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Set Cursor Lock Mode/State to Locked at Start
        Cursor.visible = false; //Turn Cursor Visibility to off

        isFirstYPress = true;
        isFirstEnter = true;
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

        if (Input.GetKeyDown(KeyCode.Y) && isFirstYPress)
        {
            bSOD.SetActive(false);
            y2KTitle.SetActive(true);
            isFirstYPress = false;
            keyboardPressAudio.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Return) && isFirstEnter)
        {
            startScreen.SetActive(false);
            isFirstEnter = false;
            keyboardPressAudio2.SetActive(true);
            pCStartup.SetActive(false);
            shutdownAudio.SetActive(true);
            animatedLights.SetActive(true);
            animatedLightTimer = Time.time;
        }

        if (Time.time - animatedLightTimer > animatedLightDisplayLength)
        {
            animatedLights.SetActive(false);
        }

    }
}
