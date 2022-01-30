using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawner : MonoBehaviour
{

    public static BallsSpawner Instance;

    [SerializeField] private GameObject ball;

    public bool isLaunch;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Instantiate(ball, this.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isLaunch)
        {
            Debug.Log("hhh");

            StartCoroutine(WaitLaunchBall());

            isLaunch = false;
        }
    }
    private void OnMouseUp()
    {
        
    }
    
    IEnumerator WaitLaunchBall()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(ball, this.transform.position, Quaternion.identity);
    }
}
