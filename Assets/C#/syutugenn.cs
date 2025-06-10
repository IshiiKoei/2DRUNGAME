using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syutugenn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10;i++)
        {
            if(GManager.instance.score >i)
            {
                this .gameObject.SetActive(true);
            }
        }
        
    }
}
