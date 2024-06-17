using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int BlueScore = 0;
    public int PinkScore = 0;
    public int YellowScore = 0;

    public TMP_Text blueText;
    public TMP_Text pinkText;
    public TMP_Text yellowText;
    void Update()
    {
        blueText.text = BlueScore.ToString();
        pinkText.text = PinkScore.ToString();
        yellowText.text = YellowScore.ToString();

        if (BlueScore == 2)
        {
            SceneManager.LoadScene("BlueWinsScene");
        }
        else if (PinkScore == 2)
        {
            SceneManager.LoadScene("PinkWinsScene");
        }
        else if (YellowScore == 2)
        {
            SceneManager.LoadScene("YellowWinsScene");
        }
    }
}
