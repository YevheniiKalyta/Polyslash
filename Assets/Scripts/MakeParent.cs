using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParent : MonoBehaviour
{
    //Player become a children of an elevator entering it

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = this.transform.parent;
        this.transform.parent.gameObject.GetComponent<Elevator>().playerInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
        this.transform.parent.gameObject.GetComponent<Elevator>().playerInside = false;

    }
}
