using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EkranHesaplayicisi  // bu scripti herhangi bir ojeye eklemeden bu değerlere her yerden erişebilmemiz lazım
{
    static float sol;
    static float sag;
    static float ust;
    static float alt;

    /// <summary>
    /// Ekranın sol kenarının koordinatlarını verir
    /// </summary>
    public static float Sol
    {
        get
        {
            return sol;
        }
    }

    /// <summary>
    /// Ekranın sağ kenarının koordinatlarını verir
    /// </summary>
    public static float Sag
    {
        get
        {
            return sag;
        }
    }


    /// <summary>
    /// Ekranın üst kenarının koordinatlarını verir
    /// </summary>
    public static float Ust
    {
        get
        {
            return ust;
        }
    }


    /// <summary>
    /// Ekranın alt kenarının koordinatlarını verir
    /// </summary>
    public static float Alt
    {
        get
        {
            return alt;
        }
    }


    public static void Init()  //oyun başlar başlammaaz bir methodun yukaarıdaki değerleri hesaplaması lazzım -initialize
    {
        float ekranZekseni = -Camera.main.transform.position.z;
        Vector3 solAltKose = new Vector3(0, 0, ekranZekseni);
        Vector3 sagUstKose = new Vector3(Screen.width, Screen.height, ekranZekseni);

        Vector3 solAltKoseOyunDunyasi = Camera.main.ScreenToWorldPoint(solAltKose);//piksel değerlerini oyun dunyasının değerlerine çeviriyoruz
        Vector3 sagUstKoseOyunDunyasi = Camera.main.ScreenToWorldPoint(sagUstKose);

        sol = solAltKoseOyunDunyasi.x;
        sag = sagUstKoseOyunDunyasi.x;
        ust = sagUstKoseOyunDunyasi.y;
        alt = solAltKoseOyunDunyasi.y;
    }
}

