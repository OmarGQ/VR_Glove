using UnityEngine;

public class Destroid : MonoBehaviour
{
    public GameObject effectXL;//Timos de meteoros
    public GameObject effectXXX;
    public GameObject effectXX;
    public GameObject effectX;

    public void DestroidXL(Vector3 position)//Obtiene la posicion de la diana destruida
    {
        Instantiate(effectXL, position, Quaternion.identity);//Crea una animación en la posición de la diana
    }
    public void DestroidXXX(Vector3 position)//Obtiene la posicion de la diana destruida
    {
        Instantiate(effectXXX, position, Quaternion.identity);//Crea una animación en la posición de la diana
    }
    public void DestroidXX(Vector3 position)//Obtiene la posicion de la diana destruida
    {
        Instantiate(effectXX, position, Quaternion.identity);//Crea una animación en la posición de la diana
    }
    public void DestroidX(Vector3 position)//Obtiene la posicion de la diana destruida
    {
        Instantiate(effectX, position, Quaternion.identity);//Crea una animación en la posición de la diana
    }
}
