using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;

    public TextMeshProUGUI priceText;

    public GameObject locked;

    public GameObject ShopManager;

    public GameObject mItem;

    public GameObject sItem1;

    public GameObject sItem2;

    public GameObject sItem3;

    public GameObject sItem4;

    public int display;

    public int _buyValue;

    public string PrefsBuyValue = "PrefsBuyValue";

    void Start()
    {
        _buyValue = 0;

        display = 0;


    }
    void Update()
    {
        if(_buyValue == 0)
        {
            priceText.text = ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        }
        
        DisplayItem();
    }

    public void DisplayItem()
    {
        if (display == 1 && _buyValue == 1)
        {
            mItem.SetActive(true);

            sItem1.SetActive(false);

            sItem2.SetActive(false);

            sItem3.SetActive(false);

            sItem4.SetActive(false);

            display = 0;

            priceText.text = "Unlock";

            locked.SetActive(false);
        }
    }

    public void DisplayItemStatus(int DisplayOrUndisplay) // 1 or 0
    {
        display = DisplayOrUndisplay;
    }

    public void BuyStatus(int buyValue)
    {
        _buyValue = buyValue;   
    }
}
