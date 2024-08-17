using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JumpUpObgect : MonoBehaviour
{
    private float startHeight;
    public float hideHeight = 3.0f;
    public Ease ease;
    // Start is called before the first frame update
    void Start()
    {
        //‰B‚·
        Hide();
    }

    // Update is called once per frame
    /// <summary>
    /// ‰B‚·
    /// </summary>
    private void Hide()
    {
        startHeight = transform.position.y;

        transform.position = new Vector3(transform.position.x, transform.position.y - hideHeight,transform.position.z);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log(col.gameObject.tag);

            HeadUp();

            GetComponent<ParticleSystem>().Play();
        }
    }

    private void HeadUp()
    {
        transform.DOMoveY(startHeight, 0.25f).SetEase(ease);
    }
    void Update()
    {
        
    }
}
