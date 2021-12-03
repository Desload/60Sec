using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;


/* Danndx 2021 (youtube.com/danndx)
From video: youtu.be/7h1cnGggY2M
thanks - delete me! :) */


public class SCR_UiInteraction : MonoBehaviour
{
    public GameObject ui_canvas;
    GraphicRaycaster ui_raycaster;

    PointerEventData click_data;
    List<RaycastResult> click_results;

    void Start()
    {
        ui_raycaster = ui_canvas.GetComponent<GraphicRaycaster>();
        click_data = new PointerEventData(EventSystem.current);
        click_results = new List<RaycastResult>();
    }

    void Update()
    {
        // use isPressed if you wish to ray cast every frame:
        //if(Mouse.current.leftButton.isPressed)
        
        // use wasReleasedThisFrame if you wish to ray cast just once per click:
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            GetUiElementsClicked();
        }
    }

    void GetUiElementsClicked()
    {
        /** Get all the UI elements clicked, using the current mouse position and raycasting. **/

        click_data.position = Mouse.current.position.ReadValue();
        click_results.Clear();

        ui_raycaster.Raycast(click_data, click_results);

        foreach(RaycastResult result in click_results)
        {
            GameObject ui_element = result.gameObject;

            Debug.Log(ui_element.name);
        }
    }
}
