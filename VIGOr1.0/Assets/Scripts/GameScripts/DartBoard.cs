using UnityEngine;

public class DartBoard : MonoBehaviour
{
    private Points point;//Objeto Points
    public int cant;//Puntos
    private Effect eff = null;//Objeto Effect
    public float moveSpeed;//Velocidad
    public float cantTime;//Variable de tiempo
    public bool isDuck;//Validaciones de objeto
    public bool isClock;

    private void Awake()//Al iniciar
    {
        eff = GameObject.FindObjectOfType<Effect>();//Busca objeto Effect
    }

    private void OnTriggerEnter(Collider other)//En caso de colisión
    {
        if (other.gameObject.name == "Dart")//Si el objeto colisionador fue Dart
        {
            Points.points += cant;//Suma los puntos
            Destroy(other.gameObject);//Destruye el dardo
            Vector3 vec= new Vector3(transform.position.x, transform.position.y, transform.position.z);//Guarda la posición
            if (isClock)//En caso de ser un reloj
            {
                Timer.time += cantTime;//Sumar tiempo
            }
            eff.Create(vec);//Manda su posición a Effect.Create
            Destroy(this.gameObject);//Se destruye
        }
    }

    void Update()//Se actualiza cada frame
    {
        if (isDuck)//Si es un pato
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);//Se mueve hacia abajo debido a que modelo del pato la cabeza apunta a abajo
        }
        else//Si no es un pato
        {
            if (transform.position.z == 14 || transform.position.z == 15)//Si la posición en z es 14 o 15
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);//Se mueve a la derecha
            }
            if (transform.position.z == 17 || transform.position.z == 12)//Si la posición en z es 17 o 12
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);//Se mueve a la izquierda 
            }
        }
        if (transform.position.x > 10)//Si la posición en x es mayor a 10
        {
            Destroy(this.gameObject);//Se destruye
        }
        if(transform.position.x < -10)//Si la posición en x es menor a -10
        {
            Destroy(this.gameObject);//Se destruye
        }
    }
}
