using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemsType : MonoBehaviour
{
    public void DefaultPant()
    {
        //if (GameManager.Instance.Coins <= 0)
        //{
        ItemsMenu.IdDefaultPant = 2;

        ItemsMenu.IdBatmanPant = 1;

        PlayerPrefs.SetInt("DefaultPant", ItemsMenu.IdDefaultPant);

        PlayerPrefs.SetInt("BatmanPant", ItemsMenu.IdBatmanPant);

        //GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();
        //}

        //if (GameManager.Instance.Coins >= 0)
        //{
        //    ItemsMenu.IdDefaultPant = 2;

        //    PlayerPrefs.SetInt("DefaultPant", ItemsMenu.IdDefaultPant);

        //    GameManager.Instance.Coins -= 0;

        //    PlayerPrefs.SetInt("Coins", GameManager.Instance.Coins);

        //    GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();
        //}
    }

    public void BatmanPant()
    {
        ItemsMenu.IdBatmanPant = 2;

        ItemsMenu.IdDefaultPant = 1;

        PlayerPrefs.SetInt("BatmanPant", ItemsMenu.IdBatmanPant);

        PlayerPrefs.SetInt("DefaultPant", ItemsMenu.IdDefaultPant);

        //GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();

        //if (GameManager.Instance.Coins >= 200)
        //{
        //    ItemsMenu.IdBatmanPant = 2;

        //    PlayerPrefs.SetInt("BatmanPant", ItemsMenu.IdBatmanPant);

        //    GameManager.Instance.Coins -= 200;

        //    PlayerPrefs.SetInt("Coins", GameManager.Instance.Coins);

        //    GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();
        //}
    }
    public void ChambiPant()
    {
        if(GameManager.Instance.Coins >= 400)
        {
            ItemsMenu.IdChambiPant = 2;

            PlayerPrefs.SetInt("ChambiPant", ItemsMenu.IdChambiPant);

            GameManager.Instance.Coins -= 400;

            PlayerPrefs.SetInt("Coins", GameManager.Instance.Coins);

            GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();
        }
    }

    public void OnionPant()
    {
        if(GameManager.Instance.Coins >= 600)
        {
            ItemsMenu.IdOnionPant = 2;

            PlayerPrefs.SetInt("OnionPant", ItemsMenu.IdOnionPant);

            GameManager.Instance.Coins -= 600;

            PlayerPrefs.SetInt("Coins", GameManager.Instance.Coins);

            GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();
        }
    }

    public void DabaoPant()
    {
        if(GameManager.Instance.Coins >= 800)
        {
            ItemsMenu.IdDabaoPant = 2;

            PlayerPrefs.SetInt("DabaoPant", ItemsMenu.IdDabaoPant);

            GameManager.Instance.Coins -= 800;

            PlayerPrefs.SetInt("Coins", GameManager.Instance.Coins);

            GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();
        }
    }

    public void ResetPurchare()
    {
        PlayerPrefs.DeleteKey("BuyStatus");
    }
}
