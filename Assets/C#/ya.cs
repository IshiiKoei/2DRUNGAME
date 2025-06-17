using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ya : MonoBehaviour
{
    [SerializeField] private GameObject _createprehub;
    [SerializeField] private Transform _rangeA;
    [SerializeField] private Transform _rangeB;
    Rigidbody2D _rd;
    [SerializeField] public float _movespped = 5f;
    
    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rd.velocity = new Vector2(_movespped, _rd.velocity.y);
        if (GManager.instance.mileagea > 200)
        {
            _time = _time + Time.deltaTime;
            if (_time > 10f)
            {
                float x = Random.Range(_rangeA.position.x, _rangeB.position.x);
                float y = Random.Range(_rangeA.position.y, _rangeB.position.y);
                float z = Random.Range(_rangeA.position.z, _rangeB.position.z);
                Instantiate(_createprehub, new Vector3(x, y, z), _createprehub.transform.rotation);
                _time = 0;
                Destroy(_createprehub, 5.0f);
            }
        }
    }
}
