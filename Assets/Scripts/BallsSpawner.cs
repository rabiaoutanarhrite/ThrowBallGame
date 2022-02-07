using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawner : MonoBehaviour
{

    public static BallsSpawner Instance;

    [SerializeField] private GameObject ball;

    [SerializeField] private int numSpawns = 0;

    private int countSpawn = 0;

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

        LimitSpawn();
    }
    
    private void LimitSpawn()
    {
        if(countSpawn == numSpawns)
        {
            Debug.Log("lose");
        }
    }
    
    IEnumerator WaitLaunchBall()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(ball, this.transform.position, Quaternion.identity);

        countSpawn++;

    }
}
