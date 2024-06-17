using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public int countdownTime;
    [SerializeField]
    public TMP_Text countdownDisplay;
    public void CountdownTimer()
    {
        countdownTime = 35;
        countdownDisplay.gameObject.SetActive(true);
        StartCoroutine(CountdownToNextTurn());
    }
    IEnumerator CountdownToNextTurn()
    {
        while (countdownTime > -1)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.gameObject.SetActive(false);
    }
}
