using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int oldScore = 0;
   
   
    // Start is called before the first frame update
    void Start()
    {
        oldScore = 0;
        scoreText = GetComponent<Text>();
        


       // DontDestroyOnLoad(scoreText);
        if (GManager.instance != null)
        {
            scoreText.text = "Score"+ GManager.instance.score;
        }
        else
        {
            Debug.Log("ゲームマネージャーを置き忘れてるよ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (oldScore != GManager.instance.score)
        {
            scoreText.text = "Score" + GManager.instance.score;
            oldScore = GManager.instance.score;
        }
       
       
    }
}
