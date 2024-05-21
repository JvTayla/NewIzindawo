using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
<<<<<<< Updated upstream
    public enum PieceType
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
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public PieceType pieceType; // Enum to define piece type (Circle, Triangle, etc.)
    public ZoneType currentZone; // Enum to define current zone (Pink, Blue, Yellow, etc.)

=======
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
>>>>>>> Stashed changes
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
<<<<<<< Updated upstream
    }
=======

    } 
>>>>>>> Stashed changes
}
