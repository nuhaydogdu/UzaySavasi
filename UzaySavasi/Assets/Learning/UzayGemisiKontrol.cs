using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisiKontrol : MonoBehaviour
{
    const float hareketGucu = 5; //uzay gemisimi hızını belirlemek için sabit bir çarpan belirliyoruz

    bool topluyor = false;
    GameObject hedef;

    Rigidbody2D myRigidBody2D;

    Toplayici toplayici;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        toplayici = Camera.main.GetComponent<Toplayici>();
    }

    void OnMouseDown()      //uzay gemisine tıklandığı an çağırılan method
    {
        if (!topluyor)
        {
            GitVeTopla();
        }
    }

    void OnTriggerStay2D(Collider2D other) //bu method yardımıyla uzay gemimiz bir yıldızla temas kurarsa algılamamızı sağlıyoruz -unityden aldık
    {
        if (other.gameObject == hedef)
        {
            toplayici.YildizYokEt(hedef);
            myRigidBody2D.velocity = Vector2.zero; //yıldızı yok ettikten sonra uzay gemimizin hızını sıfırlıyoruz
            GitVeTopla();
        }
    }


    void GitVeTopla()
    {
        hedef = toplayici.HedefYildiz;
        if (hedef != null)
        {
            Vector2 gidilecekYer = new Vector2(hedef.transform.position.x
                - transform.position.x, hedef.transform.position.y - transform.position.y);
            gidilecekYer.Normalize();
            myRigidBody2D.AddForce(gidilecekYer * hareketGucu, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
    //    Vector3 position = transform.position; //gemimizin şuanki pozisyonu
    //                                           //uzay gemimizi kontrolcüler aracılığı ile kontrol etmeye çalışıyoruz -GetAxis("Horizontal","Vertical")
    //    float yatayInput = Input.GetAxis("Horizontal");
    //    float dikeyInput = Input.GetAxis("Vertical");

    //    if (yatayInput != 0)
    //    {
    //        position.x += yatayInput * hareketGucu * Time.deltaTime; // her frame hareket etmesşnş şstediğimiz için -Time.deltaTime
    //    }

    //    if (dikeyInput != 0)
    //    {
    //        position.y += dikeyInput * hareketGucu * Time.deltaTime;
    //    }

    //    transform.position = position;
    }
}
