using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler 
{

    public Image image;
    private Transform parentAfterDrag;
    public GridCellSlot.PieceType pieceType;
    public ZoneManager.ZoneType currentZone;

    //private RectTransform rectTransform;
    private void Start()
    {
        parentAfterDrag = transform.parent;
    }

    //public void Awake()
    //{
    //    rectTransform = GetComponent<RectTransform>();
    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");

        // Convert screen position to world position
        Vector3 screenPos = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        // Set the position of the piece to the calculated world position
        transform.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        image.raycastTarget = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped on Grid Cell Slot");
        GridCellSlot gridCell = eventData.pointerEnter.GetComponent<GridCellSlot>();
        if (gridCell != null)
        {
            if (gridCell.transform.childCount == 0)
            {
                transform.SetParent(gridCell.transform);
                transform.localPosition = Vector3.zero;
            }
            else
            {
                Debug.Log("Grid cell is not empty.");
                // Handle the case when the grid cell is not empty
            }
        }
        else
        {
            // If dropped outside the grid, return the piece to its original position
            transform.SetParent(parentAfterDrag);
            transform.localPosition = Vector3.zero;
        }
    }


    /*public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public GridCellSlot.PieceType pieceType; 
    public ZoneManager.ZoneType currentZone;



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

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

    }*/
}
