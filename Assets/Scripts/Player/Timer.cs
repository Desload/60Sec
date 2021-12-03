using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UniRx;

public class Timer : MonoBehaviour
{
    public float time = 60;
    public GameObject canvasTimer;
    [SerializeField] private CharacterMove move;

    void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            move.speed += 0.2f;
        });
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
