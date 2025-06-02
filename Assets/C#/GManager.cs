using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    //public static GManager instance = null;
    public int score;
    public int stageNum;
    public int continueNum;
    //[SerializeField] Button reset;
    public GameObject resetpre;
    //[SerializeField] GameObject gameoverCanvas;
    public GameObject GameOverpre;
    //[SerializeField] Transform playerTransform;
    public GameObject Playerprehub;
    public GameObject scoreprehub;
    //[SerializeField] GameObject clickstart;
    public static  GManager instance;
    public Score point;

    // Start is called before the first frame update

    void Start()
    {
        /*if(resetpre != null)
        {
            resetpre.onClick.AddListener(RetryGame);
        }*/

    }
    void Awake()
    {
       
        
        
        if (instance != null)
        {
            Destroy(this.gameObject);

        }
        else
        {
            instance = this;
           
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
    public void RetryGame()
    {
        point.oldScore = score;
        score = 0;
        SceneManager.LoadScene("restrat");
    }
    public void GameOver()
    {
        Playerprehub.gameObject.GetComponent<Renderer>().enabled = false;
            /*SetActive(false);*/
        GameOverpre.SetActive(true);
        

    }
    /*public void RetryGame()
    {
        SceneManager.LoadScene("restrat");
        score = 0;

    }
    /*public void Clickstart()
    {
        playerTransform.gameObject.SetActive(true );
        clickstart.SetActive(true);
    }*/
   

}





    
