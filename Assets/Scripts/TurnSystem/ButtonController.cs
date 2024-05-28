using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public TurnController gameScript;
    public GameObject blueButton;
    private void Start()
    {
        blueButton.SetActive(true);
        gameScript = GameObject.FindGameObjectWithTag("TurnController").GetComponent<TurnController>();
    }
    public void BluebuttonPress()
    {
        gameScript.PinkStink();
    }
    public void YellowbuttonPress()
    {
        gameScript.BluesClues();
    }

    public void PinkbuttonPress()
    {
        gameScript.YellowMellow();
    }
}