using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Target> targets = new List<Target>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Target t in targets)
        {
            if (!t.isLive)
            {
                Debug.Log("Win!");
            }
        }
    }
}
