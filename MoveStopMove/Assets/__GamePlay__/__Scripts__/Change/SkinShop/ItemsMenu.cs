using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemsMenu : MonoBehaviour
{
    public GameObject DefaultPant;

    public static int IdDefaultPant;

    public int PriceDefaultPant;

    public GameObject BatmanPant;

    public static int IdBatmanPant;

    public int PriceBatmanPant;

    public GameObject ChambiPant;

    public static int IdChambiPant;

    public int PriceChambiPant;

    public GameObject OnionPant;

    public static int IdOnionPant;

    public int PriceOnionPant;

    public GameObject DabaoPant;

    public static int IdDabaoPant;

    public int PriceDabaoPant;

    void Start()
    {
        IdDefaultPant = PlayerPrefs.GetInt("DefaultPant",1);

        IdBatmanPant = PlayerPrefs.GetInt("BatmanPant",1);

        IdChambiPant = PlayerPrefs.GetInt("ChambiPant",1);

        IdOnionPant = PlayerPrefs.GetInt("OnionPant",1);

        IdDabaoPant = PlayerPrefs.GetInt("DabaoPant",1);

        PriceDefaultPant = 0;

        PriceBatmanPant = 200;

        PriceChambiPant = 400;

        PriceOnionPant = 600;

        PriceDabaoPant = 800;
    }

    
    void Update()
    {
        if(IdDefaultPant == 1)
        {
            DefaultPant.SetActive(false);
        }
        
        if(IdDefaultPant == 2)
        {
            DefaultPant.SetActive(true);

            BatmanPant.SetActive(false);

            ChambiPant.SetActive(false);

            OnionPant.SetActive(false);

            DabaoPant.SetActive(false);

            if(GameManager.Instance.Coins >= PriceDefaultPant)
            {
                GameManager.Instance.Coins -= 0;

                PlayerPrefs.SetInt("Coins", GameManager.Instance.Coins);

                GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();

                PriceDefaultPant = 0;

                PlayerPrefs.SetInt("PriceDefaultPant", PriceDefaultPant);
            }
        }

        if (IdBatmanPant == 2)
        {
            BatmanPant.SetActive(true);

            DefaultPant.SetActive(false);

            ChambiPant.SetActive(false);

            OnionPant.SetActive(false);

            DabaoPant.SetActive(false);

            if(GameManager.Instance.Coins >= 200)
            {
                GameManager.Instance.Coins -= 200;

                PlayerPrefs.SetInt("Coins", GameManager.Instance.Coins);

                GameManager.Instance.CoinsText.text = GameManager.Instance.Coins.ToString();
            }
        }

        if (IdChambiPant == 1)
        {
            ChambiPant.SetActive(false);
        }
        if (IdChambiPant == 2)
        {
            ChambiPant.SetActive(true);

            DefaultPant.SetActive(false);

            BatmanPant.SetActive(false);

            OnionPant.SetActive(false);

            DabaoPant.SetActive(false);
        }

        if (IdOnionPant == 1)
        {
            OnionPant.SetActive(false);
        }
        if (IdOnionPant == 2)
        {
            OnionPant.SetActive(true);

            DefaultPant.SetActive(false);

            BatmanPant.SetActive(false);

            ChambiPant.SetActive(false);

            DabaoPant.SetActive(false);
        }

        if (IdDabaoPant == 1)
        {
            DabaoPant.SetActive(false);
        }
        if (IdDabaoPant == 2)
        {
            DabaoPant.SetActive(true);

            DefaultPant.SetActive(false);

            BatmanPant.SetActive(false);

            ChambiPant.SetActive(false);

            OnionPant.SetActive(false);
        }
    }


    public void ResetPurchare()
    {
        PlayerPrefs.DeleteKey("BuyStatus");
    }

    public void ReseT()
    {
        IdDefaultPant = 1;

        PlayerPrefs.SetInt("DefaultPant", IdDefaultPant);

        IdBatmanPant = 1;

        PlayerPrefs.SetInt("BatmanPant", IdBatmanPant);

        IdChambiPant = 1;

        PlayerPrefs.SetInt("ChambiPant", IdChambiPant);

        IdOnionPant = 1;

        PlayerPrefs.SetInt("OnionPant", IdOnionPant);

        IdDabaoPant = 1;

        PlayerPrefs.SetInt("DabaoPant", IdDabaoPant);

        PlayerPrefs.DeleteKey("Coins");

        GameManager.Instance.Coins = 0;

        PlayerPrefs.SetInt("Coins", GameManager.Instance.Coins);

        GameManager.Instance.CoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
