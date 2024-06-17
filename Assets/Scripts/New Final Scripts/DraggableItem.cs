using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentAfterDrag;
    public Transform parentBeforeDrag;
    public MovementController movementController;
    public Image image;
    public bool Triangle;
    public Vector3 startPos;
    public Vector3 endPos;
    public float distanceBetweenObjects;

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        parentBeforeDrag = transform.parent;
        transform.SetParent(transform.root);
        //image.raycastTarget = false;
        startPos = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Triangle == false)
        {
            transform.SetParent(parentAfterDrag);
            endPos = transform.parent.position;
            //image.raycastTarget = true;
            distanceBetweenObjects = Vector3.Distance(startPos, endPos);
            movementController.circleMove--;
        }
        else if (Triangle == true)
        {
            transform.SetParent(parentAfterDrag);
            endPos = transform.parent.position;
            //image.raycastTarget = true;
            distanceBetweenObjects = Vector3.Distance(startPos, endPos);
            movementController.triangleMove--;
        }

            if (distanceBetweenObjects > 123)
        { 
            transform.SetParent(parentBeforeDrag);
            movementController.circleMove++;
        }
        else if (Triangle == true && transform.parent.tag != "HeartZone")
        {
            transform.SetParent(parentBeforeDrag);
            movementController.triangleMove++;
        }
    }
}
