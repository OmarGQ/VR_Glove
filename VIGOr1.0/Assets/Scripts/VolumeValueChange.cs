using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{

    // referencia al componente de sonido
    private AudioSource audioSrc;

    // variable modificadora del volumen
    private float musicVolume = 1f;

    void Start()
    {

        // asignación del componente de audio
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

        // aplicación de la opcion de volumen en el componente de sonido
        audioSrc.volume = musicVolume;
    }

    // Toma el valor del slider y lo pasa a la variable del volumen
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
