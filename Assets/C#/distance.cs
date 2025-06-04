using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distance : MonoBehaviour
{
    public Text distancetext;
    public int oscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        distancetext = GetComponent<Text>();
        oscore = 0;

        if (GManager.instance != null)
        {
            distancetext.text = GManager.instance.mileagea.ToString()+"m";
        }
        else
        {
            Debug.Log("ゲームマネージャーを置き忘れてるよ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oscore != GManager.instance.mileagea)
        {
            distancetext.text = GManager.instance.mileagea.ToString()+"m";
            oscore = GManager.instance.mileagea;
        }
    }
}
