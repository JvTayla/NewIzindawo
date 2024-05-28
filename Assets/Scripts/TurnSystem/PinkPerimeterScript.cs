using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinkPerimeterScript : MonoBehaviour
{
    public GameObject pinkSlot;
    public TurnController turnController;
    

    public void SellDatBook()
    {
            if (pinkSlot.transform.childCount > 0)
            {
                if (pinkSlot.transform.GetChild(0).CompareTag("Blue"))
                {
                DestroyImmediate(pinkSlot.transform.GetChild(0).gameObject);
                turnController.BlueScore = turnController.BlueScore + 1;
                }
                else if (pinkSlot.transform.GetChild(0).CompareTag("Yellow"))
                {
                DestroyImmediate(pinkSlot.transform.GetChild(0).gameObject);
                turnController.YellowScore = turnController.YellowScore + 1;
            }
        }

    }
}
