using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        //�w�i��x���W
        startpos = transform.position.x;
        //�w�i�摜��x�������̕�
        length =
            GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        //�����X�N���[���Ɏg���p�����[�^�[
        float temp =
            (cam.transform.position.x * (1 - parallaxEffect));
        //�w�i�̎��i���ʂɎg�p����p�����[�^�[
        float dist=
            (cam.transform.position.x * parallaxEffect);

        //���o���ʂ�^���鏈��
        //�w�i�摜��x���W��dist�̕��ړ�������
        transform.position = new Vector3(startpos + dist,
                                        transform.position.y,
                                        transform.position.z);
        //�����X�N���[��
        //��ʊO�ɂȂ�����w�i�摜���ړ�������
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos-length) startpos-= length;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
