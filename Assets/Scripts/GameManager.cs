using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    

        private Vector3 originalPosition;

        void OnDrop(GameObject droppedPiece, GameObject targetCell)
        {
            DraggablePieceWithMovement pieceMovement = droppedPiece.GetComponent<DraggablePieceWithMovement>();

            if (pieceMovement.CanMoveTo(targetCell))
            {
                // Move the piece to the target cell
                Debug.Log("Valid Move");
                droppedPiece.transform.position = targetCell.transform.position;
            }
            else
            {
                // Invalid move, return the piece to its original position
                droppedPiece.transform.position = originalPosition;
                Debug.Log("Invalid Move");
            }
        }

    

}
