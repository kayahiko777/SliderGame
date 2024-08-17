using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerobj; //カメラが追従する対象のオブジェクト

    private Vector3 offset; //カメラが追従する対象との間のとる、一定の距離用の補正値
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerobj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //追従対象がいる場合
        if (playerobj !=  null)
        {
            //カメラの位置を追従対象の位置＋補正値にする
            transform.position = playerobj.transform.position + offset;
        }
    }
}
