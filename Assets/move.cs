using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// アクター操作・制御クラス
/// </summary>
public class ActorController : MonoBehaviour
{
    static int hashSpeed = Animator.StringToHash("Speed");
    static int hashFallSpeed = Animator.StringToHash("FallSpeed");
    static int hashGroundDistance = Animator.StringToHash("GroundDistance");
    static int hashIsCrouch = Animator.StringToHash("IsCrouch");
    static int hashAttack1 = Animator.StringToHash("Attack1");
    static int hashAttack2 = Animator.StringToHash("Attack2");
    static int hashAttack3 = Animator.StringToHash("Attack3");


    static int hashDamage = Animator.StringToHash("Damage");
    static int hashIsDead = Animator.StringToHash("IsDead");
    // オブジェクト・コンポーネント参照
    [SerializeField] private float characterHeightOffset = 0.2f;
    [SerializeField] LayerMask groundMask;

    [SerializeField, HideInInspector] Animator animator;
    [SerializeField, HideInInspector] SpriteRenderer spriteRenderer;
    [SerializeField, HideInInspector] new Rigidbody2D rigidbody2D; // Rigidbody2Dコンポーネントへの参照

    // 移動関連変数
    private float xSpeed; // X方向移動速度

    private Sprite[] walkSprites;
    float time = 0;
    int idx = 0;

    // Start（オブジェクト有効化時に1度実行）
    void Awake()
    {
        // コンポーネント参照取得
        rigidbody2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator> ();
        Application.targetFrameRate = 60;
    }

    // Update（1フレームごとに1度ずつ実行）
    void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        bool isDown = Input.GetAxisRaw("Vertical") < 0;
        // 左右移動処理
        MoveUpdate();

        var distanceFromGround = Physics2D.Raycast(transform.position, Vector3.down, 1, groundMask);

        animator.SetBool(hashIsCrouch, isDown);
        animator.SetFloat(hashGroundDistance, distanceFromGround.distance == 0 ? 99 : distanceFromGround.distance - characterHeightOffset);
        animator.SetFloat(hashFallSpeed, rigidbody2D.velocity.y);
        animator.SetFloat(hashSpeed, Mathf.Abs(axis));
        if (Input.GetKeyDown(KeyCode.Z)) { animator.SetTrigger(hashAttack1); }
        if (Input.GetKeyDown(KeyCode.X)) { animator.SetTrigger(hashAttack2); }
        if (Input.GetKeyDown(KeyCode.C)) { animator.SetTrigger(hashAttack3); }


    }

    /// <summary>
    /// Updateから呼び出される左右移動入力処理
    /// </summary>
    private void MoveUpdate()
    {
        // X方向移動入力
        if (Input.GetKey(KeyCode.D))
        {// 右方向の移動入力
         // X方向移動速度をプラスに設定
            xSpeed = 3.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {// 左方向の移動入力
         // X方向移動速度をマイナスに設定
            xSpeed = -3.0f;
        }
        else
        {// 入力なし
         // X方向の移動を停止
            xSpeed = 0.0f;
        }

        this.time += Time.deltaTime;
        if (this.time > 0.1f)
        {
            this.time = 0;
            this.spriteRenderer.sprite = this.walkSprites[this.idx];
            this.idx = 1 - this.idx;
        }
    }

    private void FixedUpdate()
    {
        // 移動速度ベクトルを現在値から取得
        Vector2 velocity = rigidbody2D.velocity;
        // X方向の速度を入力から決定
        velocity.x = xSpeed;

        // 計算した移動速度ベクトルをRigidbody2Dに反映
        rigidbody2D.velocity = velocity;
    }
}