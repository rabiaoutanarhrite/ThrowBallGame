using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    private Rigidbody rb;

    private bool isShoot;

    [SerializeField] private float forceMultiplier = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        startPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if (!GameManager.instance.isWin)
        {
            Vector3 forceInit = (Input.mousePosition - startPos);
            Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y)) * forceMultiplier;

            if (!isShoot)
            {
                DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);
            }
        }
    }

    private void OnMouseUp()
    {
        if (!GameManager.instance.isWin)
        {
            DrawTrajectory.Instance.HideLine();
            endPos = Input.mousePosition;
            Shoot(startPos - endPos);
            BallsSpawner.instance.isLaunch = true;

            StartCoroutine(DestroyBall());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 force)
    {
        if (isShoot)
        {
            return;
        }

        rb.AddForce(new Vector3(force.x, force.y, force.y) * forceMultiplier);
        isShoot = true;
    }

    IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(5f);

        Destroy(this.gameObject);
    }

}
