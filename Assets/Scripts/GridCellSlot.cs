using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridCellSlot : MonoBehaviour, IDropHandler
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
    }
}
