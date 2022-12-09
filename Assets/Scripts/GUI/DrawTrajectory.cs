using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawTrajectory : MonoBehaviour
{
    /*

    public int numSteps = 1000;
    public float timeStep = 0.1f;
    public bool usePhysicsTimeStep;

    public bool relativeToBody;
    public GravityBody centralBody;
    public float width = 100;
    public bool useThickLines;


    void Start()
    {
        if (Application.isPlaying)
        {
            HideOrbits();
        }
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DrawOrbits();
        }
    }

    void DrawOrbits()
    {

        GravityBody[] bodies = FindObjectsOfType<GravityBody>();
        var virtualBodies = new VirtualBody[bodies.Length];
        var drawPoints = new Vector3[bodies.Length][];
        int referenceFrameIndex = 0;
        Vector2 referenceBodyInitialPosition = Vector2.zero;

        // Initialize virtual bodies (don't want to move the actual bodies)
        for (int i = 0; i < virtualBodies.Length; i++)
        {
            virtualBodies[i] = new VirtualBody(bodies[i]);
            drawPoints[i] = new Vector3[numSteps];

            if (bodies[i] == centralBody && relativeToBody)
            {
                referenceFrameIndex = i;
                referenceBodyInitialPosition = virtualBodies[i].Position;
            }
        }

        // Simulate
        for (int step = 0; step < numSteps; step++)
        {
            Vector2 referenceBodyPosition = (relativeToBody) ? virtualBodies[referenceFrameIndex].Position : Vector2.zero;
            // Update velocities
            for (int i = 0; i < virtualBodies.Length; i++)
            {
                virtualBodies[i].EmittingGravity(virtualBodies, timeStep);
            }
            // Update positions
            for (int i = 0; i < virtualBodies.Length; i++)
            {
                virtualBodies[i].UpdatePosition(timeStep);
                Vector2 newPos = virtualBodies[i].Position;

                if (relativeToBody)
                {
                    var referenceFrameOffset = referenceBodyPosition - referenceBodyInitialPosition;
                    newPos -= referenceFrameOffset;
                }
                if (relativeToBody && i == referenceFrameIndex)
                {
                    newPos = referenceBodyInitialPosition;
                }

                drawPoints[i][step] = new Vector3(newPos.x, newPos.y, 0);
            }
        }

        // Draw paths
        for (int bodyIndex = 0; bodyIndex < virtualBodies.Length; bodyIndex++)
        {
            var pathColour = Color.red; //bodies[bodyIndex].gameObject.GetComponentInChildren<MeshRenderer> ().sharedMaterial.color; //

            if (useThickLines)
            {
                var lineRenderer = bodies[bodyIndex].gameObject.GetComponentInChildren<LineRenderer>();
                lineRenderer.enabled = true;
                lineRenderer.positionCount = drawPoints[bodyIndex].Length;
                lineRenderer.SetPositions(drawPoints[bodyIndex]);
                lineRenderer.startColor = pathColour;
                lineRenderer.endColor = pathColour;
                lineRenderer.widthMultiplier = width;
            }
            else
            {
                for (int i = 0; i < drawPoints[bodyIndex].Length - 1; i++)
                {
                    Debug.DrawLine(drawPoints[bodyIndex][i], drawPoints[bodyIndex][i + 1], pathColour);
                }

                // Hide renderer
                var lineRenderer = bodies[bodyIndex].gameObject.GetComponentInChildren<LineRenderer>();
                if (lineRenderer)
                {
                    lineRenderer.enabled = false;
                }
            }
        }

    }


    void HideOrbits()
    {
        GravityBody[] bodies = FindObjectsOfType<GravityBody>();

        // Draw paths
        for (int bodyIndex = 0; bodyIndex < bodies.Length; bodyIndex++)
        {
            var lineRenderer = bodies[bodyIndex].gameObject.GetComponentInChildren<LineRenderer>();
            lineRenderer.positionCount = 0;
        }
    }

    void OnValidate()
    {
        if (usePhysicsTimeStep)
        {
            timeStep = Universe.physicsTimeStep;
        }
    }

*/
}
