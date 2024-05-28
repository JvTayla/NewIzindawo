using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    [SerializeField]
    public TextMeshProUGUI countdownDisplay;
    public void countdownTimer()
    {
        countdownTime = 45;
        countdownDisplay.gameObject.SetActive(true);
        StartCoroutine(CountdownToNextTurn());
    }
    IEnumerator CountdownToNextTurn()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }
}
