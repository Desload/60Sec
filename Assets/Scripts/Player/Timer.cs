using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float time=60;
    public GameObject canvasTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        canvasTimer.GetComponent<Text>().text = time.ToString("f0");
        if (time <= 0)
        {
            //���������
        }

        }
}