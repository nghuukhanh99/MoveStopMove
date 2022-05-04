using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ShopPantManager : MonoBehaviour
{
    [SerializeField] private PantManager pantManager;

    [SerializeField] int PantIndex;

    [SerializeField] private Button BuyButton;

    [SerializeField] private Button UnEquipButton;

    [SerializeField] private Button EquipButton;

    [SerializeField] private TextMeshProUGUI costText;

    [SerializeField] private Image LockIcon;

    [SerializeField] private Image EquippedIcon;

    private Skin skinPant;
    void Start()
    {
        skinPant = pantManager.skinsPant[0];

        if (pantManager.IsUnlocked(PantIndex))
        {
            BuyButton.gameObject.SetActive(false);

            LockIcon.gameObject.SetActive(false);

            EquipButton.gameObject.SetActive(true);
        }
        else
        {
            BuyButton.gameObject.SetActive(true);

            LockIcon.gameObject.SetActive(true);
        }

        if (pantManager.IsEquipped(PantIndex))
        {
            EquippedIcon.gameObject.SetActive(true);

            EquipButton.gameObject.SetActive(false);

            UnEquipButton.gameObject.SetActive(true);
        }

        if (pantManager.IsUnSelect(PantIndex))
        {
            EquippedIcon.gameObject.SetActive(false);

            EquipButton.gameObject.SetActive(true);

            UnEquipButton.gameObject.SetActive(false);
        }
    }

    public void OnSkinPressed()
    {
        if (pantManager.IsUnlocked(PantIndex))
        {
            pantManager.SelectPant(PantIndex);

            BuyButton.gameObject.SetActive(false);
        }
        else
        {
            BuyButton.gameObject.SetActive(true);

            costText.text = skinPant.cost.ToString();
        }
    }

    public void OnUnEquipButtonPressed()
    {
        foreach (GameObject go in PantShopController.Instance.EquippedStatus)
        {
            go.gameObject.SetActive(false);

            for (int i = 0; i < PantShopController.Instance.PantCount; i++)
            {
                pantManager.ClearEquip(i);
            }
        }

        pantManager.UnSelect(PantIndex);

        pantManager.SelectPant(0);

        EquippedIcon.gameObject.SetActive(false);

        EquipButton.gameObject.SetActive(true);

        UnEquipButton.gameObject.SetActive(false);
    }

    public void OnEquipButtonPressed()
    {
        pantManager.Unlock(PantIndex);

        pantManager.SelectPant(PantIndex);

        EquippedIcon.gameObject.SetActive(true);

        EquipButton.gameObject.SetActive(false);

        UnEquipButton.gameObject.SetActive(true);
    }

    public void OnBuyButtonPressed()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);

        if (coins >= skinPant.cost && !pantManager.IsUnlocked(PantIndex)) // check du tien hay k va da unlock hay chua
        {
            PlayerPrefs.SetInt("Coins", coins - skinPant.cost);

            pantManager.Unlock(PantIndex);

            BuyButton.gameObject.SetActive(false);
            
            pantManager.SelectPant(PantIndex);

            LockIcon.gameObject.SetActive(false);

            foreach (GameObject go in PantShopController.Instance.EquippedStatus)
            {
                go.gameObject.SetActive(false);

                for(int i = 0; i < PantShopController.Instance.PantCount; i++)
                {
                    pantManager.ClearEquip(i);
                }
            }

            PantShopController.Instance.EquippedStatus.RemoveRange(0, PantShopController.Instance.EquippedStatus.Count);

            EquippedIcon.gameObject.SetActive(true);

            PantShopController.Instance.EquippedStatus.Add(EquippedIcon.gameObject);

            pantManager.Equip(PantIndex);

            UnEquipButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Not Enough Coins");
        }
    }
}
