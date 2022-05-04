using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PantShopController : MonoBehaviour
{
    public static PantShopController Instance;

    public SkinnedMeshRenderer Pant;

    [SerializeField] private TextMeshProUGUI coinsText;

    [SerializeField] private PantManager pantManager;

    public List<GameObject> EquippedStatus = new List<GameObject>();

    public List<GameObject> ListEquipButton = new List<GameObject>();

    public List<GameObject> ListUnEquipButton = new List<GameObject>();

    public int PantCount = 9;

    public void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        coinsText.text = PlayerPrefs.GetInt("Coins").ToString();

        Pant.material = pantManager.GetSelectedPant().MaterialPant;
    }
}
