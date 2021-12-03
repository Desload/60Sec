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
    [SerializeField] ScopeAdd scopeAdd;
    private bool timeIsEnd = false;


    // Update is called once per frame
    void Update()
    {
        if (timeIsEnd)
            return;

        time -= Time.deltaTime;
        canvasTimer.GetComponent<TextMeshProUGUI>().text = time.ToString("f0");
        if (time <= 0)
        {
            timeIsEnd = true;
            canvasTimer.GetComponent<TextMeshProUGUI>().text = "0";
            scopeAdd.EndGame();
            LevelController.Instance.TimeIsEnd();
        }
    }
}
