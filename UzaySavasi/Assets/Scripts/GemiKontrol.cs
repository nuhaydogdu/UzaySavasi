using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemiKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject kursunPrefab;

    [SerializeField]
    GameObject patlamaPrefab;

    const float hareketGucu = 10; //uzay gemisimi hızını belirlemek için sabit bir çarpan belirliyoruz

    OyunKontrol oyunKontrol;

    // Start is called before the first frame update
    void Start()
    {
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position; //gemimizin şuanki pozisyonu
                                               //uzay gemimizi kontrolcüler aracılığı ile kontrol etmeye çalışıyoruz -GetAxis("Horizontal","Vertical")
        float yatayInput = Input.GetAxis("Horizontal");
        float dikeyInput = Input.GetAxis("Vertical");

        if (yatayInput != 0)
        {
            position.x += yatayInput * hareketGucu * Time.deltaTime; // her frame hareket etmesini istediğimiz için -Time.deltaTime
        }

        if (dikeyInput != 0)
        {
            position.y += dikeyInput * hareketGucu * Time.deltaTime;
        }

        transform.position = position;

        if (Input.GetButtonDown("Jump"))
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().Ates();
            Vector3 kursunPozisyon = gameObject.transform.position;
            kursunPozisyon.y += 1;
            Instantiate(kursunPrefab, kursunPozisyon, Quaternion.identity);
        }
    }
    void OnCollisionEnter2D(Collision2D col) //collider 2D ve collision2D arasındaki fark collisionda olay sonrası karsı bir kuvvet uygulanması sağlanıyor
    {
        if (col.gameObject.tag == "Asteroid")
        {
            GameObject.FindGameObjectWithTag("Audio").GetComponent<SesKontrol>().GemiPatlama();
            oyunKontrol.OyunuBitir();
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

