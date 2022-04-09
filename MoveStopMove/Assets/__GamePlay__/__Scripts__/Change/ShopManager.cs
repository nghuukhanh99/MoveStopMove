using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[6, 6];

<<<<<<< HEAD
    public int coins;
=======
    public List<GameObject> PantToChange = new List<GameObject>();

    public float coins;
>>>>>>> parent of ade8c88 (Up Again)

    public TextMeshProUGUI CoinsText;

    public string EventTag = "Event";

    // Start is called before the first frame update
    void Start()
    {
        CoinsText.text = coins.ToString();

        // ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;
        shopItems[1, 5] = 5;

        // Price
        shopItems[2, 1] = 0;
        shopItems[2, 2] = 200;
        shopItems[2, 3] = 300;
        shopItems[2, 4] = 400;
        shopItems[2, 5] = 500;
    }

   public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag(EventTag).GetComponent<EventSystem>().currentSelectedGameObject;

        if(coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID] && ButtonRef.GetComponent<ButtonInfo>().Puchased == false)
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];

            CoinsText.text = coins.ToString();

            ButtonRef.GetComponent<ButtonInfo>().BuyStatus(true);

            ButtonRef.GetComponent<ButtonInfo>().DisplayItemStatus(true);
        }
        else if(coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID] && (ButtonRef.GetComponent<ButtonInfo>().Puchased == true))
        {
            ButtonRef.GetComponent<ButtonInfo>().DisplayItemStatus(true);
        }
        else if(coins <= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID] && (ButtonRef.GetComponent<ButtonInfo>().Puchased == true))
        {
            ButtonRef.GetComponent<ButtonInfo>().DisplayItemStatus(true);
        }
    }
}
