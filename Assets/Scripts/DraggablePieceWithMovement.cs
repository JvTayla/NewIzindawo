using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggablePieceWithMovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public float detectionRadius = 1f; // Adjust the detection radius as needed
    public LayerMask layerMask; // Specify the layers to detect objects on

    private List<GameObject> surroundingCells = new List<GameObject>();
    private Transform parentAfterDrag;
    public Image image;

    public GridCellSlot.PieceType pieceType;
    public ZoneManager.ZoneType currentZone;

    private void Start()
    {
        DetectSurroundingCells();
        image = GetComponent<Image>();
    }

    private void DetectSurroundingCells()
    {
        surroundingCells.Clear();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, layerMask);

        foreach (Collider2D collider in colliders)
        {
            GameObject cell = collider.gameObject;

            if (cell != this.gameObject && (cell.CompareTag("BlueGridCells") || cell.CompareTag("IntersectionCells") || cell.CompareTag("PinkGridCells") || cell.CompareTag("BlankCells") || cell.CompareTag("YellowGridCells")))
            {
                surroundingCells.Add(cell);
            }
        }
    }

    public bool CanMoveTo(GameObject targetCell)
    {
        return surroundingCells.Contains(targetCell);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
