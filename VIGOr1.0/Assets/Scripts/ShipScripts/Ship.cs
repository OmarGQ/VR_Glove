using UnityEngine;

public class Ship : MonoBehaviour
{
    public GameObject VrCamera, Over;
    public Effect effect;
    public static float speed = 0.0f, ext = 0.0f, last = 0.0f;
    public Points point;//Objeto Points
    float num = 0.0f;
    Vector3 vec, cam;

    private void Awake()
    {
        speed = num;//Restaura valor en 0 al iniciar
        Over.transform.Translate(new Vector3(0,0,0));
        Over.SetActive(false);
    }

    void Update()//Cada frame se mueve hacia adelante
    {
        ext = Points.points;
        last = speed + ext;
        Vector3 direccion = new Vector3(transform.forward.x, 0, transform.forward.z).normalized * last * Time.deltaTime;
        Quaternion rotacion = Quaternion.Euler(new Vector3(0, transform.root.eulerAngles.y, 0));
        transform.Translate(rotacion * direccion);
    }

    public void GameOver()//Al chocar
    {
        Vector3 vec = new Vector3(transform.position.x, transform.position.y, transform.position.z);//Guarda la posición
        cam = VrCamera.transform.position;
        Vector3 rec = new Vector3(0, -1, 0);
        Vector3 last = cam + rec;
        Over.transform.Translate(last);//Posiciona la ventana de game over
        Over.SetActive(true);
        effect.Create(vec);//efecto de destruccion
        Destroy(this.gameObject);//Destruye el objeto
    }
}
