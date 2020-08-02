using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public int floorNumber;
    public bool isActive;
    public bool isOutside;
    public Elevator elevatorScript;
    public DoorStates doorStates;
    Light buttonLight;
    AudioSource audioSource;
    public AudioClip clip,buttClicked;
    // Start is called before the first frame update
    void Start()
    {
        buttonLight = GetComponentInChildren<Light>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(elevatorScript.idleState && elevatorScript.curFloor == floorNumber && (doorStates.doorState==1|| doorStates.doorState == 0))
        {
            if (isActive && elevatorScript.playerInside && !isOutside)
            {
                audioSource.PlayOneShot(clip);
               
            }
            if (isActive && isOutside)
            {
                audioSource.PlayOneShot(clip);
                
            }

            isActive = false;
            buttonLight.enabled = false;
            

        }
    }

    public void ButtonClick()
    {

        if (!isActive)
        {

            if (elevatorScript.curFloor == floorNumber && !elevatorScript.movingState)
            {

                elevatorScript.t = elevatorScript.timeToClose;

            }
            if (elevatorScript.curFloor != floorNumber || elevatorScript.movingState)
            {
                elevatorScript.SetGoal(floorNumber);
            }

            /* if (!elevatorScript.goals.Contains(floorNumber))
             {

             }*/
            isActive = true;
            buttonLight.enabled = true;
            audioSource.PlayOneShot(buttClicked);
        }
            

    }
}
