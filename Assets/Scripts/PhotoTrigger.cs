using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoTrigger : MonoBehaviour
{
    public Elevator elevator;

    private void OnTriggerStay(Collider other)
    {
        elevator.t = elevator.timeToClose;
    }
}
