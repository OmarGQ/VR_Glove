using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject asteroidXL, asteroidXXX, asteroidXX, asteroidX, asteroid;
    public GameObject coin;
    public Ship ship;
    private Vector3 offset;

    private void Awake()//Al iniciar la aplicación busca el objeto Ship y
    {
        ship = GameObject.FindObjectOfType<Ship>();
    }

    void Start()
    {
        offset = transform.position - ship.transform.position;
        InvokeRepeating("AsteroidXL", Random.Range(7.0f, 10.0f), Random.Range(7.0f, 10.0f));
        InvokeRepeating("AsteroidXXX", Random.Range(6.0f, 8.0f), Random.Range(6.0f, 8.0f));
        InvokeRepeating("AsteroidXX", Random.Range(4.0f, 6.0f), Random.Range(4.0f, 6.0f));
        InvokeRepeating("AsteroidX", Random.Range(3.0f, 4.0f), Random.Range(2.0f, 3.0f));
        InvokeRepeating("Asteroid", Random.Range(1.5f, 2.0f), Random.Range(1.5f, 2.0f));
        InvokeRepeating("Coin", Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f));
    }

    private void Update()
    {
        if (GameObject.FindObjectOfType<Ship>() == null)
        {
            CancelInvoke("AsteroidXL");
            CancelInvoke("AsteroidXXX");
            CancelInvoke("AsteroidXX");
            CancelInvoke("AsteroidX");
            CancelInvoke("Asteroid");
            CancelInvoke("Coin");
        }
    }

    public void AsteroidXL()//Creación de patos
    {
        float Ay = ship.transform.transform.eulerAngles.y;
        Vector3 ot = new Vector3(0, 0, 0);
        Vector3 pos = new Vector3(0, 0, 0);
        pos = ship.transform.position + offset;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0)); ;//Valores de rotación
        if (Ay>45 && Ay<=135)
        {
            rot = Quaternion.Euler(new Vector3(0, 270, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-1600.0f, -1000.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        }
        if (Ay > 135 && Ay <= 225)
        {
            rot = Quaternion.Euler(new Vector3(0, 0, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(1000.0f, 1600.0f));
        }
        if (Ay > 225 && Ay <= 315)
        {
            rot = Quaternion.Euler(new Vector3(0, 90, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(1000.0f, 1600.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        }
        if ((Ay > 315 && Ay <= 360)|| (Ay >= 0 && Ay <= 45))
        {
            rot = Quaternion.Euler(new Vector3(0, 180, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(-1800.0f, -1000.0f));
        }
        pos = pos + ot;
        Instantiate(asteroidXL, pos, rot);//Instancia el objeto
    }
    public void AsteroidXXX()//Creación de patos
    {
        float Ay = ship.transform.transform.eulerAngles.y;
        Vector3 ot = new Vector3(0, 0, 0);
        Vector3 pos = new Vector3(0, 0, 0);
        pos = ship.transform.position + offset;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0)); ;//Valores de rotación
        if (Ay > 45 && Ay <= 135)
        {
            rot = Quaternion.Euler(new Vector3(0, 270, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-1400.0f, -800.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        }
        if (Ay > 135 && Ay <= 225)
        {
            rot = Quaternion.Euler(new Vector3(0, 0, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(800.0f, 1400.0f));
        }
        if (Ay > 225 && Ay <= 315)
        {
            rot = Quaternion.Euler(new Vector3(0, 90, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(800.0f, 1400.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        }
        if ((Ay > 315 && Ay <= 360) || (Ay >= 0 && Ay <= 45))
        {
            rot = Quaternion.Euler(new Vector3(0, 180, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(-1400.0f, -800.0f));
        }
        pos = pos + ot;
        Instantiate(asteroidXXX, pos, rot);//Instancia el objeto
    }
    public void AsteroidXX()//Creación de patos
    {
        float Ay = ship.transform.transform.eulerAngles.y;
        Vector3 ot = new Vector3(0, 0, 0);
        Vector3 pos = new Vector3(0, 0, 0);
        pos = ship.transform.position + offset;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0)); ;//Valores de rotación
        if (Ay > 45 && Ay <= 135)
        {
            rot = Quaternion.Euler(new Vector3(0, 270, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-1200.0f, -800.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        }
        if (Ay > 135 && Ay <= 225)
        {
            rot = Quaternion.Euler(new Vector3(0, 0, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(800.0f, 1200.0f));
        }
        if (Ay > 225 && Ay <= 315)
        {
            rot = Quaternion.Euler(new Vector3(0, 90, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(800.0f, 1200.0f), Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        }
        if ((Ay > 315 && Ay <= 360) || (Ay >= 0 && Ay <= 45))
        {
            rot = Quaternion.Euler(new Vector3(0, 180, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-500.0f, 500.0f), Random.Range(-1200.0f, -800.0f));
        }
        pos = pos + ot;
        Instantiate(asteroidXX, pos, rot);//Instancia el objeto
    }
    public void AsteroidX()//Creación de patos
    {
        float Ay = ship.transform.transform.eulerAngles.y;
        Vector3 ot = new Vector3(0, 0, 0);
        Vector3 pos = new Vector3(0, 0, 0);
        pos = ship.transform.position + offset;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0)); ;//Valores de rotación
        if (Ay > 45 && Ay <= 135)
        {
            rot = Quaternion.Euler(new Vector3(0, 270, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-1000.0f, -700.0f), Random.Range(-400.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        }
        if (Ay > 135 && Ay <= 225)
        {
            rot = Quaternion.Euler(new Vector3(0, 0, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-400.0f, 500.0f), Random.Range(700.0f, 1000.0f));
        }
        if (Ay > 225 && Ay <= 315)
        {
            rot = Quaternion.Euler(new Vector3(0, 90, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(700.0f, 1000.0f), Random.Range(-400.0f, 500.0f), Random.Range(-500.0f, 500.0f));
        }
        if ((Ay > 315 && Ay <= 360) || (Ay >= 0 && Ay <= 45))
        {
            rot = Quaternion.Euler(new Vector3(0, 180, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-400.0f, 500.0f), Random.Range(-1000.0f, -700.0f));
        }
        pos = pos + ot;
        Instantiate(asteroidX, pos, rot);//Instancia el objeto
    }
    public void Asteroid()//Creación de patos
    {
        float Ay = ship.transform.transform.eulerAngles.y;
        Vector3 ot = new Vector3(0, 0, 0);
        Vector3 pos = new Vector3(0, 0, 0);
        pos = ship.transform.position + offset;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0)); ;//Valores de rotación
        if (Ay > 45 && Ay <= 135)
        {
            rot = Quaternion.Euler(new Vector3(0, 270, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-1000.0f, -700.0f), Random.Range(-400.0f, 300.0f), Random.Range(-300.0f, 300.0f));
        }
        if (Ay > 135 && Ay <= 225)
        {
            rot = Quaternion.Euler(new Vector3(0, 0, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-300.0f, 300.0f), Random.Range(-400.0f, 300.0f), Random.Range(700.0f, 1000.0f));
        }
        if (Ay > 225 && Ay <= 315)
        {
            rot = Quaternion.Euler(new Vector3(0, 90, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(700.0f, 1000.0f), Random.Range(-400.0f, 300.0f), Random.Range(-300.0f, 300.0f));
        }
        if ((Ay > 315 && Ay <= 360) || (Ay >= 0 && Ay <= 45))
        {
            rot = Quaternion.Euler(new Vector3(0, 180, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-300.0f, 300.0f), Random.Range(-400.0f, 300.0f), Random.Range(-1000.0f, -700.0f));
        }
        pos = pos + ot;
        Instantiate(asteroid, pos, rot);//Instancia el objeto
    }
    public void Coin()//Creación de patos
    {
        float Ay = ship.transform.transform.eulerAngles.y;
        Vector3 ot = new Vector3(0, 0, 0);
        Vector3 pos = new Vector3(0, 0, 0);
        pos = ship.transform.position + offset;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, 0)); ;//Valores de rotación
        if (Ay > 45 && Ay <= 135)
        {
            rot = Quaternion.Euler(new Vector3(0, 270, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-900.0f, -600.0f), Random.Range(-100.0f, 200.0f), Random.Range(-100.0f, 100.0f));
        }
        if (Ay > 135 && Ay <= 225)
        {
            rot = Quaternion.Euler(new Vector3(0, 0, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 200.0f), Random.Range(600.0f, 900.0f));
        }
        if (Ay > 225 && Ay <= 315)
        {
            rot = Quaternion.Euler(new Vector3(0, 90, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(600.0f, 900.0f), Random.Range(-100.0f, 200.0f), Random.Range(-100.0f, 100.0f));
        }
        if ((Ay > 315 && Ay <= 360) || (Ay >= 0 && Ay <= 45))
        {
            rot = Quaternion.Euler(new Vector3(0, 180, 0));//Se asignan los valores de rotación
            ot = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 200.0f), Random.Range(-900.0f, -600.0f));
        }
        pos = pos + ot;
        Instantiate(coin, pos, rot);//Instancia el objeto
    }
}
