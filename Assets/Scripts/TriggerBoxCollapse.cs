using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxCollapse : MonoBehaviour
{
    public GameObject archiveBoxStack;
    public GameObject archuveBoxStackAnimated;
    public bool hasTriggerbeenTriggered = false;
    public GameObject uIController;
    public GameObject boxCollapseAudio;
    public GameObject particles;
    private float particleTimer;
    public float particleLength;

    //Runs when the Player moves into this trigger
    void OnTriggerEnter(Collider other)
    {
        //Checks if the tag of the object that enters is "Player"
        if (other.tag == "Player" && !hasTriggerbeenTriggered)
        {
            //Play Box Falling Annimation
            archiveBoxStack.SetActive(false);
            archuveBoxStackAnimated.SetActive(true);
            boxCollapseAudio.SetActive(true);
            hasTriggerbeenTriggered = true;
            particles.SetActive(true);
            particleTimer = Time.time;
            GameObject.FindObjectOfType<UIController>().Dialogue("*Sigh*... Who stacked these?\nLooks like I'll have to take the long way round.", 4); //Show Dialogue saying the door is locked.
        }
    }

    void Update()
    {
        //If the time passed is MORE THAN the display length (allows it to display inclusive of the frame it hits the display length)
        if (Time.time - particleTimer > particleLength)
        {
            //Deativate Particles
            particles.SetActive(false); //Turn off particles
        }


    }

}
