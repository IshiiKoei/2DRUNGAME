using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField, Header("視覚効果"), Range(0, 1)]//Range あたいをへんこうするさいの最大値や最小値の変更
    private float _parallaxEffect;

    private GameObject _camera;
    private float _Length;//カメラの距離を入れる用の変数
    private float _startPosX;//初期位置のx座標

    // Start is called before the first frame update
    void Start()
    {
        _startPosX = transform.position.x;
        _Length =GetComponent<SpriteRenderer>().bounds.size.x;
        //背景画像の横幅
        _camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _Parallax();
    }

    private void _Parallax()
    {
        float temp = _camera.transform.position.x * (1 - _parallaxEffect);
        float dist = _camera.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPosX + dist, transform.position.y, transform.position.z);

        if (temp > _startPosX + _Length)
        {
            _startPosX += _Length;
        }
        else if (temp < -_startPosX - _Length)
        {
            _startPosX -= _Length;
        }
    }
}
