using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerball : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        //�T�b�J�[�{�[������ɂԂ�������
        if(col.gameObject.tag == "Fance")
        {
            //�T�b�J�[�{�[����j�󂷂�
            Destroy(gameObject);
        }
    }
}
