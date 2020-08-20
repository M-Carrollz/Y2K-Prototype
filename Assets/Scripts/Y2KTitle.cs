using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y2KTitle : MonoBehaviour
{
    private bool isShowingPressY; //Variable for is the Press Y message showing.
    private bool isGlitching; //Variable is the screen glitching.
    private float displayTimer; //Display Timer.
    private float replayTimer; //Timer for how long the Press Y isn't displayed.
    private float glitchTimer; //Timer for how long the glitch is displayed.
    private float glitchReplayTimer; //Timer for how long the glitch isn't displayed.
    public float glitchLength; //Variable for how long between glitches.
    public float glitchDisplayLength; //Variable for how long between glitches.
    public float displayLength; //Variable for how long the message is displayed.
    public float replayLength; //Variable for how long until the press y is replayed.
    public GameObject titlePressY; //Reference to Game Object.
    public GameObject titleGlitch; //Reference to Game Object.
    public GameObject titleGlitchPressY; //Reference to Game Object.

    public GameObject credits;
    public GameObject keyboardPressAudio;

    // Start is called before the first frame update
    void Start()
    {
        isShowingPressY = false; // Set Showing to false
        isGlitching = false; //Set showing glitch to false
        glitchReplayTimer = Time.time; //Set Glitch Replay timer and set how time is calculated.
        replayTimer = Time.time; //Set timer and how time is calculated
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowingPressY && !isGlitching) // Set to showing Press Y without glitch.
        {
            //If the time passed is MORE THAN the display length (allows it to display inclusive of the frame it hits the display length)
            if (Time.time - displayTimer > displayLength)
            {
                //Deativate Press Y Message
                titlePressY.SetActive(false); //Turn off Press Y UI
                isShowingPressY = false; //Set is Showing Press Y Bool to false
                replayTimer = Time.time; //Set timer and how time is calculated
            }
        }

        if (isShowingPressY && isGlitching)
        {
            //If the time passed is MORE THAN the display length (allows it to display inclusive of the frame it hits the display length)
            if (Time.time - displayTimer > displayLength)
            {
                //Deativate Press Y Message
                titleGlitchPressY.SetActive(false); //Turn off Press Y UI
                titleGlitch.SetActive(true); //Turn on Glitch.
                isShowingPressY = false; //Set is Showing Press Y Bool to false
                replayTimer = Time.time; //Set timer and how time is calculated
            }
        }

        if (!isShowingPressY && !isGlitching)
        {
            //If the time passed is MORE THAN the display length (allows it to display inclusive of the frame it hits the display length)
            if (Time.time - replayTimer > replayLength)
            {
                titlePressY.SetActive(true); //Turn on Press Y UI
                titleGlitchPressY.SetActive(false); //Turn off Glitch
                titleGlitch.SetActive(false); //Turn off Glitch
                isShowingPressY = true; //Set is Showing Press Y Bool to true
                displayTimer = Time.time; //Set timer and how time is calculated
            }
        }

        if (!isShowingPressY && isGlitching)
        {
            //If the time passed is MORE THAN the display length (allows it to display inclusive of the frame it hits the display length)
            if (Time.time - replayTimer > replayLength)
            {
                titleGlitchPressY.SetActive(true); //Turn on Press Y UI
                isShowingPressY = true; //Set is Showing Press Y Bool to true
                displayTimer = Time.time; //Set timer and how time is calculated
            }
        }

        if (Time.time - glitchReplayTimer > glitchLength)
        {
            isGlitching = true;
            glitchTimer = Time.time;
        }

        if (Time.time - glitchTimer > glitchDisplayLength)
        {
            isGlitching = false;
            glitchReplayTimer = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            keyboardPressAudio.SetActive(true);
            credits.SetActive(true);
        }
    }
}
