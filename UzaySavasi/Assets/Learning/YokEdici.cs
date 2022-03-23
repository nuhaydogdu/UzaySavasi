using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokEdici : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab;  // buradaki GameObject classsın adı 15. satırda yazan gameObject ise objenin adı yani yok edici scriptini nereye eklersek o obje oluyor

    GeriSayimSayaci yokEdiciGeriSayim;

    // Start is called before the first frame update
    void Start()
    {
        yokEdiciGeriSayim = gameObject.AddComponent<GeriSayimSayaci>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (yokEdiciGeriSayim.Bitti)
        {
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void AsteroidYokEdici(int sure)
    {
        yokEdiciGeriSayim.ToplamSure = sure;
        yokEdiciGeriSayim.Calistir();
    }
}
