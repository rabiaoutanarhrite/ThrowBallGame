using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] [Range(3, 30)] private int lineSegCount = 20;

    private List<Vector3> linePoints = new List<Vector3>();

    public static DrawTrajectory Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rb, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / rb.mass) * Time.fixedDeltaTime;

        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = FlightDuration / lineSegCount;

        linePoints.Clear();

        for (int i = 0; i < lineSegCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 movementVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                velocity.z * stepTimePassed
                );

            linePoints.Add(-movementVector + startingPoint);
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
    }

    public void HideLine()
    {
        lineRenderer.positionCount = 0;
    }
}
