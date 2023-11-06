using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI OutText = null; //Objeto con el cual se mostrarán los mensajes
    public TextMeshProUGUI UserNameShow = null;

    public InputField UserName = null; //Cuadros de texto de donde se obtendrán la información del registro
    public InputField Email = null;
    public InputField Password = null;
    public InputField reEnterPassword = null;

    public InputField PasswordLog = null; //Cuadros de texto de donde se obtendrán la información del login
    public InputField UserNameLog = null;

    public float rotateSpeed; //Variable para la velocidad con la que girara el fondo

    private NetworkManager networkManager = null;

    string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";//Verificador de la estructura del email

    private void Awake()//Al iniciar la aplicación busca el objeto NetworkManager
    {
        networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed); //Cada frame el fondo gira segun el valor de rotateSpeed
        UserNameShow.text = Data.userName;//Muestra el nombre de usuario
    }

    public void submitRegister()//Acción del botón de registro
    {
        if (UserName.text == "" || Email.text == "" || Password.text == "" || reEnterPassword.text == "")//Verifica que no haya recuadros vacíos
        {
            OutText.text = "Llene los campos faltantes";//Muestra mensaje
        }
        else
        {
            if (Regex.IsMatch(Email.text, expression))//Verifica que la estructura se cumpla
            {
                if (Regex.Replace(Email.text, expression, string.Empty).Length == 0)
                {
                    if (Password.text == reEnterPassword.text)//Verifica que la contraseña se haya escrito correctamente
                    {
                        int length = (Password.text).Length;//Cuenta el tamaño del string
                        if (length >= 6)//Si es mayor o igual a 6
                        {
                            OutText.text = "Procesando...";//Muestra mensaje
                            networkManager.Registrar(UserName.text, Email.text, Password.text);//Pasa los datos del registro a NetworkManager
                        }
                        else
                        {
                            OutText.text = "La contraseña debe tener almenos 6 caracteres";//Muestra mensaje
                        }
                    }
                    else
                    {
                        OutText.text = "Las contraseñas no son idénticas";//Muestra mensaje
                    }
                }
                else
                {
                    OutText.text = "La direccion de email no es valida";//Muestra mensaje
                }
            }
            else
            {
                OutText.text = "La direccion de email no es valida";//Muestra mensaje
            }
        }
    }

    public void submitLogin()//Acción del botón de login
    {
        if (UserNameLog.text == "" || PasswordLog.text == "")//Verifica que no haya recuadros vacíos
        {
            OutText.text = "Llene los campos faltantes";//Muestra mensaje
        }
        else
        {
            OutText.text = "Procesando...";//Muestra mensaje
            networkManager.IniciaarSecion(UserNameLog.text, PasswordLog.text);//Pasa los datos del login a NetworkManager
            PasswordLog.text = "";//Vacía el campo Password
        }
    }

    public void puntajes()//Acción del botón de puntajes
    {
        networkManager.Score();//Llama al networkManager
    }

    public void CloseSession()//Cerrar sesión
    {
        Data.userName = "";//Se borra la variable de sesión
    }

    public void PlayGame()//Acción del botón Empezar
    {
        //Cambia de escena para dar inicio al juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()//Acción del botón Cerrar
    {
        //Cierra la aplicación
        Application.Quit();
    }
    public void puntajes2()//Acción del botón de puntajes
    {
        networkManager.Score2();//Llama al networkManager
    }
}
