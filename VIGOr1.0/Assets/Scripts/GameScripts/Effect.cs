using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Effect : MonoBehaviour
{
    public GameObject effect;
    private int score;
    public TextMeshProUGUI pointsText;//Text donde mostrara el puntaje final
    public TextMeshProUGUI  OutText;//Text donde mostrara mensaje de la base de datos
    public GameObject panel;//Pantalla de game over

    public void GameOver()//Proceso que se ejecuta cuando Timer llega a 0
    {
        panel.SetActive(true);//Aparece la pantalla de game over
        score = Points.points;//Obtiene el puntaje
        pointsText.text = "" + score + " Points";//muestra puntaje
        StartCoroutine(NewScore(score));//Inicia el IEnumerator del NewScore
    }

    public void Create(Vector3 position)//Obtiene la posicion de la diana destruida
    {
        Instantiate(effect, position, Quaternion.identity);//Crea una animación en la posición de la diana
        StartCoroutine(NewCoins());
    }

    IEnumerator NewScore(int score)//Hilo que manda los datos del login al servidor y espera respuesta
    {
        var user = Data.userName;
        var uri = "http://omargodinez.com/DAR2/newScore.php?user=" + user + "&points=" + score;//Crea el acceso al servidor y manda los datos
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))//Realiza la conexión
        {
            yield return webRequest.SendWebRequest();//Solicita y espera la página deseada

            if (webRequest.isNetworkError)//Si ocurrió un error 
            {
                OutText.text = "No se logró conectar";//Muestra mensaje
            }
            else
            {
                if (webRequest.downloadHandler.text == "registrado")//Si se registró el puntaje
                {
                    OutText.text = "Top 5";//Muestra mensaje
                }
            }
        }
    }

    IEnumerator NewCoins()//Hilo que manda los datos del login al servidor y espera respuesta
    {
        score = Points.points;//Obtiene el puntaje
        pointsText.text = "X  " + score;//muestra puntaje
        var user = Data.userName;
        var uri = "http://omargodinez.com/DAR2/newCoins.php?user=" + user + "&points=" + score;//Crea el acceso al servidor y manda los datos
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))//Realiza la conexión
        {
            yield return webRequest.SendWebRequest();//Solicita y espera la página deseada

            if (webRequest.isNetworkError)//Si ocurrió un error 
            {
                OutText.text = "No se logró conectar";//Muestra mensaje
            }
            else
            {
                if (webRequest.downloadHandler.text == "registrado")//Si se registró el puntaje
                {
                    OutText.text = "Top 5";//Muestra mensaje
                }
            }
        }
    }
}
