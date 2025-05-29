using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerJump(float velY)
    {
        animator.SetFloat("Jump", velY);
    }
    public void Running(bool running)
    {
        animator.SetBool("Run", running);
    }
}
