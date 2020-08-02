using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoors : MonoBehaviour
{
    public int floorNumber;
   public Elevator elevator;
    public Controls player;
    public DoorStates doorStates;
    Animator animator;
    public Light roomLight;

    //This Script synchronizes Doors!

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (elevator.curFloor == floorNumber)
        {
           
            animator.SetFloat("Multi", doorStates.animator.GetFloat("Multi"));
        }
        

        if (player.playerCurFloor == floorNumber || elevator.curFloor == floorNumber)
        {
            roomLight.enabled = true;
        }
        else roomLight.enabled = false;

    }

    
}
