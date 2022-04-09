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

    public bool Puchased;

    public bool display;

    void Start()
    {
        Puchased = false;
    }
    void Update()
    {
        if(Puchased == false)
        {
            priceText.text = ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        }
        
        DisplayItem();
    }

    public void DisplayItem()
    {
        if (display == true && Puchased == true)
        {
            mItem.SetActive(true);

            sItem1.SetActive(false);

            sItem2.SetActive(false);

            sItem3.SetActive(false);

            sItem4.SetActive(false);

            display = false;

            priceText.text = "Unlock";

            locked.SetActive(false);
        }
    }

    public void DisplayItemStatus(bool tOf)
    {
        display = tOf;
    }

    public void BuyStatus(bool Buyed)
    {
        Puchased = Buyed;
    }
}
