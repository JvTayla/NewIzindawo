using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void CameraBluePosition()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 120f);
    }
    public void CameraPinkPosition()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 240f);
    }
    public void CameraYellowPosition()
    {
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }
}
