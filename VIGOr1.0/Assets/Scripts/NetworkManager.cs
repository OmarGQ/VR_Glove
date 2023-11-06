using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{
    public TextMeshProUGUI OutText = null; //Objeto con el cual se mostrarán los mensajes
    public GameObject logpanel = null;
    public GameObject logtext = null;
    public GameObject OutConection = null;
    public Image icon = null;
    public GameObject logbutton = null;
    public GameObject closebutton = null;
    public GameObject userNameShow = null;
    public GameObject data = null;
    private HighScore score = null;

    private void Awake()//Al iniciar la aplicación busca el objeto HighScore
    {
        score = GameObject.FindObjectOfType<HighScore>();
        if (GameObject.FindObjectOfType<Data>() == null)//Si no existe Data lo crea
        {
            Instantiate(data);
        }
    }

    void Update()//Revisa la conexión a internet en cada frame
    {
        if (Application.internetReachability != NetworkReachability.NotReachable && Data.userName == "")//si ha conexión a internet
        {
            icon.sprite = Resources.Load<Sprite>("Images/vacio");//No muestra el icono de "fuera de línea"
            logbutton.SetActive(true);//Activa el botón de login
            closebutton.SetActive(false);//Desactiva el botón de cerrar sesión
            OutConection.SetActive(false);//Desactiva el mensaje de fuera de línea
            userNameShow.SetActive(false);//Desactiva el nombre del usuario
        }
        else if (Application.internetReachability != NetworkReachability.NotReachable && Data.userName != "")//si ha conexión a internet
        {
            icon.sprite = Resources.Load<Sprite>("Images/vacio");//No muestra el icono de "fuera de línea"
            logbutton.SetActive(false);//Desactiva el botón de login
            closebutton.SetActive(true);//Activa el botón de cerrar sesión
            userNameShow.SetActive(true);//Activa el nombre del usuario
            OutConection.SetActive(false);//Desactiva el mensaje de fuera de línea
        }
        else//En caso opuesto
        {
            icon.sprite = Resources.Load<Sprite>("Images/icono1");//Muestra el icono de "fuera de línea"
            logbutton.SetActive(false);//Desactiva el botón de login
            closebutton.SetActive(false);//Desactiva el botón de cerrar sesión
            userNameShow.SetActive(false);//Desactiva el nombre del usuario
            OutConection.SetActive(true);//Activa el mensaje de fuera de línea
        }
    }

    public void IniciaarSecion(string user, string pass)
    {
        StartCoroutine(Login(user, pass));//Inicia el IEnumerator del Login
    }

    public void Registrar(string user, string email, string pass)
    {
        StartCoroutine(Register(user, email, pass));//Inicia el IEnumerator del Registro
    }
    
    public void Score()
    {
        StartCoroutine(Puntuaciones());//Inicia el IEnumerator del Score
    }
    public void Score2()
    {
        StartCoroutine(Coins());//Inicia el IEnumerator del Score
    }

    IEnumerator Login(string user, string pass)//Hilo que manda los datos del login al servidor y espera respuesta
    {
        var uri = "http://omargodinez.com/DAR2/login.php?user=" + user + "&pass=" + pass;//Crea el acceso al servidor y manda los datos
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))//Realiza la conexión
        {
            yield return webRequest.SendWebRequest();//Solicita y espera la página deseada

            if (webRequest.isNetworkError)//Si ocurrió un error 
            {
                OutText.text = "No se logró conectar con el servidor";//Muestra mensaje
            }
            else
            {
                if(webRequest.downloadHandler.text == "nop")//En caso de respuesta negativa
                {
                    OutText.text = "Los datos no concuerdan";//Muestra mensaje
                }else if(webRequest.downloadHandler.text == "sirve")//En caso de respuesta positiva
                {
                    OutText.text = "Éxito";//Muestra mensaje
                    Data.userName = user;//Guarda el nombre del usuario con sesión abierta
                    OutText.text = "";//Borra el mensaje
                    //GameObject child = logpanel.transform.GetChild(3).gameObject;
                    //child.SetActive(false);
                    logpanel.SetActive(false);//Oculta la ventana de login
                    logtext.SetActive(false);//Oculta el OutText
                }
                else//En cualquier otro caso
                {
                    OutText.text = "Ocurrió un problema";//Muestra mensaje
                }
            }
        }
    }

    IEnumerator Register(string user, string email, string pass)//Hilo que manda los datos del registro al servidor y espera respuesta
    {
        var uri = "http://omargodinez.com/DAR2/createuser.php?user=" + user + "&email=" + email + "&pass=" + pass;//Dirección del servidor al cual se accederá
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))//Realiza la conexión
        {
            yield return webRequest.SendWebRequest();//Solicita y espera la página deseada

            if (webRequest.isNetworkError)//Si ocurrió un error 
            {
                OutText.text = "No se logró conectar con el servidor";//Muestra mensaje
            }
            else
            {
                if (webRequest.downloadHandler.text == "usuario")//Si el usuario ya existe
                {
                    OutText.text = "Ya existe el usuario";//Muestra mensaje
                }else if (webRequest.downloadHandler.text == "email")//Si el email ya está registrado
                {
                    OutText.text = "Ya está registrado el email";//Muestra mensaje
                }else if (webRequest.downloadHandler.text == "registrado")//En caso de respuesta positiva
                {
                    OutText.text = "Usuario creado con éxito";//Muestra mensaje
                }else
                {
                    OutText.text = "Ocurrió un problema";//Muestra mensaje
                }
            }
        }
    }

    IEnumerator Puntuaciones()//Hilo que pide los puntajes al servidor y espera respuesta
    {
        var uri = "http://omargodinez.com/DAR2/score.php";//Dirección del servidor al cual se accederá
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))//Realiza la conexión
        {
            yield return webRequest.SendWebRequest();//Solicita y espera la página deseada

            if (webRequest.isNetworkError)//Si ocurrió un error 
            {
                score.colocarP("");//Pasa un dato vacío a HighScore para que este muestre error de conexión
            }
            else
            {
                score.colocarP(webRequest.downloadHandler.text);//Pasa los datos del servidor a HighScore
            }
        }
    }
    IEnumerator Coins()//Hilo que pide los puntajes al servidor y espera respuesta
    {
        var uri = "http://omargodinez.com/DAR2/score2.php";//Dirección del servidor al cual se accederá
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))//Realiza la conexión
        {
            yield return webRequest.SendWebRequest();//Solicita y espera la página deseada

            if (webRequest.isNetworkError)//Si ocurrió un error 
            {
                score.colocarP("");//Pasa un dato vacío a HighScore para que este muestre error de conexión
            }
            else
            {
                score.colocarP(webRequest.downloadHandler.text);//Pasa los datos del servidor a HighScore
            }
        }
    }
}