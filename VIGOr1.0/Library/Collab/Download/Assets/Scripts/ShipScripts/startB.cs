using UnityEngine;
using UnityEngine.SceneManagement;


namespace RayCaster.Utils
{
    public class startB : MonoBehaviour
    {
        public InteractivoVR RayCast;//Captador de raycast
        public GameObject Objeto, TObj;//El objeto que contiene el script
        private float time = 0;//Contador
        public bool start = false, restart = false;//Si el botón es de inicio
        public Material m1;//materiales para cambiar de color
        public Material m2;
        public Material m3;
        public Material non;
        public GameObject spawn;

        void Update()//Se actualiza cada frame
        {
            if (RayCast.EstasMirando == true)//Si el raycaster detecta la retícula
            {
                time += Time.deltaTime;//Se le suma 1 a time cada segundo
                if (time < 1)//Si el tiempo es menor a 1
                {
                    TObj.gameObject.GetComponent<Renderer>().material = m1;//Cambia el material
                }
                time += Time.deltaTime;//Se le suma 1 a time cada segundo
                if (time > 1 && time < 2)//Si el tiempo es mayor a 1 y menor que 2
                {
                    TObj.gameObject.GetComponent<Renderer>().material = m2;//Cambia el material
                }
                time += Time.deltaTime;//Se le suma 1 a time cada segundo
                if (time > 2 && time < 3)//Si el tiempo es mayor a 2 y menor que 3
                {
                    TObj.gameObject.GetComponent<Renderer>().material = m3;//Cambia el material
                }
                if (time > 3)//Si time es mayor a 3
                {
                    if (start)//Si es un botón de inicio

                    {
                        //spawn.SetActive(true);
                        Instantiate(spawn, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                        Ship.speed = -40.0f;
                        Objeto.SetActive(false);//Se deshabilita el objeto para evitar errores al destruir
                        Initiation.ban = true;//Inicia Initiation
                        Destroy(Objeto); //Se destruye el objeto
                    }
                    else if (restart)
                    {
                        //Debug.Log(bluetoothData.javaObject.Call<string>("closeConnection"));
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Cambia de escena al Return
                    }
                }
            }
            else if (RayCast.EstasMirando == false)//Si el raycaster no detecta la retícula
            {
                TObj.gameObject.GetComponent<Renderer>().material = non;//Cambia el material al estado original
                time = 0;//El valor de time es 0;
            }
        }
    }
}