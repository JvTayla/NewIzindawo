using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.parentAfterDrag = transform;
        }
        else if (transform.childCount != 0 && !transform.GetChild(0).GetComponent<DraggableItem>().Triangle)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            if (draggableItem.Triangle)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
                //gameObject.transform.GetChild(0).gameObject.SetActive(false);
                draggableItem.parentAfterDrag = transform;
            }
        }
    }
}
