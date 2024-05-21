using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridCellSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    { if (transform.childCount == 0)
        { 
        GameObject dropped = eventData.pointerDrag;
        DraggablePiece draggedPiece = dropped.GetComponent<DraggablePiece>();
        draggedPiece.parentAfterDrag = transform;
        }
    }
}
