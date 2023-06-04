using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPistol : MonoBehaviour
{
    public float theDistance;
    public GameObject actionKey;
    public GameObject pistol;
    public GameObject realPistol;
    public GameObject ammoPanel;

    //public AudioSource doorSound;


    void Start()
    {

    }
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

                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                actionKey.SetActive(false);
                realPistol.SetActive(true);
                Destroy(pistol);
                ammoPanel.SetActive(true);


                //   doorSound.Play();

            }
        }
    }

    void OnMouseExit()
    {
        actionKey.SetActive(false);
    }


}
