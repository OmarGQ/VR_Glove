using UnityEngine;

public class Camer4 : MonoBehaviour
{
    public GameObject ship;       //Public variable to store a reference to the player game object
    private Vector3 offset, last;         //Private variable to store the offset distance between the player and camera
    double z = 0.000f, x = 0.000f;
    private Quaternion rotate, value;
    public GameObject CLeft, CRight;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = new Vector3(0, 4, -13);
        value = Quaternion.Euler(new Vector3(0, 180, 0));
        rotate = ship.transform.rotation;
        Vector3 last = value.eulerAngles + rotate.eulerAngles;
        CLeft.transform.rotation = Quaternion.Euler(last);
        CRight.transform.rotation = Quaternion.Euler(last);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (GameObject.FindObjectOfType<Ship>() == null)
        {

        }
        else
        {
            float Ay = ship.transform.transform.eulerAngles.y;
            if (Ay <= 180)
            {
                z = 26-(Ay * 0.144);
                if(Ay > 0 && Ay < 90)
                {
                    x = Ay * 0.144;
                }
                else
                {
                    x = (Ay - 90) * 0.144;
                    x = 13 - x;
                }
            }
            else
            {
                z = (Ay - 180) * 0.144;
                if (Ay > 180 && Ay < 270)
                {
                    x = ((Ay - 180) * 0.144) * -1;
                }
                else
                {
                    x = ((Ay - 180) * 0.144) - 26;
                }
            }
            float variableZ = (float)z;
            float variableX = (float)x;
            last = new Vector3(variableX,0,variableZ);
            transform.position = ship.transform.position + offset + last;
        }
    }
}
