using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloorGimmick : MonoBehaviour
{
    public GameObject[] floorObjects;
    public float duration;
    [Header("チェックが入ってたら上がる、チェックが入ってなかったら下がる")]
    public bool isFloorUp = false;
    public float distance;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            MoveFloor();
        }
    }

    private void MoveFloor()
    {
        if (isFloorUp)
        {
            for (int i = 0; i < floorObjects.Length; i++)
            {
                floorObjects[i].transform.DOMoveY(distance, duration);
            }
        }
        else
        {
            for (int i = 0; i < floorObjects.Length; i++)
            {
                floorObjects[i].transform.DOMoveY(-distance, duration);
            }
        }
    }
}
