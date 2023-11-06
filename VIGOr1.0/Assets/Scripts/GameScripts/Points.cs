using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI ScoreBar = null;//Text que mostrara el puntaje
    private int num = 0;//Valor inicial
    public static int points;//Variable donde se almacenarán los puntos
    public bool coins = false;

    private void Awake()
    {
        points = num;//Restaura valor en 0 al iniciar
    }
    public void OnGUI()
    {
        if (!coins)//Si son monedas
        {
            ScoreBar.text = "" + points;//Muestra los puntos
        }
        else
        {
            ScoreBar.text = "X" + points;//Muestra los puntos
        }
        
    }
}
