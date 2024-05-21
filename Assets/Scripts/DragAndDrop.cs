using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;
    private Transform startParent;

    private void Start()
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }

   
    private void OnMouseDown()
    {
        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPosition();
        startPosition = transform.position;
        startParent = transform.parent;
    }

    void OnMouseUp()
    {
        isDragging = false;

        Collider2D[] Cells = Physics2D.OverlapBoxAll(GetMouseWorldPosition(), new Vector2(1f, 1f), 0f);

        foreach (Collider2D cell in Cells)
        {
            if (cell.CompareTag("YellowGridCells") && cell.transform.childCount == 0)
            {
                SnapToCell(cell.transform);
                return;
            }
            else if (cell.CompareTag("BlueGridCells") && cell.transform.childCount == 0)
            {
                SnapToCell(cell.transform);
                return;
            }
           /* else if (cell.CompareTag("PinkGridCells") && cell.transform.childCount == 0)
            {
                SnapToCell(cell.transform);
                return;
            }
            else if (cell.CompareTag("IntersectionCells") && cell.transform.childCount == 0)
            {
                SnapToCell(cell.transform);
                return;
            }
            else if (cell.CompareTag("BlankCells") && cell.transform.childCount == 0)
            {
                SnapToCell(cell.transform);
                return;
            }*/

        }
        ReturnToStart();
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void SnapToCell(Transform cell)
    {
        Vector3 snapPosition = cell.position;
        snapPosition.z = -2f; // Set the z position to -2

        // Get the center of the cell's bounds
        Bounds cellBounds = cell.GetComponent<Collider2D>().bounds;
        snapPosition = cellBounds.center;

        transform.position = snapPosition;
        transform.parent = cell;
    }
    private void ReturnToStart()
    {
        transform.position = startPosition;
        transform.parent = startParent;
    }
}


   

     

