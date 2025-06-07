using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] GManager manager;
    

    private Rigidbody2D rd;
    public int score;
    private bool isJumping;
    //public static PlayerMove instance;
    


   // public float timer = 5.0f;
    //private PlayerAnimation playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
        rd = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponent<PlayerAnimation>();
        manager.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
    }
    private void FixedUpdate()
    //プレイヤーが自動で動くようにする
    {
        MovePlayer();
        
        // AnimatePlayer();
    }
    private void MovePlayer()
    {
        /*if (Input.GetMouseButtonDown(0) && isStart)
        {
            isStart = true;
        }
        else if (Input.GetMouseButtonDown(0) && isStart)
        {
            isStart = false;
        }
        if (isStart)
        {
            transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        }*/
        
            
                rd.velocity = new Vector2(moveSpeed, rd.velocity.y);
            
        
    }
    private void Jump()
    //ジャンプ関係 (ジャンプ方法、ジャンプ制限)
    { 
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rd.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
        //gameoverの条件
    {
        if(collision.gameObject.tag == "gameover")
        {
            //Destroy(this.gameObject);
            //manager.score = 0;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            GManager.instance.IsActive = false;
            //Destroy(this.gameObject);
            manager.GameOver();
        }
        if(collision.gameObject.tag =="speedup")
        {
            moveSpeed +=0.075f;
        }
    }
    
    /*private void AnimatePlayer()
    {
        playerAnimation.PlayerJump(rd.velocity.y);
        playerAnimation.Running(!isJumping);
    }*/
}

