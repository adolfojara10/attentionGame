using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour
{
    public Material lineMaterial;
    public float lineWidth = 0.1f;
    private bool isDrawing = false;
    private List<Vector3> linePositions = new List<Vector3>();
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();
    public LineRenderer lineRenderer;


    private void Start()
    {
        InitializeLineRenderer();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }

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
        linePositions.Clear();
    }

    void StopDrawing()
    {
        if (linePositions.Count > 1)
        {
            CreateNewLineRenderer();
            lineRenderers[lineRenderers.Count - 1].positionCount = linePositions.Count;
            lineRenderers[lineRenderers.Count - 1].SetPositions(linePositions.ToArray());
        }

        isDrawing = false;
        linePositions.Clear();
    }

    void DrawLine()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        linePositions.Add(mousePosition);

        int pointCount = linePositions.Count;
        lineRenderer.positionCount = pointCount;
        lineRenderer.SetPosition(pointCount - 1, mousePosition);
    }

    void CreateNewLineRenderer()
    {
        GameObject lineObj = new GameObject("LineRenderer");
        LineRenderer lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;

        lineRenderers.Add(lineRenderer);
    }
}
