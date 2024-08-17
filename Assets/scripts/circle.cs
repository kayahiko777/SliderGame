using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circle : MonoBehaviour
{
    public int point;
    private void OnTriggerEnter(Collider col)
    {
        //if(col.gameObject.tag == "Player")
        //{
           // Debug.Log("ÉLÉÉÉâêNì¸");
       // }

        if (col.gameObject.TryGetComponent(out PlayerController player))
        {
            player.AddScore(point);
            Destroy(gameObject, 0.5f);
        }

       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
