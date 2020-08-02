using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public List<int> goals,removedGoals;
    public int curGoal, curFloor, floorHeight;
    public float speed, timeToClose, t;
    public float[] floors;
    public bool movingState, idleState, stopState,directionUp,playerInside;
    bool music;
    AudioSource source;
    DoorStates doorStates;



    void Start()
    {
        goals = new List<int>();
        removedGoals = new List<int>();
        t = timeToClose;
        doorStates = GetComponent<DoorStates>();
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        doorStates.DoorState();
        if (movingState && doorStates.doorState == 3)
        {
            ElevatorMovement();
        }
        if (stopState)
        {
            ElevatorStop();
        }
        if (idleState)
        {
            ElevatorIdle();
        }

        CurFloorMath();


        

    }

    public void CurFloorMath()
    {
        if (transform.position.y % floorHeight < 0.1)
        {
            curFloor = (int)(transform.position.y / floorHeight);
        }

    }



    //----------------------------Elevator States--------------------
    //ElevatorMovement
    public void ElevatorMovement()
    {
        if (curGoal != curFloor)
        {

            
            Vector3 goalVector = new Vector3(transform.position.x, floors[curGoal], transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, goalVector, speed * Time.deltaTime);
            if (movingState && !music && playerInside)
            {
                source.Play();
                music = true;
            }
        }
        else
        {
            source.Pause();
            goals.RemoveAt(0);
            movingState = false;
            stopState = true;
            idleState = false;
            music = false;
            
        }
    }

    public void ElevatorStop()
    {
      
        t = timeToClose;
        doorStates.DoorOpening();
        movingState = false;
        stopState = false;
        idleState = true;
    }


    public void ElevatorIdle()
    {
        if (t > 0)
        {
            t -= Time.deltaTime;
            if (doorStates.doorState != 0)
            {
                doorStates.DoorOpening();
            }
        }
        if (t <= 0)
        {

            doorStates.DoorClosing();
            ChoosingGoal();
        }
    }

    //----------------------------Elevator States--------------------end

    //----------------------------------------------------------------

    //----------------------------Elevator goals----------------------

    public void SetGoal(int newGoal)
    {

        goals.Add(newGoal);
        ChoosingGoal();



    }

    public void Sorting()
    {
        if (directionUp)
        {
            goals.Sort();

        }
        else
        {
            goals.Sort();
            goals.Reverse();
        }
    }

  


    public void ChoosingGoal()
    {
        if (doorStates.doorState == 3)
        {
            Sorting();
            UpdateCurGoal();
        }
    }

    public void UpdateCurGoal()
    {
        if (goals.Count > 0)
        {
            if (goals.Count > 1)
            {
                if (directionUp)
                {
                    if (goals[0] <= curFloor)
                    {
                        removedGoals.Add(goals[0]);
                        goals.RemoveAt(0);
                        UpdateCurGoal();
                    }

                }
                else
                {
                    if (goals[0] >= curFloor)
                    {
                        removedGoals.Add(goals[0]);
                        goals.RemoveAt(0);
                        UpdateCurGoal();
                    }

                }
            }
            curGoal = goals[0];
            if (floors[curGoal] < transform.position.y)
            {
                directionUp = false;
            }
            else directionUp = true;

            goals.InsertRange(goals.Count, removedGoals);
            removedGoals.Clear();



            movingState = true;
            stopState = false;
            idleState = false;
        }
        }
    
    //----------------------------Elevator goals----------------------end
}
