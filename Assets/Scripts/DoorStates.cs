using UnityEngine;


public class DoorStates : MonoBehaviour
{
    public int doorState;//doorState {0-Open,1-Opening,2-Closing,3-Closed}
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip doorSound, doorEndSound;

    


    public void DoorOpening()
    {
        if (doorState != 0)
        {
            if (doorState != 1)
            {
                animator.SetFloat("Multi", 1);
                audioSource.Stop();
                audioSource.PlayOneShot(doorSound);
                doorState = 1;
            }
            
            
        }

    }

    public void DoorClosing()
    {
        if (doorState == 0)
        {
            animator.SetFloat("Multi", -1);
            doorState = 2;
            audioSource.Stop();
            audioSource.PlayOneShot(doorSound);
        }
    }

    public void DoorState()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (doorState != 0)
            {
                animator.SetFloat("Multi", 0);
                doorState = 0;
                audioSource.Stop();

            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.0f)
        {
            if (doorState != 3)
            {
                animator.SetFloat("Multi", 0);
                doorState = 3;
                audioSource.Stop();

            }
        }

    }
}
