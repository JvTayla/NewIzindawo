using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntersectionControllerRight : MonoBehaviour
{
    public GameObject rightButton;
    public TurnController turnController;
    public MovementController movementController;

    public GameObject pinkSpaces;
    public GameObject pinkSpaces2;
    public GameObject pinkSpaces3;

    public GameObject blueSpaces;
    public GameObject blueSpaces2;
    public GameObject blueSpaces3;

    public GameObject yellowSpaces;
    public GameObject yellowSpaces2;
    public GameObject yellowSpaces3;

    public GameObject intYPSpaces;
    public GameObject intYPSpaces2;
    public GameObject intYPSpaces3;

    public GameObject intBYSpaces;
    public GameObject intBYSpaces2;
    public GameObject intBYSpaces3;

    public GameObject intPBSpaces;
    public GameObject intPBSpaces2;
    public GameObject intPBSpaces3;

    public GameObject RightCirc;
    public GameObject PinkSpawn;
    public GameObject YellowSpawn;
    public GameObject blueSpawn;

    void Update()
    {
        if (turnController.state == GameStates.YellowState)
        {
            if (yellowSpaces.transform.childCount == 1 && yellowSpaces2.transform.childCount == 1 && pinkSpaces3.transform.childCount == 1 && intYPSpaces.transform.childCount == 0 && intYPSpaces2.transform.childCount == 0 && intYPSpaces3.transform.childCount == 0)
            {
                RightCirc.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                RightCirc.GetComponent<SpriteRenderer>().color = Color.red;
            }
            rightButton.GetComponent<Image>().color = Color.yellow;
        }
        else if (turnController.state == GameStates.BlueState)
        {
            if (blueSpaces.transform.childCount == 1 && blueSpaces2.transform.childCount == 1 && blueSpaces3.transform.childCount == 1 && intBYSpaces.transform.childCount == 0 && intBYSpaces2.transform.childCount == 0 && intBYSpaces3.transform.childCount == 0)
            {
                RightCirc.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                RightCirc.GetComponent<SpriteRenderer>().color = Color.red;
            }
            rightButton.GetComponent<Image>().color = Color.blue;
        }

        else if (turnController.state == GameStates.PinkState)
        {
            if (pinkSpaces.transform.childCount == 1 && pinkSpaces2.transform.childCount == 1 && pinkSpaces3.transform.childCount == 1 && intPBSpaces.transform.childCount == 0 && intPBSpaces2.transform.childCount == 0 && intPBSpaces3.transform.childCount == 0)
            {
                RightCirc.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                RightCirc.GetComponent<SpriteRenderer>().color = Color.red;
            }
            rightButton.GetComponent<Image>().color = Color.magenta;
        }
    }

    public void RightButtonPress()
    {
        if (turnController.state == GameStates.PinkState)
        {
            if (pinkSpaces.transform.childCount == 1 && pinkSpaces2.transform.childCount == 1 && pinkSpaces3.transform.childCount == 1 && intYPSpaces.transform.childCount == 0 && intYPSpaces2.transform.childCount == 0 && intYPSpaces3.transform.childCount == 0)
            {
                movementController.circleMove = 0;
                DestroyImmediate(pinkSpaces.transform.GetChild(0).gameObject);
                DestroyImmediate(pinkSpaces2.transform.GetChild(0).gameObject);
                DestroyImmediate(pinkSpaces3.transform.GetChild(0).gameObject);
                Instantiate(PinkSpawn, intYPSpaces.transform);
                Instantiate(PinkSpawn, intYPSpaces2.transform);
                Instantiate(PinkSpawn, intYPSpaces3.transform);
            }
        }
        else if (turnController.state == GameStates.BlueState)
        {
            if (blueSpaces.transform.childCount == 1 && blueSpaces2.transform.childCount == 1 && blueSpaces3.transform.childCount == 1 && intPBSpaces.transform.childCount == 0 && intPBSpaces2.transform.childCount == 0 && intPBSpaces3.transform.childCount == 0)
            {
                movementController.circleMove = 0;
                DestroyImmediate(blueSpaces.transform.GetChild(0).gameObject);
                DestroyImmediate(blueSpaces2.transform.GetChild(0).gameObject);
                DestroyImmediate(blueSpaces3.transform.GetChild(0).gameObject);
                Instantiate(blueSpawn, intPBSpaces.transform);
                Instantiate(blueSpawn, intPBSpaces2.transform);
                Instantiate(blueSpawn, intPBSpaces3.transform);
            }
        }
        else if (turnController.state == GameStates.YellowState)
        {
            if (yellowSpaces.transform.childCount == 1 && yellowSpaces2.transform.childCount == 1 && pinkSpaces3.transform.childCount == 1 && intBYSpaces.transform.childCount == 0 && intBYSpaces2.transform.childCount == 0 && intBYSpaces3.transform.childCount == 0)
            {
                movementController.circleMove = 0;
                DestroyImmediate(yellowSpaces.transform.GetChild(0).gameObject);
                DestroyImmediate(yellowSpaces2.transform.GetChild(0).gameObject);
                DestroyImmediate(yellowSpaces3.transform.GetChild(0).gameObject);
                Instantiate(YellowSpawn, intBYSpaces.transform);
                Instantiate(YellowSpawn, intBYSpaces2.transform);
                Instantiate(YellowSpawn, intBYSpaces3.transform);
            }
        }
    }
}
