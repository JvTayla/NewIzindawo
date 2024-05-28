using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YlwPerimeter : MonoBehaviour
{
    public GameObject ylwSlot;
    public TurnController turnController;
    

    public void Update()
    {
            if (ylwSlot.transform.childCount > 0)
            {
                if (ylwSlot.transform.GetChild(0).CompareTag("Blue"))
                {
                DestroyImmediate(ylwSlot.transform.GetChild(0).gameObject);
                turnController.BlueScore = turnController.BlueScore + 1;
                }
                else if (ylwSlot.transform.GetChild(0).CompareTag("Pink"))
                {
                DestroyImmediate(ylwSlot.transform.GetChild(0).gameObject);
                turnController.PinkScore = turnController.PinkScore + 1;
            }
        }

    }
}
