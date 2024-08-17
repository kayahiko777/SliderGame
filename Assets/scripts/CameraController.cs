using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerobj; //�J�������Ǐ]����Ώۂ̃I�u�W�F�N�g

    private Vector3 offset; //�J�������Ǐ]����ΏۂƂ̊Ԃ̂Ƃ�A���̋����p�̕␳�l
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - playerobj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�Ǐ]�Ώۂ�����ꍇ
        if (playerobj !=  null)
        {
            //�J�����̈ʒu��Ǐ]�Ώۂ̈ʒu�{�␳�l�ɂ���
            transform.position = playerobj.transform.position + offset;
        }
    }
}
