using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Ship ship;
    public Transform player;
    public Destroid effect;
    public float speedR = 5.0f;
    public float speed = 0.0f;
    private float dist = 0.0f;
    public bool IsXL, IsXXX = false, IsXX = false, IsX = false, IsI = false, fallow = false;
    public GameObject I, X, XX, XXX, This;
    private Vector3 target;

    private void Awake()//Al iniciar la aplicación busca el objeto Ship y
    {
        if (GameObject.FindObjectOfType<Ship>() != null)
        {
            player = GameObject.FindObjectOfType<Ship>().GetComponent<Transform>();
        }
        ship = GameObject.FindObjectOfType<Ship>();
        effect = GameObject.FindObjectOfType<Destroid>();
    }
    private void Start()
    {
        if (IsI || IsX)
        {
            Destroy(This, 25);
        }
        if (Random.Range(0.0f, 100.0f) > 50.0f)
        {
            speedR *= -1;
        }
        if (Random.Range(0.0f, 100.0f) > 60.0f || IsXL)
        {
            fallow = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindObjectOfType<Ship>() == null)
        {
            destroid();
        }
        else
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
            target = player.transform.position;
        }
        if ((IsI || IsXL) && fallow)
        {
            if(dist > 8)
            {
                transform.Rotate(Vector3.up * speedR * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
            }
            else
            {
                transform.Rotate(Vector3.up * speedR * Time.deltaTime);
                GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
            }
        }
        else
        {
            transform.Rotate(Vector3.up * speedR * Time.deltaTime);
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)//En caso de colisión
    {
        if (other.gameObject.name == "shipA")//Si el objeto colisionador fue Dart
        {
            ship.GameOver();//LLama la funcion de destruccion
        }
        else if (other.gameObject.name == "AsteroidXL(Clone)")
        {
            destroid();
        }
        else if (other.gameObject.name == "AsteroidXXX(Clone)" && ((IsI || IsX) || (IsXX || IsXXX)))
        {
            destroid();
        }
        else if (other.gameObject.name == "AsteroidXX(Clone)" && (IsI || IsX))
        {
            destroid();
        }
        else if (other.gameObject.name == "AsteroidX(Clone)" && (IsI))
        {
            destroid();
        }
    }

    private void destroid()
    {
        //Dependiendo del tamaño sera los meteoritos que apareceran por la colicion
        Vector3 vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);//Guarda la posición
        effect.DestroidX(vec);
        if (IsX)
        {
            Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));//Se asignan los valores de rotación
            Quaternion rot2 = Quaternion.Euler(new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));//Se asignan los valores de rotación
            Instantiate(I, vec, rot);//Instancia el objeto
            Instantiate(I, vec, rot2);//Instancia el objeto
        }
        else if (IsXX)
        {
            Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));//Se asignan los valores de rotación
            Quaternion rot2 = Quaternion.Euler(new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));//Se asignan los valores de rotación
            Instantiate(X, vec, rot);//Instancia el objeto
            Instantiate(X, vec, rot2);//Instancia el objeto
        }
        else if (IsXXX)
        {
            Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));//Se asignan los valores de rotación
            Instantiate(XX, vec, rot);//Instancia el objeto
        }
        else if (IsXL)
        {
            Quaternion rot = Quaternion.Euler(new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f)));//Se asignan los valores de rotación
            Instantiate(XXX, vec, rot);//Instancia el objeto
        }
        Destroy(this.gameObject);
    }
}
