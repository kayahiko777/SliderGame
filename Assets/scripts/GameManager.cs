using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;

    [Header("�Q�[������")]
    public int gameTime;

    private float timeCounter;
    // Start is called before the first frame update
    void Start()
    {
        //�Q�[�����Ԃ̕\�����X�V
        uiManager.UpdateDisplayGameTime(gameTime);
    }

    // Update is called once per frame
    void Update()
    {
        //�J�E���^�[�����Z
        timeCounter += Time.deltaTime;
        // 1�b�o���Ƃ�
        if (timeCounter >= 1.0f)
        {
            // �J�E���^�[���������B�ēx 0 ������Z���ď�L�̏����ɓ���悤�ɂ���
            timeCounter = 0;
            // �Q�[�����Ԃ�1�b�����炷
            gameTime--;
            // �Q�[�����Ԃ� 0 �ȉ��ɂȂ�����
            if (gameTime <= 0)
            {
                // �}�C�i�X�ɂȂ�Ȃ��悤�� 0 �ɌŒ肷��
                gameTime = 0;
            }

            uiManager.UpdateDisplayGameTime(gameTime);
        }
    }
}
