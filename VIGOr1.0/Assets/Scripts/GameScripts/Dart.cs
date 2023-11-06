using UnityEngine;

public class Dart : MonoBehaviour
{
    private void Update()//Actualización en cada frame
    {
        if (this.transform.position.y < -1)//Si su posición en y es menor a 1
        {
            Destroy(this.gameObject);//Se destruye
        }
    }
}
