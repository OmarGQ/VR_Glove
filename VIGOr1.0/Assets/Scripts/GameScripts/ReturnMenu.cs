using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    private float num = 5;//Valor inicial
    public static float time;//Variable para la cuenta regresiva

    private void Awake()//Al iniciar
    {
        time = num;//Se le coloca el valor inicial a Time
    }

    void Update()//Se actualiza en cada frame
    {
        time -= Time.deltaTime;//Se le resta 1 a time cada segundo
        if (time < 0)//Si time es menor a 0
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);//Cambia de escena al Menú
        }
    }
}
