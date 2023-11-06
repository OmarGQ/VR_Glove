using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour
{
    public GameObject ThisDart;
    public Transform dart;
    float time = 3;

    private void Update()
    {
        if (ThisDart.activeInHierarchy)
        {
            Vector3 vec = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);//Guarda la posición
            Quaternion rot = Quaternion.Euler(new Vector3(transform.rotation.x + 180, transform.rotation.y, transform.rotation.z));
            time -= Time.deltaTime;//Se resta 1 a time cada segundo
            if (time < 0)//Si time es menor a 0
            {
                ThisDart.SetActive(false);
                Transform obj = Instantiate(dart, vec, rot) as Transform;
                obj.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * -15.0f, ForceMode.Impulse);
                time = 5;
            }
        }
    }
    private void OnTriggerEnter(Collider other)//En caso de colisión
    {
        if (other.gameObject.name == "table")//Si el objeto colisionador fue Dart
        {
            ThisDart.SetActive(true);
        }
    }
}
