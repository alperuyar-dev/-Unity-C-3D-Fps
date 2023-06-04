using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject closedDoorText;

    public AudioSource doorSound;


    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    void OnMouseOver()
    {

        if (theDistance <= 2)
        {
            actionKey.SetActive(true);
        }
        else
        {
            actionKey.SetActive(false);
        }
        if (Input.GetButton("Action"))
        {
            if (theDistance <= 2)
            {
                actionKey.SetActive(false);
                closedDoorText.SetActive(true);
                StartCoroutine(ClosedDoor());
                doorSound.Play();

            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);

    }

    IEnumerator ClosedDoor()
    {
        yield return new WaitForSeconds(1.5f);
        closedDoorText.SetActive(false);
    }
}
