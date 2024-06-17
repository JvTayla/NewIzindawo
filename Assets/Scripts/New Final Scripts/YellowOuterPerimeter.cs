using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowOuterPerimeter : MonoBehaviour
{
    public GameObject yellowSlot;
    public ScoreController scoreController;


    public void Update()
    {
        if (yellowSlot.transform.childCount > 0)
        {
            if (yellowSlot.transform.GetChild(0).CompareTag("Blue"))
            {
                DestroyImmediate(yellowSlot.transform.GetChild(0).gameObject);
                scoreController.BlueScore = scoreController.BlueScore + 1;
            }
            else if (yellowSlot.transform.GetChild(0).CompareTag("Pink"))
            {
                DestroyImmediate(yellowSlot.transform.GetChild(0).gameObject);
                scoreController.PinkScore = scoreController.PinkScore + 1;
            }
        }

    }
}
