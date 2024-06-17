using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementController : MonoBehaviour
{
    public int circleMove = 0;
    public int triangleMove = 0;
    public int turnNumber = 0;

    public TMP_Text circNum;
    public TMP_Text triNum;

    private void Update()
    {
        circNum.text = circleMove.ToString();
        triNum.text = triangleMove.ToString();

        if (circleMove == 0)
        {
            triangleMove = 0;
        }
    }
}
