using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;//Text donde se mostrará el cronometro
    private float num = 20; //Valor inicial
    public static float time;//Variable del tiempo
    private Effect over;
    public static int In = 0;

    private void Awake()//Al iniciar
    {
        In = 0;//In se iguala a 0 ya que al ejecutarse por segunda vez el valor es 1
        time = num;//Se asigna el valor inicial a time
        over = GameObject.FindObjectOfType<Effect>();//Se busca el objeto Effect
    }

    void Update()//Se actualiza en cada frame
    {
        if (In == 1)//Si In es igual a 1 inicia el cronometro
        {
            time -= Time.deltaTime;//Se resta 1 a time cada segundo
            timeText.text = "" + time.ToString("f0");//Se muestra el valor de time
            if (time < 0)//Si time es menor a 0
            {
                over.GameOver();//Llama la función GameOver de Effect
                Destroy(this);//Se destruye
            }
        }
    }
}
