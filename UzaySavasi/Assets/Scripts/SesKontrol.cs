using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrol : MonoBehaviour
{

    [SerializeField]
    AudioClip asteroidPatlama = default;

    [SerializeField]
    AudioClip gemiPatlama = default;

    [SerializeField]
    AudioClip ates = default;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // seslerimixi çalabilmek içi audiosource classına ihtiyacımız var.
    }

    public void AsteroidPatlama()
    {
        audioSource.PlayOneShot(asteroidPatlama); // patlama sesini bir kez çalması için
    }

    public void GemiPatlama()
    {
        audioSource.PlayOneShot(gemiPatlama);
    }

    public void Ates()
    {
        audioSource.PlayOneShot(ates, 0.4f);
    }
}
