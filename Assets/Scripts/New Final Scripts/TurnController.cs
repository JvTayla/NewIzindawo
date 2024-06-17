using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameStates
{
    BlueState, PinkState, YellowState
}

public class TurnController : MonoBehaviour
{
    public GameStates state;
    
    public TimerController TimeScript;
    public CameraController CameraController;
    public MovementController movementController;
    
    public int hasRun = 35;
    
    public GameObject playerTurn;
    public GameObject BlueButton;
    public GameObject PinkButton;
    public GameObject YellowButton;

    public GameObject[] pinkPieces;
    public GameObject[] yellowPieces;
    public GameObject[] bluePieces;


    void Start()
    {
        state = GameStates.BlueState;
        StartCoroutine(BlueTurn());
        pinkPieces = GameObject.FindGameObjectsWithTag("Pink");
        yellowPieces = GameObject.FindGameObjectsWithTag("Yellow");
        bluePieces = GameObject.FindGameObjectsWithTag("Blue");
    }

    void Update()
    {
        if (movementController.circleMove == 0 || movementController.triangleMove == 0)
        {
            foreach (GameObject obj in pinkPieces)
            {
                obj.GetComponent<DraggableItem>().enabled = false;
            }

            foreach (GameObject obj in yellowPieces)
            {
                obj.GetComponent<DraggableItem>().enabled = false;
            }

            foreach (GameObject obj in bluePieces)
            {
                obj.GetComponent<DraggableItem>().enabled = false;
            }
        }
        else if (movementController.circleMove > 0)
        {
            if (GameStates.BlueState == state)
            {
                foreach (GameObject obj in pinkPieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = false;
                }

                foreach (GameObject obj in yellowPieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = false;
                }

                foreach (GameObject obj in bluePieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = true;
                }
                PinkButton.SetActive(false);
                BlueButton.SetActive(true);
                YellowButton.SetActive(false);
            }
            else if (GameStates.YellowState == state)
            {
                foreach (GameObject obj in pinkPieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = false;
                }

                foreach (GameObject obj in yellowPieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = true;
                }

                foreach (GameObject obj in bluePieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = false;
                }
                PinkButton.SetActive(false);
                BlueButton.SetActive(false);
                YellowButton.SetActive(true);
            }
            else if (GameStates.PinkState == state)
            {
                foreach (GameObject obj in pinkPieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = true;
                }

                foreach (GameObject obj in yellowPieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = false;
                }

                foreach (GameObject obj in bluePieces)
                {
                    obj.GetComponent<DraggableItem>().enabled = false;
                }
                PinkButton.SetActive(true);
                BlueButton.SetActive(false);
                YellowButton.SetActive(false);
            }
        }
    }

    public IEnumerator BlueTurn()
    {
        if (hasRun > 0)
        {
            TimeScript.CountdownTimer();
            playerTurn.GetComponent<SpriteRenderer>().color = Color.blue;
            movementController.turnNumber++;
            CameraController.CameraBluePosition();
            if(movementController.turnNumber == 1)
            {
                movementController.circleMove = 4;
                movementController.triangleMove = 1;
            }
            else if (movementController.turnNumber > 1)
            {
                movementController.circleMove = 2;
                movementController.triangleMove = 1;
            }
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 35;
        state = GameStates.PinkState;
        StartCoroutine(PinkTurn());
    }
    public IEnumerator YellowTurn()
    {
        if (hasRun > 0)
        {
            playerTurn.GetComponent<SpriteRenderer>().color = Color.yellow;
            TimeScript.CountdownTimer();
            CameraController.CameraYellowPosition();
            if (movementController.turnNumber == 1)
            {
                movementController.circleMove = 4;
                movementController.triangleMove = 1;
            }
            else if (movementController.turnNumber > 1)
            {
                movementController.circleMove = 2;
                movementController.triangleMove = 1;
            }
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 35;
        state = GameStates.BlueState;
        StartCoroutine(BlueTurn());
    }
    public IEnumerator PinkTurn()
    {
        if (hasRun > 0)
        {
            playerTurn.GetComponent<SpriteRenderer>().color = Color.magenta;
            TimeScript.CountdownTimer();
            CameraController.CameraPinkPosition();
            if (movementController.turnNumber == 1)
            {
                movementController.circleMove = 4;
                movementController.triangleMove = 1;
            }
            else if (movementController.turnNumber > 1)
            {
                movementController.circleMove = 2;
                movementController.triangleMove = 1;
            }
        }
        while (hasRun > 0)
        {
            yield return new WaitForSeconds(1f);
            hasRun--;
        }
        yield return new WaitForSeconds(1f);
        hasRun = 35;
        state = GameStates.YellowState;
        StartCoroutine(YellowTurn());
    }

    public void BlueStartTurn()
    {
        state = GameStates.BlueState;
        StartCoroutine(BlueTurn());
    }

    public void PinkStartTurn()
    {
        state = GameStates.PinkState;
        StartCoroutine(PinkTurn());
    }

    public void YellowStartTurn()
    {
        state = GameStates.YellowState;
        StartCoroutine(YellowTurn());
    }
}