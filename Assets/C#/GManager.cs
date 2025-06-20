using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField]
    Text mileageText;
    public int mileagea = 0;
   public  bool timerIsActive = false;
    public Coroutine timer;
    float secondsPerMeter = 0.1f;
    
    

    // Start is called before the first frame update

    
    
    void Start()
    {
        /*if(resetpre != null)
        {
            resetpre.onClick.AddListener(RetryGame);
        }*/
        IsActive = true;
       
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
    public bool IsActive { get; set; } = true;
    public int Mileage
    {
        get
        {
            return mileagea;
        }
        set
        {
            mileagea = Mathf.Max(value, 0);

            UpdateMileageUI();
        }
    }
    void Update()
    {
        if ((!IsActive))
        {
            return;
        }
        if (!timerIsActive)
        {
            timer =
                StartCoroutine(nameof(MileageTimer));
        }
    }
    public void Startgame()
    {
        InitGame();
        IsActive = true;
    }
    void InitGame()
    {
        Mileage = 0;
        timerIsActive = false;
    }
    public IEnumerator MileageTimer()
    {
        timerIsActive = true;
        Mileage++;
        yield return new WaitForSeconds(secondsPerMeter);
        timerIsActive = false;
        /*if (mileagea > 50)
        {
            PlayerMove.instance.moveSpeed = 7.0f;
        }*/


    }
    public void RetryGame()
    {
        point.oldScore = score;
        score = 0;
        SceneManager.LoadScene("restrat");
        scoreprehub.SetActive(false);
       // Startgame();
    }
    public void GameOver()
    {
        //Playerprehub.gameObject.GetComponent<Renderer>().enabled = false;
            /*SetActive(false);*/
        GameOverpre.SetActive(true);
        scoreprehub.SetActive(false);
        

        if (timer != null)
        {
            StopCoroutine(nameof(MileageTimer));
            timerIsActive = false;
        }
        IsActive = false;
        
       
     

    }
    void UpdateMileageUI()
    {
        mileageText.text = mileagea.ToString() + "m";
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





    
