using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlebgm : MonoBehaviour
{
    [SerializeField]AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
