using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSODFlash : MonoBehaviour
{
    private bool isShowingPressY; //Variable for is the message showing
    private float displayTimer; //Display Timer
    private float replayTimer; //Timer for how long the Press Y isn't displayed
    public float displayLength; //Variable for how long the message is displayed
    public float replayLength; //Variable for how long until the press y is replayed.
    public GameObject bSODPressY; //Reference to Game Object

    // Start is called before the first frame update
    void Start()
    {
        isShowingPressY = true; // Set Showing to true
        displayTimer = Time.time; //Set timer and how time is calculated
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowingPressY)
        {
            //If the time passed is MORE THAN the display length (allows it to display inclusive of the frame it hits the display length)
            if (Time.time - displayTimer > displayLength)
            {
                //Deativate Message Panel
                bSODPressY.SetActive(false); //Turn off Press Y UI
                isShowingPressY = false; //Set is Showing Press Y Bool to false
                replayTimer = Time.time; //Set timer and how time is calculated
            }
        }

        if (!isShowingPressY)
        {
            //If the time passed is MORE THAN the display length (allows it to display inclusive of the frame it hits the display length)
            if (Time.time - replayTimer > replayLength)
            {
                bSODPressY.SetActive(true); //Turn off Press Y UI
                isShowingPressY = true; //Set is Showing Press Y Bool to false
                displayTimer = Time.time; //Set timer and how time is calculated
            }
        }
    }
}
