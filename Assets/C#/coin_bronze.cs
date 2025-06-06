using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_bronze : MonoBehaviour
{
    public int myScore;
    public PlayerTriggerCheck PlayerCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCheck.isOn)
        {
            if (GManager.instance != null)
            {
                GManager.instance.score += myScore;
                this.gameObject.SetActive(false);
               
            }
        }
    }

        public void Reset()
    {
        Destroy(GManager.instance);
    }
}

