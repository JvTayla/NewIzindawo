using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static DraggablePiece;
using static ZoneManager;

public class GridCellSlot : MonoBehaviour, IDropHandler /*IEndDragHandler*/
{

    
    public enum PieceType
    {
        Circle,
        Triangle
    }

    private enum PieceColor
    {
        Pink,
        Blue,
        Yellow
    }

    private PieceColor GetPieceColor(GameObject pieceObject)
    {
        if (pieceObject.CompareTag("Pink"))
        {
            return PieceColor.Pink;
        }
        else if (pieceObject.CompareTag("Blue"))
        {
            return PieceColor.Blue;
        }
        else if (pieceObject.CompareTag("Yellow"))
        {
            return PieceColor.Yellow;
        }
        return PieceColor.Pink; 
    }

    private ZoneManager zoneManager;

    private void Start()
    {
        // Get a reference to the ZoneManager instance
        zoneManager = FindObjectOfType<ZoneManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggablePiece draggablepiece = dropped.GetComponent<DraggablePiece>();
            draggablepiece.transform.SetParent(transform);
            draggablepiece.transform.localPosition = Vector3.zero;
            PieceColor pieceColor = GetPieceColor(dropped);

            // Check piece color and zone color for movement restrictions
            if (pieceColor == PieceColor.Pink)
            {
                // Pink piece movement logic
                if (zoneManager.IsInZone(transform.gameObject, ZoneType.Pink))
                {
                    Debug.Log("Pink Piece can Move 2 spaces in any direction");
                    
                }
                else
                {
                    Debug.Log("Pink Piece can Move 1 space in any direction");
                    
                }
            }
            else if (pieceColor == PieceColor.Blue)
            {
                // Blue piece movement logic
                if (zoneManager.IsInZone(transform.gameObject, ZoneType.Blue))
                {
                    Debug.Log("Blue Piece can Move 2 spaces in any direction");
                    
                }
                else
                {
                    Debug.Log("Blue Piece can Move 1 space in any direction");
                    
                }
            }
            else if (pieceColor == PieceColor.Yellow)
            {
                // Yellow piece movement logic
                if (zoneManager.IsInZone(transform.gameObject, ZoneType.Yellow))
                {
                    Debug.Log("Yellow Piece can Move 2 spaces in any direction");
                    
                }
                else
                {
                    Debug.Log("Yellow Piece can move 1 space in any direction");
                    
                }
            }
        }
    }
}
/*public enum PieceType
{
    Circle,
    Triangle
}

private enum PieceColor
{
    Pink,
    Blue,
    Yellow
}

private PieceColor GetPieceColor(GameObject pieceObject)
{
    if (pieceObject.CompareTag("Pink"))
    {
        return PieceColor.Pink;
    }
    else if (pieceObject.CompareTag("Blue"))
    {
        return PieceColor.Blue;
    }
    else if (pieceObject.CompareTag("Yellow"))
    {
        return PieceColor.Yellow;
    }
    return PieceColor.Pink; // Default to Pink for demonstration
}

private ZoneManager zoneManager;

private void Start()
{
    // Get a reference to the ZoneManager instance
    zoneManager = FindObjectOfType<ZoneManager>();
}

public void OnEndDrag(PointerEventData eventData)
{
    if (transform.childCount == 0)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggablePiece draggablepiece = dropped.GetComponent<DraggablePiece>();
        draggablepiece.parentAfterDrag = transform;
        PieceColor pieceColor = GetPieceColor(dropped);

        // Check piece color and zone color for movement restrictions
        if (pieceColor == PieceColor.Pink)
        {
            // Pink piece movement logic
            if (zoneManager.IsInZone(transform.gameObject, ZoneType.Pink))
            {
                Debug.Log("Pink Piece can Move 2 spaces in any direction");


            }
            else
            {
                Debug.Log("Pink Piece can Move 1 space in any direction");

            }
        }
        else if (pieceColor == PieceColor.Blue)
        {
            // Blue piece movement logic
            if (zoneManager.IsInZone(transform.gameObject, ZoneType.Blue))
            {
                Debug.Log("Blue Piece can Move 2 spaces in any direction");

            }
            else
            {
                Debug.Log("Blue Piece can Move 1 space in any direction");

            }
        }
        else if (pieceColor == PieceColor.Yellow)
        {
            // Yellow piece movement logic
            if (zoneManager.IsInZone(transform.gameObject, ZoneType.Yellow))
            {
                Debug.Log("Yellow Piece can Move 2 spaces in any direction");
            }


            else
            {
                Debug.Log("Yellow Piece can move 1 space in any direction");

            }
            }
        }
    }
}*/


/*public enum PieceType
{
    Circle,
    Triangle

}
public enum ZoneType
{
    Pink,
    Blue,
    Yellow,
    Intersections,
    Whitezone
}
public void OnDrop(PointerEventData eventData)
{
    if (transform.childCount == 0)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggablePiece draggedPiece = dropped.GetComponent<DraggablePiece>();

        // Check piece type and zone for movement restrictions
        if (draggedPiece.pieceType == PieceType.Circle)
        {
            // Get the current position of the circle piece
            int currentX = (int)dropped.transform.position.x;
            int currentY = (int)dropped.transform.position.y;

            // Calculate the valid movement positions for the circle piece
            List<Vector3> validPositions = new List<Vector3>();
            for (int x = currentX - 2; x <= currentX + 2; x++)
            {
                for (int y = currentY - 2; y <= currentY + 2; y++)
                {
                    // Check if the position is within the valid movement range
                    if (Mathf.Abs(x - currentX) + Mathf.Abs(y - currentY) <= 2)
                    {
                        // Check if the target position is within the game board
                        if (x >= 0 && x < 8 && y >= 0 && y < 8)
                        {
                            // Get the grid cell at the target position
                            GameObject targetCell = GameObject.Find("GridCell_" + x + "_" + y);
                            Debug.Log("targetCell");
                            if (targetCell != null && targetCell.transform.childCount == 0)
                            {
                                // Add the valid position to the list
                                validPositions.Add(targetCell.transform.position);
                            }
                        }
                    }
                }
            }

            // Check if the dropped position is a valid movement position for the circle piece
            if (validPositions.Contains(transform.position))
            {
                // Move the piece to the new position
                dropped.transform.position = transform.position;
                draggedPiece.parentAfterDrag = transform;
            }
        }
        else if (draggedPiece.pieceType == PieceType.Triangle)
        {
            // Get the current position of the triangle piece
            int currentX = (int)dropped.transform.position.x;
            int currentY = (int)dropped.transform.position.y;

            // Calculate the valid movement positions for the triangle piece
            List<Vector3> validPositions = new List<Vector3>();
            for (int x = currentX - 1; x <= currentX + 1; x++)
            {
                for (int y = currentY - 1; y <= currentY + 1; y++)
                {
                    // Check if the target position is within the game board
                    if (x >= 0 && x < 8 && y >= 0 && y < 8)
                    {
                        // Get the grid cell at the target position
                        GameObject targetCell = GameObject.Find("GridCell_" + x + "_" + y);
                        if (targetCell != null && targetCell.transform.childCount == 0 && targetCell.CompareTag("HeartZone"))
                        {
                            // Add the valid position to the list
                            validPositions.Add(targetCell.transform.position);
                        }
                    }
                }
            }

            // Check if the dropped position is a valid movement position for the triangle piece
            if (validPositions.Contains(transform.position))
            {
                // Move the piece to the new position
                dropped.transform.position = transform.position;
                draggedPiece.parentAfterDrag = transform;
            }
        }
    }
}*/

/* public enum PieceType
 {
     Circle,
     Triangle
     // Add any other piece types as needed
 }
 public enum ZoneType
 {
     Pink,
     Blue,
     Yellow,
     Intersections,
     Whitezone
 }


 public void OnDrop(PointerEventData eventData)
 {
     if (transform.childCount == 0)
     {
         GameObject dropped = eventData.pointerDrag;
         DraggablePiece draggedPiece = dropped.GetComponent<DraggablePiece>();

         // Check piece type and zone for movement restrictions
         if (draggedPiece.pieceType == PieceType.Circle)
         {
             // Apply movement rules for Circle pieces based on zones
             if (draggedPiece.currentZone == ZoneType.Pink || draggedPiece.currentZone == ZoneType.Blue || draggedPiece.currentZone == ZoneType.Yellow)
             {
                 // Implement movement logic for Circle pieces within their own zone
             }
             else
             {
                 // Implement movement logic for Circle pieces outside their zone
             }
         }
         else if (draggedPiece.pieceType == PieceType.Triangle)
         {
             // Apply movement rules for Triangle pieces within the heart zone
             if (draggedPiece.currentZone == ZoneType.Pink || draggedPiece.currentZone == ZoneType.Blue || draggedPiece.currentZone == ZoneType.Yellow)
             {
                 // Implement movement logic for Triangle pieces within the heart zone
             }
         }

         draggedPiece.parentAfterDrag = transform;
     }
 }*/

