using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yamove : MonoBehaviour
{
    [SerializeField] float _movespeed = -2f;
    Rigidbody2D _rd;
    // Start is called before the first frame update
    void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rd.velocity = new Vector2(_movespeed, _rd.velocity.y);
    }
}
