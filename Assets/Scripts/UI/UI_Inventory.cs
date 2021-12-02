using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform container;
    private Transform itemContainer;
    private Player _player;



    private void Awake()
    {
        container = transform.Find("Container");
        itemContainer = container.Find("itemContainer");
    }
    
    public void RefreshInventory()
    {
        Debug.Log(container);

        foreach(Transform child in container)
        {
            if (child == itemContainer) continue;
            Destroy(child.gameObject) ;
        }
        float x = -24, y = 36;
        foreach(Item item in inventory.GetListItem)
        {            
            RectTransform rectTransform = Instantiate(ItemAssets.Instance.pfTransformItem.gameObject, container).GetComponent<RectTransform>();
            rectTransform.gameObject.SetActive(true);
            rectTransform.anchoredPosition = new Vector2(x, y);
            Image image = rectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x += 48;
            if (x >= 48)
            {
                x = 0;
                y -= 48;
            }
        }        
    }

    public void SetInventory(Inventory inv)
    {
        inventory = inv;

        RefreshInventory();
    }
    public void SetPlayer(Player player)
    {
        _player = player;
    }
}
