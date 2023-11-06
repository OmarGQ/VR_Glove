using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using System;

public class bluetoothData : MonoBehaviour
{
    private AndroidJavaClass javaClass;
    public static AndroidJavaObject javaObject;
    private Ship nave;
    public Transform cube;
    private StackTrace ster;
    private string[] splitString;
    private Quaternion nRotation;
    private Vector3 nEulerRotation;
    private Vector3 Acc;
    public Text text3;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        try
        {
            UnityEngine.Debug.Log("HOLA");
            javaClass = new AndroidJavaClass("com.dugh.unitybluetooth.BluetoothConnector");
            javaObject = javaClass.CallStatic<AndroidJavaObject>("getInstance");
            javaObject.Call<string>("BluetoothConnect");
            javaObject.SetStatic<string>("BTname", "HC-05");
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.Log("DESCOMPOSTURA DE TIPO START");
            UnityEngine.Debug.Log(ex.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            //text3.text = javaObject.Call<string>("BTState");
            if (javaObject.Call<string>("ReadData").Length > 1)
            {
                if (javaObject.Call<string>("ReadData").StartsWith("%"))
                {
                    splitString = javaObject.Call<string>("ReadData").Split('#');
                    splitString[0] = splitString[0].Substring(1);
                    nRotation = new Quaternion(float.Parse(splitString[2]), float.Parse(splitString[3]), float.Parse(splitString[1]), float.Parse(splitString[0]));
                    nEulerRotation = nRotation.eulerAngles;
                    nEulerRotation.y += 210;
                    cube.rotation = Quaternion.Lerp(cube.rotation, Quaternion.Euler(nEulerRotation.x, nEulerRotation.y * -1, nEulerRotation.z), 0.5f);
                    Acc = new Vector3(float.Parse(splitString[5]) * (9.81f / 16384), float.Parse(splitString[6]) * (9.81f / 16384), float.Parse(splitString[4]) * (9.81f / 16384));
                    if (Acc.x < -9.00f)
                    {
                        Ship.speed =-80.0f;
                        //Como se le ponia el fast omr
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ster = new StackTrace(ex, true);
            UnityEngine.Debug.Log(ex.Message);
            UnityEngine.Debug.Log("DESCOMPOSTURA DE TIPO Update");
            UnityEngine.Debug.Log("De aqui vino el chamaco, " + ex.Message + " STACK " + ex.StackTrace);
        }
    }
}   