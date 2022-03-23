using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetikleyici : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake() // oyun içerisindeki ilk önce yapılması gerken işlemler için yapılır -awake
    {
        EkranHesaplayicisi.Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

