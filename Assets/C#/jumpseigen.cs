using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump制限 : MonoBehaviour
{
    public Rigidbody2D rd;
    public float jumpForce;
    int jumpCount;
    public int maxJumpCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) &&jumpCount < maxJumpCount)
        {
            rd.AddForce(new Vector2(0,jumpForce));
            jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
