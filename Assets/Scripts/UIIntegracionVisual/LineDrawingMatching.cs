using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawingMatching : MonoBehaviour
{
    public LineRenderer lineRenderer; // Attach a LineRenderer component to an empty GameObject in the scene.
    public Material lineMaterial; // The material for the line.
    public float lineWidth = 0.1f; // The width of the line.
    private bool isDrawing = false; // Indicates whether the line is being drawn.

    public LayerMask cardLayer; // Create a LayerMask for the cards.

    public List<Transform> selectedCards = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        InitializeLineRenderer();
    }

    // Update is called once per frame
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


        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, cardLayer);

            if (hit.collider != null)
            {
                SelectCard(hit.transform);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, cardLayer);

            if (hit.collider != null)
            {
                SelectCard(hit.transform);
            }
        }

        // Continue drawing when the mouse button is held down.
        if (isDrawing && Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateLine(mousePos);

            //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, cardLayer);

            if (hit.collider != null)
            {
                SelectCard(hit.transform);
                CheckForMatch();
            }

        }

        // Check for user input to stop drawing and check for a match.
        if (isDrawing && Input.GetMouseButtonUp(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, cardLayer);

            if (hit.collider != null)
            {
                SelectCard(hit.transform);
                CheckForMatch();
            }

            ResetLine();
        }

        CheckForMatch();
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

    void SelectCard(Transform card)
    {
        if (!selectedCards.Contains(card))
        {
            selectedCards.Add(card);
        }
    }

    void UpdateLine(Vector2 targetPos)
    {
        lineRenderer.positionCount = selectedCards.Count;
        for (int i = 0; i < selectedCards.Count; i++)
        {
            lineRenderer.SetPosition(i, selectedCards[i].position);
        }

        lineRenderer.SetPosition(selectedCards.Count, targetPos);
    }

    void ResetLine()
    {
        lineRenderer.positionCount = 0;
        selectedCards.Clear();
        isDrawing = false;
    }

    bool CheckForMatch()
    {
        if (selectedCards.Count == 2)
        {
            /*// Implement your matching logic here.
            // For simplicity, we're just checking if their names are the same.
            Debug.Log("1--------: " + selectedCards[0].name + " 2--------: " + selectedCards[1].name);
            if (selectedCards[0].name == selectedCards[1].name)
            {
                Debug.Log("Match!");
                // You can implement further actions for a correct match.
            }
            else
            {
                Debug.Log("No match!");
                // You can implement actions for an incorrect match.
            }*/

            char lastChar1 = selectedCards[0].name[selectedCards[0].name.Length - 1];
            char lastChar2 = selectedCards[1].name[selectedCards[1].name.Length - 1];

            // Check if the last characters are digits and if they are the same
            if (lastChar1 == lastChar2)
            {
                Debug.Log("Match!");
                return lastChar1 == lastChar2;
            }

            Debug.Log("No match!");

            // If either string doesn't end with a digit, they are not considered a match.
            return false;
        }
        return false;
    }
}
