using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private  void OnTriggerEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag.Equals("Player"))
        {
           GetComponent<ItemBase>().Get();
            
        }
    }
}
