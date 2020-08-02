using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public LayerMask buttonMask;
    public Image crosshair;
    public Sprite interactionSprite,idleSprite;
    public Text text;
    public float t, instructionsTime;
    bool instructions = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,5,buttonMask))
        {
            if (crosshair.sprite == idleSprite)
            {
                if (instructions)
                {
                    text.enabled = true;
                }
                crosshair.sprite = interactionSprite;
                crosshair.gameObject.GetComponent<RectTransform>().localScale= Vector3.one * 5;
                
            }

            //Pressing the button
            if (Input.GetButtonDown("Fire1"))
            {
                hit.transform.gameObject.GetComponent<ButtonScript>().ButtonClick();
            }

        }
        else if(crosshair.sprite == interactionSprite)
        {
            crosshair.sprite = idleSprite;
            text.enabled = false;
            crosshair.gameObject.GetComponent<RectTransform>().localScale = Vector3.one ;
        }

        if (text.enabled == true)
        {
            t += Time.deltaTime;
            if (t >= instructionsTime)
            {
                instructions = false;
                text.enabled = false;
            }
        }

        
    }
}
