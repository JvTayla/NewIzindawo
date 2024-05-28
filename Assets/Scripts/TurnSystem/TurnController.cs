using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using TMPro;


public class TurnController : MonoBehaviour
{
    public GameState state;
    public CameraController CamScript;
    public CountdownController TimeScript;
    public DraggablePiece draggablePiece;

    public int hasRun = 45;
    public string EndScene;
    
    public int BlueScore = 0;
    public int YellowScore = 0;
    public int PinkScore = 0;

    public TextMeshProUGUI blueText;
    public TextMeshProUGUI yellowText;
    public TextMeshProUGUI pinkText;

    private void Awake()
    {
        CamScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        TimeScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<CountdownController>();
        draggablePiece = GameObject.FindGameObjectWithTag("Pink").GetComponent<DraggablePiece>();

        state = GameState.BlueState;
    }


    void Start()
    {
        StartCoroutine(BluesClues());
    }

    public void Update()
    {
        blueText.text = BlueScore.ToString();
        yellowText.text = YellowScore.ToString();
        pinkText.text = PinkScore.ToString();

        if (BlueScore == 2 || PinkScore == 2 || YellowScore == 2)
        {
            SceneManager.LoadScene(EndScene);
        }
    }
    public IEnumerator BluesClues()
    {
        if (hasRun > 0)
        {
            CamScript.CameraPosJuan();
            TimeScript.countdownTimer();
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 45;
        draggablePiece.enabled = !draggablePiece.enabled;
        state = GameState.YellowState;
        StartCoroutine(YellowMellow());
    }
    public IEnumerator YellowMellow()
    {
        if (hasRun > 0)
        {
            CamScript.CameraPosDos();
            TimeScript.countdownTimer();
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 30;
        state = GameState.YellowState;
        StartCoroutine(PinkStink());
    }
    public IEnumerator PinkStink()
    {
        if (hasRun > 0)
        {
            CamScript.CameraPosTres();
            TimeScript.countdownTimer();
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 45;
        state = GameState.PinkState;
    }
}
public enum GameState
{
    BlueState, PinkState, YellowState
}
