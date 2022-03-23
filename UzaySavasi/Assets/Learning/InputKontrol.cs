using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefab;
   
    List<GameObject> astroidList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log(Input.mousePosition);
            Vector3 position = Input.mousePosition;          //23 üçüncü satırda z eksenine göre ayarlamalar yapıyoruz çünki 2D dede üçüncü bir ze eksen, var ve objeler orada göründügü zaman var olabiliyorlar.      
            position.z = -Camera.main.transform.position.z; //maincamera ya ulaşmak için -Camera.main (kameranın yerini değiştirdiğimiz zaman oyun objelerimizin oluştugu yerde aynı olsun diye)
            position = Camera.main.ScreenToWorldPoint(position); // unity nin mouse pozisyonu olarak ekran pikselllerine göre verdiği değeri oyun dünyasının kendi kodlarına çevirdik

            for (int i = 0; i < 25; i++)
            {
                astroidList.Add(Instantiate(asteroidPrefab, position, Quaternion.identity));// rotasyonunda bir değişiklik olmasın diye -Quaternion.identity
            }
           
           

        }
        //    if (Input.GetMouseButton(0))
        //    {
        //        Debug.Log("Pressed left click.");
        //    }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (GameObject asteroid in astroidList)
            {
                Destroy(asteroid);
            }
            astroidList.Clear(); //astroidleri her yok ettiğimizde list değişkenimizin içinide temizlememiz lazım(gereğinden fazla kullanımı azaltmak için.


            // for (int i = 0; i < astroidList.Count; i++) //listlerde kaç elaman oldugunu sorguluyoruz -.Count
            //{
            //    Destroy(astroidList[i]);
            // }
        }

        //    if (Input.GetMouseButton(2))
        //    {
        //        Debug.Log("Pressed middle click.");
        //}
    }
}

