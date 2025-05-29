using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Grounds : MonoBehaviour
{
    public GameObject Ground;
    GameObject[] step = new GameObject[10];
    float speed = 20;
    float disapper = -10;
    float respawn = 30;
    float timer = 0;
    float spowntime = 2;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < step.Length; i++)
        {
            step[i] = Instantiate(Ground, new Vector3(4 * i, 0, 0), Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer > spowntime)
            {
                PlaneGenerate();
                timer = 0;
            }
            for (int i = 0; i < step.Length; i++)
            {
                step[i].gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
                if (step[i].gameObject.transform.position.x < disapper)
                {
                    ChangeScale(i);
                    step[i].gameObject.transform.position = new Vector3(respawn, 0, 0);
                }
            }
            void PlaneGenerate()
            {
                Instantiate(Ground, new Vector3(1, 0, 0), Quaternion.identity);
            }
            void ChangeScale(int i)
            {
                int x = (i + 9) % 10;
                if (step[x].transform.localScale.y == 0.5)
                {
                    step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(0, 2), 0);
                }
                else
                {
                    step[i].transform.localScale = step[x].transform.localScale + new Vector3(0, Random.Range(-1, 2), 0);
                }
            }
        }
    }
}