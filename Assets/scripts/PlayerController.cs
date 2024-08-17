using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody �R���|�[�l���g�̑�����s�����߁ARigidbody �R���|�[�l���g���擾���đ�����邽�߂̕ϐ�

    private bool isGoal;

    private float coefficient = 0.985f;

    private float stopValue = 2.5f;

    private Animator anim;

    private int score;

    [Header("�ړ����x")] // Header������ϐ��̐錾�ɒǉ�����ƁA�C���X�y�N�^�[���( )���ɋL�q�����������\������܂�
    public float moveSpeed;


    [Header("�������x")]
    public float accelerationSpeed;

    [Header("�W�����v��")]
    public float jumpPower;

    [SerializeField]
    private PhysicMaterial pmNoFriction;

    [SerializeField, Header("�n�ʔ���p���C���[")]
    private LayerMask groundLayer;

    [SerializeField, Header("�ΖʂƂ̐ڒn����")]
    private bool isGrounded;

    [SerializeField]
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        // ���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�������Ă��� Rigidbody �R���|�[�l���g�̏����擾���� rb �ϐ��ɑ��
        rb = GetComponent<Rigidbody>();

        GetComponent<ParticleSystem>().Play();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void FixedUpdate() // <=�@Update ���\�b�h�ł͂Ȃ��̂Œ��ӁI
    {
        if (rb.isKinematic == true)
        {
            return;
        }

        if (isGoal == true)
        {
            DampingSpeed();

            return;
        }

        //
        Move();

        Accelerate();

    }
    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move()
    {
        // �L�[�{�[�h�̍��E���̃L�[���͂𔻒肵�A-1.0f �` 1.0f �܂ł̒l����
        float x = Input.
            GetAxis("Horizontal");

        // Rigidbody �� Velocity(���x)�ɁA�L�[���͂̔���l�ƈړ����x�������ăL�������ړ�
        rb.velocity = new Vector3(x*moveSpeed, rb.velocity.y, rb.velocity.z);

        //Debug.Log(rb.velocity);
    }
    void Update()
    {
        if(isGoal == true)
        {
            return;
        }

        Brake();


        CheckGround();

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }

    /// <summary>
    /// �u���[�L
    /// </summary>
    private void Brake()
    {
        float vertical = Input.GetAxis("Vertical");

        if (vertical <0)
        {
            pmNoFriction.dynamicFriction += Time.deltaTime;

            if (pmNoFriction.dynamicFriction > 1.0f)
            {
                pmNoFriction.dynamicFriction = 1.0f;
            }
        
        }
        else
        {
            pmNoFriction.dynamicFriction = 0.0f;
        }

    }
    /// <summary>
    /// ����
    /// </summary>
    private void Accelerate()
    {
        float vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, accelerationSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("Goal");

            isGoal = true;
            Debug.Log(isGoal);
        }
    }
    /// <summary>
    /// ���x�����X�Ɍ��������Ē�~������
    /// </summary>
    private void DampingSpeed()
    {
        rb.velocity *= coefficient;

        if (rb.velocity.z <= stopValue)
        {
            rb.velocity = Vector3.zero;

            rb.isKinematic = true;
        }
    }

    /// <summary>
    /// �W�����v
    /// </summary>
    private void Jump()
    {
        rb.AddForce(transform.up * jumpPower);

        anim.SetTrigger("jump");
    }
    /// <summary>
    /// �ΖʂƂ̐ڒn����Btrue �Ȃ�ڒn���Ă����ԁAfalse �͐ڒn���Ă��Ȃ���Ԃƒ�`����
    /// </summary>
    private void CheckGround()
    {
        isGrounded = Physics.Linecast(transform.position, transform.position - transform.up * 0.5f, groundLayer);

        Debug.DrawLine(transform.position, transform.position - transform.up * 0.5f, Color.red);
    }

    /// <summary>
    /// �X�R�A���Z
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        score += amount;

        Debug.Log("���݂̓��_�F"+ score);

        uiManager.UpdateDisplayScore(score);
    }    
}

