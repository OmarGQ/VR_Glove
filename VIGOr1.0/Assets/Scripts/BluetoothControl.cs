using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class BluetoothControl : MonoBehaviour
{
    private AndroidJavaClass javaClass;
    private AndroidJavaObject javaObject;
    public Text text1;
    public Transform cube;
    private StackTrace ster;
    private float realStateX = 0.0f;
    private float realStateY = 0.0f;
    private float realStateZ = 0.0f;
    private float outputDataX = 0.0f;
    private float prevOutputDataX = 0.0f;
    private float unfilteredPreviousX = 0.0f;
    private float outputDataY = 0.0f;
    private float prevOutputDataY = 0.0f;
    private float unfilteredPreviousY = 0.0f;
    private float outputDataZ = 0.0f;
    private float prevOutputDataZ = 0.0f;
    private float unfilteredPreviousZ = 0.0f;
    private float currentHighestValue = 0.0f;
    private float vI = 0.0f;
    private float vF = 0.0f;
    private float time = 0.0f;
    private float g = 0.0f;
    private string[] splitString;
    private String isConnected = "";
    private float a = 0.0f;
    const float ACCELERATION_RC_CONSTANT = 30.0f;
    private bool weOnlyGoBackwards = false;

    void Start()
    {
        try {
            UnityEngine.Debug.Log("HOLA");
                javaClass = new AndroidJavaClass("com.dugh.unitybluetooth.BluetoothConnector");
                javaObject = javaClass.CallStatic<AndroidJavaObject>("getInstance");
                UnityEngine.Debug.Log(javaObject.Call<string>("BluetoothConnect"));
                text1.text = "Conectado!";
        } catch (Exception ex) {
            UnityEngine.Debug.Log("DESCOMPOSTURA DE TIPO START");
            UnityEngine.Debug.Log(ex.ToString());
        }
        text1.text = "Conectado!";
    }
    // Update is called once per frame
    void Update()
    {
        try {
            if (javaObject.Call<string>("ReadData").Length > 1) {
                UnityEngine.Debug.Log(javaObject.Call<string>("ReadData"));
                if (javaObject.Call<string>("ReadData").StartsWith("%"))
                {
                    splitString = javaObject.Call<string>("ReadData").Split('#');
                    splitString[0] = splitString[0].Substring(1);

                    /*forceX = cube.mass * float.Parse(splitString[4]);
                    forceY = cube.mass * float.Parse(splitString[6]);
                    forceZ = cube.mass * float.Parse(splitString[5]);

                    cube.AddForce(new Vector3(forceX, forceY, forceZ), ForceMode.Force);
                    cube.MoveRotation(new Quaternion(float.Parse(splitString[0]), float.Parse(splitString[1]), float.Parse(splitString[2]), float.Parse(splitString[3])));
                    text1.text = cube.rotation.ToString();*/
                    //UnityEngine.Debug.Log(javaObject.Call<string>("ReadData") + "Longitud: " + splitString.Length);
                    //time = float.Parse(splitString[7]) / 1000000; ;
                    time = 0.10f;
                    a = ACCELERATION_RC_CONSTANT / (ACCELERATION_RC_CONSTANT + time);
                    outputDataX = (a * (prevOutputDataX + (float.Parse(splitString[4]) - unfilteredPreviousX))) * (9.81f / 16384);
                    prevOutputDataX = outputDataX;
                    unfilteredPreviousX = float.Parse(splitString[4]);
                    outputDataY = (a * (prevOutputDataY + (float.Parse(splitString[6]) - unfilteredPreviousY))) * (9.81f / 16384);
                    prevOutputDataY = outputDataY;
                    unfilteredPreviousY = float.Parse(splitString[6]);
                    outputDataZ = (a * (prevOutputDataZ + (float.Parse(splitString[5]) - unfilteredPreviousZ))) * (9.81f / 16384);
                    prevOutputDataZ = outputDataZ;
                    unfilteredPreviousZ = float.Parse(splitString[5]);
                    realStateX = ((outputDataX / 2) * (time * time)) * -10;
                    realStateY = ((outputDataY / 2) * (time * time)) * -10;
                    realStateZ = ((outputDataZ / 2) * (time * time)) * 2000;
                    /*if(realStateX < 1.00f && realStateX > -1.00f)
                    {
                        realStateX = 0;
                    }
                    if(realStateY < 1.00f && realStateY > -1.00f)
                    {
                        realStateY = 0;
                    }
                    if(realStateZ < 1.00f && realStateZ > -1.00f)
                    {
                        realStateZ = 0;
                    }*/
                    cube.rotation = Quaternion.Slerp(cube.rotation, new Quaternion(float.Parse(splitString[1]), float.Parse(splitString[2]), float.Parse(splitString[3]), float.Parse(splitString[0])), 0.5f);
                    if (realStateX <= prevOutputDataX && weOnlyGoBackwards == false)
                    {
                        text1.text = realStateX + " " + realStateY + " " + realStateZ + "\n";
                        cube.position = Vector3.Lerp(cube.position, new Vector3(cube.position.x + realStateX, cube.position.y, 0.0f), 0.5f);
                    } else
                    {
                        weOnlyGoBackwards = true;
                    }
                    if (realStateY <= prevOutputDataY && weOnlyGoBackwards == false)
                    {
                        text1.text = realStateX + " " + realStateY + " " + realStateZ + "\n";
                        cube.position = Vector3.Lerp(cube.position, new Vector3(cube.position.x, cube.position.y + realStateY, 0.0f), 0.5f);
                    }else
                    {
                        weOnlyGoBackwards = true;
                     }                    
                    if (weOnlyGoBackwards == true)
                    {
                        prevOutputDataX = cube.position.x;
                        prevOutputDataY = cube.position.y;
                    }
                    if(float.Parse(splitString[0]) > 300 && float.Parse(splitString[0]) < 300)
                    {
                        realStateX = 0;
                        weOnlyGoBackwards = false;
                    }
                    UnityEngine.Debug.Log(prevOutputDataX);
                    prevOutputDataY = cube.position.y;
                    prevOutputDataX = cube.position.x;
                }
            }       
        }catch (Exception ex) {
            ster = new StackTrace(ex, true);
            UnityEngine.Debug.Log("DESCOMPOSTURA DE TIPO Update");
            UnityEngine.Debug.Log("De aqui vino el chamaco, " + ex.Message + " STACK " + ex.StackTrace);
        }
    }
}
