using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    public LineRenderer lineRenderer; // Attach a LineRenderer component to an empty GameObject in the scene.
    public Material lineMaterial; // The material for the line.
    public float lineWidth = 0.1f; // The width of the line.
    private bool isDrawing = false; // Indicates whether the line is being drawn.

    void Start()
    {
        InitializeLineRenderer();
    }

    void Update()
    {
        // Check for mouse button down to start drawing.
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }

        // Check for mouse button release to stop drawing.
        if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }

        // Draw the line while the mouse button is held down.
        if (isDrawing)
        {
            DrawLine();
        }
    }

    void InitializeLineRenderer()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.positionCount = 0;
    }

    void StartDrawing()
    {
        isDrawing = true;
        lineRenderer.positionCount = 0;
    }

    void StopDrawing()
    {
        isDrawing = false;
        lineRenderer.positionCount = 0;
    }

    void DrawLine()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        int pointCount = lineRenderer.positionCount;
        lineRenderer.positionCount = pointCount + 1;
        lineRenderer.SetPosition(pointCount, mousePosition);
    }
}
