using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{

    public TextMeshProUGUI Name1 = null;//Bloques de texto de donde se pondrá la información de los puntajes
    public TextMeshProUGUI Point1 = null;
    public TextMeshProUGUI Name2 = null;
    public TextMeshProUGUI Point2 = null;
    public TextMeshProUGUI Name3 = null;
    public TextMeshProUGUI Point3 = null;
    public TextMeshProUGUI Name4 = null;
    public TextMeshProUGUI Point4 = null;
    public TextMeshProUGUI Name5 = null;
    public TextMeshProUGUI Point5 = null;
    public TextMeshProUGUI Error = null;

    public void colocarP(string datos)//Acción de recibir y mostrar las mejores puntuaciones
    {
        if(datos == "" || datos == "Fallo la conexión")//Si recibe un parámetro vacío o un mensaje de fallo notifica el error
        {
            Error.text = "No se logró conectar con el servidor";//Muestra mensaje
        }
        else//Si no hay error
        {
            Error.text = "";//Quita mensaje
            string[] valores;//Arreglo donde se guardaran los datos de los puntajes ya separados
            valores = datos.Split(' ');//Separa la cadena recibida en cada espacio vacío
            Name1.text = valores[0];//Muestra el nombre 
            Point1.text = valores[1];//Muestra el puntaje
            Name2.text = valores[2];
            Point2.text = valores[3];
            Name3.text = valores[4];
            Point3.text = valores[5];
            Name4.text = valores[6];
            Point4.text = valores[7];
            Name5.text = valores[8];
            Point5.text = valores[9];
        }
    }
}
