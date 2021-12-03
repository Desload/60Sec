using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class UI_HideMenu : MonoBehaviour
{
    [SerializeField] private Image[] panel;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        DOVirtual.Float(255, 0, 5f, Transparency);
    }

    private void Transparency(float trans)
    {
        foreach(var image in panel)
            image.color = new Color(255, 255, 255, trans);

        text.color = new Color(255, 255, 255, trans);
    }
}
