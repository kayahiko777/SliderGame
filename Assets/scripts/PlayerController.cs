using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // Rigidbody コンポーネントの操作を行うため、Rigidbody コンポーネントを取得して代入するための変数

    private bool isGoal;

    private float coefficient = 0.985f;

    private float stopValue = 2.5f;

    private Animator anim;

    private int score;

    [Header("移動速度")] // Header属性を変数の宣言に追加すると、インスペクター上に( )内に記述した文字が表示されます
    public float moveSpeed;


    [Header("加速速度")]
    public float accelerationSpeed;

    [Header("ジャンプ力")]
    public float jumpPower;

    [SerializeField]
    private PhysicMaterial pmNoFriction;

    [SerializeField, Header("地面判定用レイヤー")]
    private LayerMask groundLayer;

    [SerializeField, Header("斜面との接地判定")]
    private bool isGrounded;

    [SerializeField]
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        // このスクリプトがアタッチされているゲームオブジェクトが持っている Rigidbody コンポーネントの情報を取得して rb 変数に代入
        rb = GetComponent<Rigidbody>();

        GetComponent<ParticleSystem>().Play();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void FixedUpdate() // <=　Update メソッドではないので注意！
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
    /// 移動
    /// </summary>
    private void Move()
    {
        // キーボードの左右矢印のキー入力を判定し、-1.0f ～ 1.0f までの値を代入
        float x = Input.
            GetAxis("Horizontal");

        // Rigidbody の Velocity(速度)に、キー入力の判定値と移動速度を代入してキャラを移動
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
    /// ブレーキ
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
    /// 加速
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
    /// 速度を徐々に減衰させて停止させる
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
    /// ジャンプ
    /// </summary>
    private void Jump()
    {
        rb.AddForce(transform.up * jumpPower);

        anim.SetTrigger("jump");
    }
    /// <summary>
    /// 斜面との接地判定。true なら接地している状態、false は接地していない状態と定義する
    /// </summary>
    private void CheckGround()
    {
        isGrounded = Physics.Linecast(transform.position, transform.position - transform.up * 0.5f, groundLayer);

        Debug.DrawLine(transform.position, transform.position - transform.up * 0.5f, Color.red);
    }

    /// <summary>
    /// スコア加算
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        score += amount;

        Debug.Log("現在の得点："+ score);

        uiManager.UpdateDisplayScore(score);
    }    
}

