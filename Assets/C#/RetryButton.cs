using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    //[SerializeField] GManager manager;
    public Button reset;
    [SerializeField] GameObject _canvas;

    void Start()
    {
        //manager.score = 0;
        if (reset != null)
        {
            reset.onClick.AddListener(RetryGame);
        }
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("restrat");
        GManager.instance.score = 0;
        GManager.instance.mileagea = 0;
        _canvas.SetActive(false);
        //GManager.instance.mileagea = 0;
      //  GManager.instance.timerIsActive = false;
        //GManager.instance = null;
        //GManager.instance.IsActive = true;
        //GManager.instance.Startgame();

    }
}
