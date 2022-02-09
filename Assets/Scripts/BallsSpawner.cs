using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawner : MonoBehaviour
{

    public static BallsSpawner instance;

    [SerializeField] private GameObject ball;

    [SerializeField] private int numSpawns = 0;

    private int countSpawn = 0;

    private int restBalls;

    public bool isLaunch;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        restBalls = numSpawns;
        
        GameManager.instance.restBallsTxt.text = restBalls + "x";

        Instantiate(ball, this.transform.position, Quaternion.identity);
         
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && isLaunch)
        {
            Debug.Log("Rest Of Balls: " + restBalls);

            countSpawn++;

            restBalls--;
            GameManager.instance.restBallsTxt.text = restBalls + "x";

            if (restBalls != 0)
            {
                StartCoroutine(WaitLaunchBall());
            }
             
            isLaunch = false;
        } 

        LimitSpawn();
    }
    
    private void LimitSpawn()
    {
        if(countSpawn == numSpawns)
        {
            StartCoroutine(LoseCheck());
        }
    }
    
    IEnumerator WaitLaunchBall()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(ball, this.transform.position, Quaternion.identity);
        
    }

    IEnumerator LoseCheck()
    {
        yield return new WaitForSeconds(5f);

        if (!GameManager.instance.isWin)
        {
            Debug.Log("lose");
            GameManager.instance.Losing();
        }

    }
}
