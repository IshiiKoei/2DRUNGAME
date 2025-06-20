using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    // Start is called before the first frame update
    public void StartBottan()
    {
        SceneManager.LoadScene("restrat");
        GManager.instance.score = 0;
        GManager.instance.mileagea = 0;
        _canvas.SetActive(false);
    }
}
