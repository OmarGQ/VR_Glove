using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject dartboard; //Objetos que utilizara
    public GameObject duck;
    public GameObject clock;
    private float BTime = 1;//variables de tiempo del dartboard
    private float BDelay = 1;

    void Start()
    {
        //Se inician los métodos que se encargaran de la creación de los objetos
        //El primer campo es el método, el segundo es el tiempo de creación 
        //y el tercero es el tiempo de pausa antes de reiniciar el método
        InvokeRepeating("Duck", Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f));
        InvokeRepeating("DartBoard", BTime, BDelay);
        InvokeRepeating("Clock", Random.Range(1.0f, 10.0f), Random.Range(3.0f, 7.0f));
    }
    
    public void Duck()//Creación de patos
    {
        Quaternion rot;//Valores de rotación
        Vector3 pos;//Valores de posición
        if (Random.Range(0.0f, 10.0f) > 5.0f)//Se obtiene un valor aleatorio y si es menor a 5
        {
            rot = Quaternion.Euler(new Vector3(-90, 180, -90));//Se asignan los valores de rotación
            pos = new Vector3(-9, 1, Random.Range(8.0f, 12.0f));//Se asignan los valores de posición
        }
        else
        {
            rot = Quaternion.Euler(new Vector3(-90, 180, 90));//Se asignan los valores de rotación
            pos = new Vector3(9, 1, Random.Range(8.0f, 12.0f));//Se asignan los valores de posición
        }
        Instantiate(duck, pos, rot);//Instancia el objeto
    }

    public void DartBoard()//Creación de dartboards
    {
        Vector3 pos;//Valores de posición
        Quaternion rot = Quaternion.Euler(new Vector3(0, 180, 0));//Se asignan los valores de rotación
        if (Random.Range(0.0f, 10.0f) > 5.0f)//Se obtiene un valor aleatorio y si es menor a 5
        {
            pos = new Vector3(-9, Random.Range(4.0f, 8.0f), 17);//Se asignan los valores de posición
        }
        else
        {
            pos = new Vector3(9, Random.Range(2.0f, 6.0f), 14);//Se asignan los valores de posición
        }
        Instantiate(dartboard, pos, rot);//Instancia el objeto
    }

    public void Clock()//Creación de relojes
    {
        Vector3 pos;// Valores de posición
        Quaternion rot = Quaternion.Euler(new Vector3(-180, 0, 0));//Se asignan los valores de rotación
        if (Random.Range(0.0f, 10.0f) > 5.0f)//Se obtiene un valor aleatorio y si es menor a 5
        {
            pos = new Vector3(-9, Random.Range(2.0f, 6.0f), 15);//Se asignan los valores de posición
        }
        else
        {
            pos = new Vector3(9, Random.Range(2.0f, 6.0f), 12);//Se asignan los valores de posición
        }
        Instantiate(clock, pos, rot);//Instancia el objeto
    }
}
