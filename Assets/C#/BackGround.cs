using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField, Header("���o����"), Range(0, 1)]//Range ���������ւ񂱂����邳���̍ő�l��ŏ��l�̕ύX
    private float _parallaxEffect;

    private GameObject _camera;
    private float _Length;//�J�����̋���������p�̕ϐ�
    private float _startPosX;//�����ʒu��x���W

    // Start is called before the first frame update
    void Start()
    {
        _startPosX = transform.position.x;
        _Length =GetComponent<SpriteRenderer>().bounds.size.x;
        //�w�i�摜�̉���
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
