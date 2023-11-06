using TMPro;
using UnityEngine;

public class Initiation : MonoBehaviour
{
    public TextMeshProUGUI timeText;//Text donde se mostrará la cuenta regresiva
    private float num = 5;//Valor inicial
    public static float time;//Variable para la cuenta regresiva
    public GameObject count;//Objeto que contiene este script
    public GameObject spawn;//Objeto Spawn
    public static bool ban = false;//Variable de inicialización


    private void Awake()//Al iniciar
    {
        time = num;//Se le coloca el valor inicial a Time
    }

    void Update()//Se actualiza en cada frame
    {
        if (ban)//Si ban es true
        {
            time -= Time.deltaTime;//Se le resta 1 a time cada segundo
            timeText.text = "" + time.ToString("f0");//Se muestra el valor de time
            if (time < 0)//Si time es menor a 0
            {
                Timer.In++;//Se suma 1 a la variable In de Timer
                Instantiate(spawn);//Se instancia Spawn
                ban = false;//Ban regresa a ser false
                Destroy(count);//Se destruye count
            }
        }
    }
}
