using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HeadShopController : MonoBehaviour
{
    public static HeadShopController Instance;

    public GameObject Head;

    public Transform HeadHolder;

    [SerializeField] private TextMeshProUGUI coinsText;

    [SerializeField] private HeadManager headManager;

    public List<GameObject> EquippedStatus = new List<GameObject>();

    public int HeadCount = 8;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = PlayerPrefs.GetInt("Coins").ToString();

        Head = headManager.GetSelectedHead().HeadPrefab;
    }
}
