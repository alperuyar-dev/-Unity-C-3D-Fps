using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool isKeyObtained;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "key1")
        {
            isKeyObtained = true;
            Destroy(key);
        }
    }

}
