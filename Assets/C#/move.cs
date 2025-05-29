using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �A�N�^�[����E����N���X
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
    // �I�u�W�F�N�g�E�R���|�[�l���g�Q��
    [SerializeField] private float characterHeightOffset = 0.2f;
    [SerializeField] LayerMask groundMask;

    [SerializeField, HideInInspector] Animator animator;
    [SerializeField, HideInInspector] SpriteRenderer spriteRenderer;
    [SerializeField, HideInInspector] new Rigidbody2D rigidbody2D; // Rigidbody2D�R���|�[�l���g�ւ̎Q��

    // �ړ��֘A�ϐ�
    private float xSpeed; // X�����ړ����x

    private Sprite[] walkSprites;
    float time = 0;
    int idx = 0;

    // Start�i�I�u�W�F�N�g�L��������1�x���s�j
    void Awake()
    {
        // �R���|�[�l���g�Q�Ǝ擾
        rigidbody2D = GetComponent<Rigidbody2D>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator> ();
        Application.targetFrameRate = 60;
    }

    // Update�i1�t���[�����Ƃ�1�x�����s�j
    void Update()
    {
        float axis = Input.GetAxisRaw("Horizontal");
        bool isDown = Input.GetAxisRaw("Vertical") < 0;
        // ���E�ړ�����
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
    /// Update����Ăяo����鍶�E�ړ����͏���
    /// </summary>
    private void MoveUpdate()
    {
        // X�����ړ�����
        if (Input.GetKey(KeyCode.D))
        {// �E�����̈ړ�����
         // X�����ړ����x���v���X�ɐݒ�
            xSpeed = 3.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {// �������̈ړ�����
         // X�����ړ����x���}�C�i�X�ɐݒ�
            xSpeed = -3.0f;
        }
        else
        {// ���͂Ȃ�
         // X�����̈ړ����~
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
        // �ړ����x�x�N�g�������ݒl����擾
        Vector2 velocity = rigidbody2D.velocity;
        // X�����̑��x����͂��猈��
        velocity.x = xSpeed;

        // �v�Z�����ړ����x�x�N�g����Rigidbody2D�ɔ��f
        rigidbody2D.velocity = velocity;
    }
}