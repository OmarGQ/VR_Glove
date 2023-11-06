using UnityEngine;

public class EffectDie : MonoBehaviour
{
    public AudioClip sound;//Archivo de sonido
    public AudioSource Audio;//Reproductor de sonido

    // Start is called before the first frame update
    void Start()
    {
        Audio.clip = sound;//Se carga el audio
        Audio.Play();//Se reproduce el audio
        Destroy(gameObject, 1);//Se destruye el objeto
    }
}
