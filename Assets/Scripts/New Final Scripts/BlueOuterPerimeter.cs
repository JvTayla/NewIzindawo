using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueOuterPerimeter : MonoBehaviour
{
    public GameObject blueSlot;
    public ScoreController scoreController;

    public void Update()
    {
        if (blueSlot.transform.childCount > 0)
        {
            if (blueSlot.transform.GetChild(0).CompareTag("Pink"))
            {
                DestroyImmediate(blueSlot.transform.GetChild(0).gameObject);
                scoreController.PinkScore = scoreController.PinkScore + 1;
            }
            else if (blueSlot.transform.GetChild(0).CompareTag("Yellow"))
            {
                DestroyImmediate(blueSlot.transform.GetChild(0).gameObject);
                scoreController.YellowScore = scoreController.YellowScore + 1;
            }
        }
    }
}
