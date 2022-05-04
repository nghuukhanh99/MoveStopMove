using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ShopWeaponState {CantBuy, CanBuy, Select, Equipped}

public enum WeaponType {Hammer, Candy, Knife}

public class WeaponShop : MonoBehaviour
{
    public int[] WeaponPrice = { 1000, 1500, 2000 };

    [SerializeField] private TextMeshProUGUI _CoinsText;

    [SerializeField] private TextMeshProUGUI _WeaponName;

    [SerializeField] private TextMeshProUGUI _CanBuyText;

    [SerializeField] private TextMeshProUGUI _CantBuyText;

    [SerializeField] private Image ShopCurrentWeapon;

    [SerializeField] private Transform _ListWeapon;

    [SerializeField] private Transform WeaponStateButton;

    Dictionary<WeaponType, ShopWeaponState> WeaponShopInfo = new Dictionary<WeaponType, ShopWeaponState>();

    public int WeaponID;

    public void Awake()
    {
        WeaponID = 0;

        for(int i = 0; i < WeaponPrice.Length; i++)
        {

        }
    }
}
