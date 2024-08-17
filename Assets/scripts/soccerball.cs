using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerball : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        //サッカーボールが柵にぶつかったら
        if(col.gameObject.tag == "Fance")
        {
            //サッカーボールを破壊する
            Destroy(gameObject);
        }
    }
}
