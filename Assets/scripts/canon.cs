using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{

    public GameObject shellPrefab;
    public float shellforce;
    public float span ;
    public float delta;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if(delta > span)
        {
            delta = 0;
            GameObject shell = Instantiate(shellPrefab,transform.position,Quaternion.identity);
            Rigidbody shellrb = shell.GetComponent<Rigidbody>();

            shellrb.AddForce(transform.forward * shellforce);

            Destroy(shell, 1.5f);
        }
    }
}
