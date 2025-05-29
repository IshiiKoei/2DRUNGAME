using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump1 : MonoBehaviour
{
    public Rigidbody2D rd;
    public float jumpForce;
    bool isJumping;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rd.AddForce(new Vector2(0, jumpForce));
            isJumping = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
