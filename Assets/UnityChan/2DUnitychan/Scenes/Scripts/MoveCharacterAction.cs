using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterAction : MonoBehaviour
{
    static int hashSpeed = Animator.StringToHash("Speed");
    static int hashFallSpeed = Animator.StringToHash("FallSpeed");
	static int hashGroundDistance = Animator.StringToHash("GroundDistance");
	static int hashIsCrouch = Animator.StringToHash("IsCrouch");
	static int hashAttack1 = Animator.StringToHash("Attack1");
	static int hashAttack2 = Animator.StringToHash("Attack2");
	static int hashAttack3 = Animator.StringToHash("Attack3");

	//static int hashDamage = Animator.StringToHash("Damage");
	//static int hashIsDead = Animator.StringToHash("IsDead");//

	[SerializeField] private float characterHeightOffset = 0.2f;
	[SerializeField] LayerMask groundMask;

	[SerializeField, HideInInspector] Animator animator;
	[SerializeField, HideInInspector] SpriteRenderer spriteRenderer;
	[SerializeField, HideInInspector] Rigidbody2D rig2d;
	[SerializeField] private float moveSpeed = 1f;
	public int hp = 4;

	void Awake()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		rig2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float axis = Input.GetAxis("Horizontal");
		bool isDown = Input.GetAxisRaw("Vertical") < 0;

		Vector2 velocity = rig2d.velocity;

		if (axis != 0)
		{
			spriteRenderer.flipX = axis < 0;
			velocity.x = axis * 2;
		}
		rig2d.velocity = new Vector2(moveSpeed,rig2d.velocity.y);
		

		var distanceFromGround = Physics2D.Raycast(transform.position, Vector3.down, 1, groundMask);

		// update animator parameters
		animator.SetBool(hashIsCrouch, isDown);
		animator.SetFloat(hashGroundDistance, distanceFromGround.distance == 0 ? 99 : distanceFromGround.distance - characterHeightOffset);
		animator.SetFloat(hashFallSpeed, rig2d.velocity.y);
		animator.SetFloat(hashSpeed, rig2d.velocity.y);
		if (Input.GetKeyDown(KeyCode.Z)) { animator.SetTrigger(hashAttack1); }
		if (Input.GetKeyDown(KeyCode.X)) { animator.SetTrigger(hashAttack2); }
		if (Input.GetKeyDown(KeyCode.C)) { animator.SetTrigger(hashAttack3); }
	}


	//void OnTriggerEnter2D(Collider2D other)
	//{
		//animator.SetTrigger(hashDamage);
	//}
	
}
