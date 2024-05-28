using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BluPerimeter : MonoBehaviour
{
    public GameObject blueSlot;
    public TurnController turnController;

    public void Update()
    {
            if (blueSlot.transform.childCount > 0)
            {
                if (blueSlot.transform.GetChild(0).CompareTag("Pink"))
                {
                DestroyImmediate(blueSlot.transform.GetChild(0).gameObject);
                turnController.PinkScore = turnController.PinkScore + 1;
                }
                else if (blueSlot.transform.GetChild(0).CompareTag("Yellow"))
                {
                DestroyImmediate(blueSlot.transform.GetChild(0).gameObject);
                turnController.YellowScore = turnController.YellowScore + 1;
            }
        }

    }



}
