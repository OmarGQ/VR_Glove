using UnityEngine;

public class DogCoin : MonoBehaviour
{
    public Points point;//Objeto Points
    private float speed = 30.0f;

    private void OnTriggerEnter(Collider other)//En caso de colisión
    {
        if (other.gameObject.name == "shipA")//Si el objeto colisionador fue la nave
        {
            Points.points += 1;//Suma los puntos
            Destroy(this.gameObject);//Se destruye
        }
    }
    
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);//Rotacion de la moneda
    }
}
