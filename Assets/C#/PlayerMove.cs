using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] GManager manager;
    public GameObject speedup;
    [SerializeField] public AudioSource a;
    [SerializeField] public AudioSource b;
    [SerializeField]public AudioSource c;
    [SerializeField] public AudioClip _bu;
    [SerializeField] public AudioClip _ch;
    

    private Rigidbody2D rd;
    public int score;
    private bool isJumping;
    private float timer2;
    private bool isTouch;
    //public static PlayerMove instance;
    


   // public float timer = 5.0f;
    //private PlayerAnimation playerAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
        rd = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponent<PlayerAnimation>();
        manager.score = 0;
        timer2 = 1f;
        isTouch = false;
        b.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
       /* if(isTouch )
        {
            timer2 -= Time.deltaTime;
            if(timer2 <= 0 )
            {
                Destroy(this);
            }

        }*/
        
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
            //Time.timeScale = 0;
           this.gameObject.GetComponent<Renderer>().enabled = false;
            GManager.instance.IsActive = false;
            rd.isKinematic = true;
           // gameObject.SetActive(false);
            b.Stop();
            c.PlayOneShot(_ch);
            moveSpeed = 3f;
            //isTouch = true;
            //timer += Time.deltaTime;
            //Destroy(this.gameObject);
            //Destroy(this, 3.0f);
            //Invoke(nameof(GM), 1.0f);
                manager.GameOver();
            

            
        }
        if(collision.gameObject.tag =="kabe")
        {
            moveSpeed = -0.7f;
           // rd.AddForce(new Vector2(-5.0f,0f), ForceMode2D.Impulse);
            rd.velocity = Vector2.zero;
            a.PlayOneShot(_bu);
            
        }
        if(collision.gameObject.tag =="speedup")
        {
            moveSpeed +=0.075f;
            speedup.SetActive(true);
            Invoke("Speed", 1.0f);
        }
    }
    void Speed()
    {
        speedup.SetActive(false);
    }
    
   /* void GM()
    {
        manager.GameOver();
    }*/
    /*private void AnimatePlayer()
    {
        playerAnimation.PlayerJump(rd.velocity.y);
        playerAnimation.Running(!isJumping);
    }*/
}

