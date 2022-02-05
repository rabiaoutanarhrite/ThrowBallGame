using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public bool isLive;

    // Start is called before the first frame update
    void Start()
    {
        isLive = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            isLive = false;
            Debug.Log("Done");
        }
    }
}
