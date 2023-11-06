using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giroscope : MonoBehaviour
{
    public GameObject VrCamera;
    private float StartY = 0f;
    private float PositionY = 0f;
    private float CalibrateY = 0f;
    public bool GameStart;

    void Start()
    {
        Input.gyro.enabled = true; //si hay un dispositivo androis=d con giroscopio
        StartY = VrCamera.transform.eulerAngles.y;
    }

    void Update()
    {
        AplicateRotation();
        AplicateCalibration();
        if(GameStart == true)
        {
            Invoke("CalibrateInY", 3f);
            GameStart = false;
        }
    }

    void AplicateRotation()
    {
        VrCamera.transform.rotation = Input.gyro.attitude;
        VrCamera.transform.Rotate(0f, 0f, 180f, Space.Self);
        VrCamera.transform.Rotate(90f, 180f, 0f, Space.World);
        PositionY = VrCamera.transform.eulerAngles.y;
    }

    void CalibrateInY()
    {
        CalibrateY = PositionY - StartY;
    }

    void AplicateCalibration()
    {
        VrCamera.transform.Rotate(0f, -CalibrateY, 0f, Space.World);
    }
}
