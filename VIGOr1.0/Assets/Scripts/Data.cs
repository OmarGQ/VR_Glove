using UnityEngine;

public class Data : MonoBehaviour
{
    public static string userName = "";//Variable que guarda el nombre del usuario

    public void Awake()//Al iniciar la aplicación se declara como no destructible
    {
        DontDestroyOnLoad(gameObject);//El objeto no se destruirá al cambiar de escena
    }
}
