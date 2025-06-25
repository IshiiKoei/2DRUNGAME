using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baru : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _canvas;
    public void Batubotton()
    {
        _canvas.SetActive(false);
    }
}
