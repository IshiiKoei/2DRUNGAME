using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickstart : MonoBehaviour
{
    [SerializeField] GManager manager;
     void Start()
    {
        manager.score = 0;
    }
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene("2d");
        manager.score = 0;
    }
}
