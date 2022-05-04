using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class HeadShopManager : MonoBehaviour
{
    [SerializeField] private HeadManager HeadManager;

    [SerializeField] int HeadIndex;

    [SerializeField] private Button BuyButton;

    [SerializeField] private Button UnEquipButton;

    [SerializeField] private Button EquipButton;

    [SerializeField] private TextMeshProUGUI costText;

    [SerializeField] private Image LockIcon;

    [SerializeField] private Image EquippedIcon;

    private SkinHead skinHead;

    void Start()
    {
        skinHead = HeadManager.skinsHead[7];

        if (HeadManager.IsUnlocked(HeadIndex))
        {
            BuyButton.gameObject.SetActive(false);

            LockIcon.gameObject.SetActive(false);

            EquipButton.gameObject.SetActive(true);

            Instantiate(HeadManager.GetSelectedHead().HeadPrefab, HeadShopController.Instance.HeadHolder);
        }
        else
        {
            BuyButton.gameObject.SetActive(true);

            LockIcon.gameObject.SetActive(true);
        }

        if (HeadManager.IsEquipped(HeadIndex))
        {
            EquippedIcon.gameObject.SetActive(true);

            EquipButton.gameObject.SetActive(false);

            UnEquipButton.gameObject.SetActive(true);
        }

        if (HeadManager.IsUnSelect(HeadIndex))
        {
            EquippedIcon.gameObject.SetActive(false);

            EquipButton.gameObject.SetActive(true);

            UnEquipButton.gameObject.SetActive(false);
        }
    }

    public void OnSkinPressed()
    {
        if (HeadManager.IsUnlocked(HeadIndex))
        {
            HeadManager.SelectHead(HeadIndex);

            BuyButton.gameObject.SetActive(false);
        }
        else
        {
            BuyButton.gameObject.SetActive(true);

            costText.text = skinHead.Cost.ToString();
        }
    }

    public void OnUnEquipButtonPressed()
    {
        foreach(GameObject go in HeadShopController.Instance.EquippedStatus)
        {
            go.gameObject.SetActive(false);

            for(int i = 0; i < HeadShopController.Instance.HeadCount; i++)
            {
                HeadManager.ClearEquip(i);
            }
        }

        foreach(Transform go in HeadShopController.Instance.HeadHolder.transform)
        {
            Destroy(go.gameObject);
        }

        HeadManager.UnSelect(7);

        HeadManager.SelectHead(7);

        EquippedIcon.gameObject.SetActive(false);

        EquipButton.gameObject.SetActive(true);

        UnEquipButton.gameObject.SetActive(false);
    }

    public void OnEquipButtonPressed()
    {
        HeadManager.Unlock(HeadIndex);

        HeadManager.SelectHead(HeadIndex);

        EquippedIcon.gameObject.SetActive(true);

        EquipButton.gameObject.SetActive(false);

        UnEquipButton.gameObject.SetActive(true);

        Instantiate(HeadManager.GetSelectedHead().HeadPrefab, HeadShopController.Instance.HeadHolder);
    }

    public void OnBuyButtonPressed()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);

        if (coins >= skinHead.Cost && !HeadManager.IsUnlocked(HeadIndex))
        {
            PlayerPrefs.SetInt("Coins", coins - skinHead.Cost);

            Instantiate(HeadManager.GetSelectedHead().HeadPrefab, HeadShopController.Instance.HeadHolder);

            HeadManager.Unlock(HeadIndex);

            BuyButton.gameObject.SetActive(false);

            HeadManager.SelectHead(HeadIndex);

            LockIcon.gameObject.SetActive(false);

            foreach (GameObject go in HeadShopController.Instance.EquippedStatus)
            {
                go.gameObject.SetActive(false);

                for (int i = 0; i < HeadShopController.Instance.HeadCount; i++)
                {
                    HeadManager.ClearEquip(i);
                }
            }

            HeadShopController.Instance.EquippedStatus.RemoveRange(0, HeadShopController.Instance.EquippedStatus.Count);

            EquippedIcon.gameObject.SetActive(true);

            PantShopController.Instance.EquippedStatus.Add(EquippedIcon.gameObject);

            HeadManager.Equip(HeadIndex);

            UnEquipButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Not Enough Coins");
        }
    }
    
}
