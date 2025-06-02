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

    }
}
