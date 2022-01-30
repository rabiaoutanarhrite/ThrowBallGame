using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour
{

    [SerializeField] private List<GameObject> cubes = new List<GameObject>();

    private int fObj = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fObj == cubes.Count)
        {
            Debug.Log("Win!");

        }
    }

    

    private void OnTriggerExit(Collider other)
    {
        foreach(GameObject c in cubes)
        {
            if ( c == other.gameObject)
            {
                fObj++;
            }
        }
    }
}
