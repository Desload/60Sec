using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 60;
    public GameObject canvasTimer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        canvasTimer.GetComponent<TextMeshProUGUI>().text = time.ToString("f0");
        if (time <= 0)
        {
            //Поражение
        }

    }
}
