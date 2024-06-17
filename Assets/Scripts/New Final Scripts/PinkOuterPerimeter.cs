using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkOuterPerimeter : MonoBehaviour
{
    public GameObject pinkSlot;
    public ScoreController scoreController;


    public void Update()
    {
        if (pinkSlot.transform.childCount > 0)
        {
            if (pinkSlot.transform.GetChild(0).CompareTag("Blue"))
            {
                DestroyImmediate(pinkSlot.transform.GetChild(0).gameObject);
                scoreController.BlueScore = scoreController.BlueScore + 1;
            }
            else if (pinkSlot.transform.GetChild(0).CompareTag("Yellow"))
            {
                DestroyImmediate(pinkSlot.transform.GetChild(0).gameObject);
                scoreController.YellowScore = scoreController.YellowScore + 1;
            }
        }

    }
}
