using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridCellSlot;
using UnityEngine.EventSystems;

public class RestrictionMovementTest : MonoBehaviour
{
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
    }
}
