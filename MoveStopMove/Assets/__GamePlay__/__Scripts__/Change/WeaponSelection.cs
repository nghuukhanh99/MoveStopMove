using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    #region Button
    //Button
    [SerializeField] private Button PrevButton;

    [SerializeField] private Button NextButton;
    #endregion

    #region Int
    //Int
    private int currentWeapon;

    public int IDHammer;

    public int IDCandy;

    public int IDKnife;
    #endregion

    #region Image
    public Image HammerIcon;

    public Image CandyIcon;

    public Image KnifeIcon;
    #endregion

    #region List
    public List<Sprite> HammerIconToChange = new List<Sprite>();

    public List<Sprite> CandyIconToChange = new List<Sprite>();

    public List<Sprite> KnifeIconToChange = new List<Sprite>();

    public List<Material> HammerObjectToChange = new List<Material>();

    public List<Material> CandyObjectToChange = new List<Material>();

    public List<Material> KnifeObjectToChange = new List<Material>();

    public List<Texture> textureCandy = new List<Texture>();

    public List<Texture> textureKnife = new List<Texture>();

    public List<Mesh> MeshToChange = new List<Mesh>();

    public List<GameObject> WeaponToChange = new List<GameObject>();

    public List<GameObject> BulletToChange = new List<GameObject>();

    public List<SkinnedMeshRenderer> listWeaponDefault = new List<SkinnedMeshRenderer>();

    #endregion

    #region Other
    //Other
    public Texture textureHammer;

    public SkinnedMeshRenderer WeaponDefault;
    #endregion

    #region String
    string CoinsPrefsTag = "Coins";

    string HammerDefaultPrefsTag = "HammerDefault";

    string HammerDefaultBuyedPrefsTag = "HammerDefaultBuyed";

    string HammerRedPrefsTag = "HammerRed";

    string HammerRedBuyedPrefsTag = "HammerRedBuyed";

    string HammerBlackPrefsTag = "HammerBlack";

    string HammerBlackBuyedPrefsTag = "HammerBlackBuyed";

    string CandyDefaultPrefsTag = "CandyDefault";

    string CandyDefaultBuyedPrefsTag = "CandyDefaultBuyed";

    string CandyBeePrefsTag = "CandyBee";

    string CandyBeeBuyedPrefsTag = "CandyBeeBuyed";


    #endregion
    private void Awake()
    {
        selectWeapon(0);
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt(HammerDefaultPrefsTag) == 2)
        {
            WeaponDefault = listWeaponDefault[0];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

            PlayerCtrl.Instance.bullet = BulletToChange[0];

            WeaponDefault.materials[0].color = HammerObjectToChange[0].color;

            WeaponDefault.materials[1].color = HammerObjectToChange[1].color;

            WeaponDefault.materials[0].mainTexture = textureHammer;

            WeaponDefault.materials[1].mainTexture = textureHammer;

            WeaponToChange[0].gameObject.SetActive(true);

            WeaponToChange[1].gameObject.SetActive(false);

            WeaponToChange[2].gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt(HammerRedPrefsTag) == 2)
        {
            WeaponDefault = listWeaponDefault[0];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

            PlayerCtrl.Instance.bullet = BulletToChange[0];

            WeaponDefault.materials[0].mainTexture = null;

            WeaponDefault.materials[1].mainTexture = null;

            WeaponDefault.materials[0].color = HammerObjectToChange[2].color;

            WeaponDefault.materials[1].color = HammerObjectToChange[3].color;

            WeaponToChange[0].gameObject.SetActive(true);

            WeaponToChange[1].gameObject.SetActive(false);

            WeaponToChange[2].gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt(HammerBlackPrefsTag) == 2)
        {
            WeaponDefault = listWeaponDefault[0];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

            PlayerCtrl.Instance.bullet = BulletToChange[0];

            WeaponDefault.materials[0].mainTexture = null;

            WeaponDefault.materials[1].mainTexture = null;

            WeaponDefault.materials[0].color = HammerObjectToChange[4].color;

            WeaponDefault.materials[1].color = HammerObjectToChange[5].color;

            WeaponToChange[0].gameObject.SetActive(true);

            WeaponToChange[1].gameObject.SetActive(false);

            WeaponToChange[2].gameObject.SetActive(false);
        }

        if(PlayerPrefs.GetInt(CandyDefaultPrefsTag) == 2)
        {
            WeaponDefault = listWeaponDefault[1];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[1];

            PlayerCtrl.Instance.bullet = BulletToChange[1];

            WeaponDefault.materials[0].color = CandyObjectToChange[0].color;

            WeaponDefault.materials[1].color = CandyObjectToChange[0].color;

            WeaponDefault.materials[2].color = CandyObjectToChange[0].color;

            WeaponDefault.materials[0].mainTexture = textureCandy[0];

            WeaponDefault.materials[1].mainTexture = textureCandy[0];

            WeaponDefault.materials[2].mainTexture = textureCandy[0];

            WeaponToChange[0].gameObject.SetActive(false);

            WeaponToChange[1].gameObject.SetActive(true);

            WeaponToChange[2].gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt(CandyBeePrefsTag) == 2)
        {
            WeaponDefault = listWeaponDefault[1];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[1];

            PlayerCtrl.Instance.bullet = BulletToChange[1];

            WeaponDefault.materials[0].color = CandyObjectToChange[1].color;

            WeaponDefault.materials[1].color = CandyObjectToChange[1].color;

            WeaponDefault.materials[2].color = CandyObjectToChange[1].color;

            WeaponDefault.materials[0].mainTexture = textureCandy[1];

            WeaponDefault.materials[1].mainTexture = textureCandy[1];

            WeaponDefault.materials[2].mainTexture = textureCandy[1];

            WeaponToChange[0].gameObject.SetActive(false);

            WeaponToChange[1].gameObject.SetActive(true);

            WeaponToChange[2].gameObject.SetActive(false);
        }
    }

    public void selectWeapon(int _index)
    {
        PrevButton.interactable = (_index != 0);
        NextButton.interactable = (_index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void changeWeapon(int _change)
    {
        currentWeapon += _change;

        selectWeapon(currentWeapon);
    }

    public void ChangeDefaultKnife()
    {
        IDKnife = 0;

        WeaponDefault = listWeaponDefault[2];

        KnifeIcon.sprite = KnifeIconToChange[0];

        PlayerCtrl.Instance.WeaponHand = WeaponToChange[2];

        PlayerCtrl.Instance.bullet = BulletToChange[2];

        WeaponDefault.materials[0].color = KnifeObjectToChange[0].color;

        WeaponDefault.materials[1].color = KnifeObjectToChange[0].color;

        WeaponDefault.materials[0].mainTexture = textureKnife[0];

        WeaponDefault.materials[1].mainTexture = textureKnife[0];

        WeaponToChange[0].gameObject.SetActive(false);

        WeaponToChange[1].gameObject.SetActive(false);

        WeaponToChange[2].gameObject.SetActive(true);
    }

    public void ChangeKnife2()
    {
        IDKnife = 1;

        WeaponDefault = listWeaponDefault[2];

        KnifeIcon.sprite = KnifeIconToChange[1];

        PlayerCtrl.Instance.WeaponHand = WeaponToChange[2];

        PlayerCtrl.Instance.bullet = BulletToChange[2];

        WeaponDefault.materials[0].color = KnifeObjectToChange[1].color;

        WeaponDefault.materials[1].color = KnifeObjectToChange[1].color;

        WeaponDefault.materials[0].mainTexture = textureKnife[1];

        WeaponDefault.materials[1].mainTexture = textureKnife[1];

        WeaponToChange[0].gameObject.SetActive(false);

        WeaponToChange[1].gameObject.SetActive(false);

        WeaponToChange[2].gameObject.SetActive(true);
    }

    public void ChangeDefaultCandy()
    {
        IDCandy = 0;

        WeaponDefault = listWeaponDefault[1];

        CandyIcon.sprite = CandyIconToChange[0];

        PlayerCtrl.Instance.WeaponHand = WeaponToChange[1];

        PlayerCtrl.Instance.bullet = BulletToChange[1];

        WeaponDefault.materials[0].color = CandyObjectToChange[0].color;

        WeaponDefault.materials[1].color = CandyObjectToChange[0].color;

        WeaponDefault.materials[2].color = CandyObjectToChange[0].color;

        WeaponDefault.materials[0].mainTexture = textureCandy[0];

        WeaponDefault.materials[1].mainTexture = textureCandy[0];

        WeaponDefault.materials[2].mainTexture = textureCandy[0];

        WeaponToChange[0].gameObject.SetActive(false);

        WeaponToChange[1].gameObject.SetActive(true);

        WeaponToChange[2].gameObject.SetActive(false);

        
    }

    public void ChangeCandyBee()
    {
        IDCandy = 1;

        WeaponDefault = listWeaponDefault[1];
       
        CandyIcon.sprite = CandyIconToChange[1];

        PlayerCtrl.Instance.WeaponHand = WeaponToChange[1];

        PlayerCtrl.Instance.bullet = BulletToChange[1];

        WeaponDefault.materials[0].color = CandyObjectToChange[1].color;

        WeaponDefault.materials[1].color = CandyObjectToChange[1].color;

        WeaponDefault.materials[2].color = CandyObjectToChange[1].color;

        WeaponDefault.materials[0].mainTexture = textureCandy[1];

        WeaponDefault.materials[1].mainTexture = textureCandy[1];

        WeaponDefault.materials[2].mainTexture = textureCandy[1];

        WeaponToChange[0].gameObject.SetActive(false);

        WeaponToChange[1].gameObject.SetActive(true);

        WeaponToChange[2].gameObject.SetActive(false);

    }

    public void ChangeDefaultHammer()
    {
        IDHammer = 0;

        WeaponDefault = listWeaponDefault[0];

        HammerIcon.sprite = HammerIconToChange[0];

        PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

        PlayerCtrl.Instance.bullet = BulletToChange[0];

        WeaponDefault.materials[0].color = HammerObjectToChange[0].color;

        WeaponDefault.materials[1].color = HammerObjectToChange[1].color;   

        WeaponDefault.materials[0].mainTexture = textureHammer;

        WeaponDefault.materials[1].mainTexture = textureHammer;

        WeaponToChange[0].gameObject.SetActive(true);

        WeaponToChange[1].gameObject.SetActive(false);

        WeaponToChange[2].gameObject.SetActive(false);
    }

    public void ChangeRedHammer()
    {
        IDHammer = 1;

        WeaponDefault = listWeaponDefault[0];

        HammerIcon.sprite = HammerIconToChange[1];

        PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

        PlayerCtrl.Instance.bullet = BulletToChange[0];

        WeaponDefault.materials[0].mainTexture = null;

        WeaponDefault.materials[1].mainTexture = null;

        WeaponDefault.materials[0].color = HammerObjectToChange[2].color;

        WeaponDefault.materials[1].color = HammerObjectToChange[3].color;

        WeaponToChange[0].gameObject.SetActive(true);

        WeaponToChange[1].gameObject.SetActive(false);

        WeaponToChange[2].gameObject.SetActive(false);
    }

    public void ChangeBlackHammer()
    {
        IDHammer = 2;

        WeaponDefault = listWeaponDefault[0];

        HammerIcon.sprite = HammerIconToChange[2];

        PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

        PlayerCtrl.Instance.bullet = BulletToChange[0];

        WeaponDefault.materials[0].mainTexture = null;

        WeaponDefault.materials[1].mainTexture = null;

        WeaponDefault.materials[0].color = HammerObjectToChange[4].color;

        WeaponDefault.materials[1].color = HammerObjectToChange[5].color;

        WeaponToChange[0].gameObject.SetActive(true);

        WeaponToChange[1].gameObject.SetActive(false);

        WeaponToChange[2].gameObject.SetActive(false);
    }

    public void BuyButtonClick()
    {
        switch (IDHammer)
        {
            case 0:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHammer0Status = 0;

                    PlayerPrefs.SetInt(HammerDefaultBuyedPrefsTag, buyedHammer0Status);

                    PlayerPrefs.SetInt(HammerDefaultPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(HammerDefaultPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(HammerDefaultBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 1:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHammer1Status = 1;

                    PlayerPrefs.SetInt(HammerRedBuyedPrefsTag, buyedHammer1Status);

                    PlayerPrefs.SetInt(HammerRedPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(HammerRedPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(HammerRedBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 2:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHammer2Status = 2;

                    PlayerPrefs.SetInt(HammerBlackBuyedPrefsTag, buyedHammer2Status);

                    PlayerPrefs.SetInt(HammerBlackPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(HammerBlackPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(HammerBlackBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;
        }

        switch (IDCandy)
        {
            case 0:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedCandy0Status = 0;

                    PlayerPrefs.SetInt(CandyDefaultBuyedPrefsTag, buyedCandy0Status);

                    PlayerPrefs.SetInt(CandyDefaultPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(CandyDefaultPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(CandyDefaultBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 1:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedCandy1Status = 1;

                    PlayerPrefs.SetInt(CandyBeeBuyedPrefsTag, buyedCandy1Status);

                    PlayerPrefs.SetInt(CandyBeePrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(CandyBeePrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(CandyBeeBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;
        }
    }

    public void EquipButtonClick()
    {
        if (IDHammer == 0 && PlayerPrefs.GetInt(HammerDefaultBuyedPrefsTag) == 0)
        {
            WeaponDefault = listWeaponDefault[0];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

            PlayerCtrl.Instance.bullet = BulletToChange[0];

            WeaponDefault.materials[0].color = HammerObjectToChange[0].color;

            WeaponDefault.materials[1].color = HammerObjectToChange[1].color;

            WeaponDefault.materials[0].mainTexture = textureHammer;

            WeaponDefault.materials[1].mainTexture = textureHammer;

            WeaponToChange[0].gameObject.SetActive(true);

            WeaponToChange[1].gameObject.SetActive(false);

            WeaponToChange[2].gameObject.SetActive(false);

            PlayerPrefs.SetInt(HammerDefaultPrefsTag, 2);

            PlayerPrefs.SetInt(HammerRedPrefsTag, 1);

            PlayerPrefs.SetInt(HammerBlackPrefsTag, 1);
        }

        if (IDHammer == 1 && PlayerPrefs.GetInt(HammerDefaultBuyedPrefsTag) == 1)
        {
            WeaponDefault = listWeaponDefault[0];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

            PlayerCtrl.Instance.bullet = BulletToChange[0];

            WeaponDefault.materials[0].mainTexture = null;

            WeaponDefault.materials[1].mainTexture = null;

            WeaponDefault.materials[0].color = HammerObjectToChange[2].color;

            WeaponDefault.materials[1].color = HammerObjectToChange[3].color;

            WeaponToChange[0].gameObject.SetActive(true);

            WeaponToChange[1].gameObject.SetActive(false);

            WeaponToChange[2].gameObject.SetActive(false);

            PlayerPrefs.SetInt(HammerDefaultPrefsTag, 1);

            PlayerPrefs.SetInt(HammerRedPrefsTag, 2);

            PlayerPrefs.SetInt(HammerBlackPrefsTag, 1);
        }

        if (IDHammer == 2 && PlayerPrefs.GetInt(HammerDefaultBuyedPrefsTag) == 2)
        {
            WeaponDefault = listWeaponDefault[0];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[0];

            PlayerCtrl.Instance.bullet = BulletToChange[0];

            WeaponDefault.materials[0].mainTexture = null;

            WeaponDefault.materials[1].mainTexture = null;

            WeaponDefault.materials[0].color = HammerObjectToChange[4].color;

            WeaponDefault.materials[1].color = HammerObjectToChange[5].color;

            WeaponToChange[0].gameObject.SetActive(true);

            WeaponToChange[1].gameObject.SetActive(false);

            WeaponToChange[2].gameObject.SetActive(false);

            PlayerPrefs.SetInt(HammerDefaultPrefsTag, 1);

            PlayerPrefs.SetInt(HammerRedPrefsTag, 1);

            PlayerPrefs.SetInt(HammerBlackPrefsTag, 2);
        }

        if(IDCandy == 0 && PlayerPrefs.GetInt(CandyDefaultBuyedPrefsTag) == 0)
        {
            WeaponDefault = listWeaponDefault[1];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[1];

            PlayerCtrl.Instance.bullet = BulletToChange[1];

            WeaponDefault.materials[0].color = CandyObjectToChange[0].color;

            WeaponDefault.materials[1].color = CandyObjectToChange[0].color;

            WeaponDefault.materials[2].color = CandyObjectToChange[0].color;

            WeaponDefault.materials[0].mainTexture = textureCandy[0];

            WeaponDefault.materials[1].mainTexture = textureCandy[0];

            WeaponDefault.materials[2].mainTexture = textureCandy[0];

            WeaponToChange[0].gameObject.SetActive(false);

            WeaponToChange[1].gameObject.SetActive(true);

            WeaponToChange[2].gameObject.SetActive(false);

            PlayerPrefs.SetInt(CandyDefaultPrefsTag, 2);

            PlayerPrefs.SetInt(CandyBeePrefsTag, 1);
        }

        if (IDCandy == 1 && PlayerPrefs.GetInt(CandyDefaultBuyedPrefsTag) == 1)
        {
            WeaponDefault = listWeaponDefault[1];

            CandyIcon.sprite = CandyIconToChange[1];

            PlayerCtrl.Instance.WeaponHand = WeaponToChange[1];

            PlayerCtrl.Instance.bullet = BulletToChange[1];

            WeaponDefault.materials[0].color = CandyObjectToChange[1].color;

            WeaponDefault.materials[1].color = CandyObjectToChange[1].color;

            WeaponDefault.materials[2].color = CandyObjectToChange[1].color;

            WeaponDefault.materials[0].mainTexture = textureCandy[1];

            WeaponDefault.materials[1].mainTexture = textureCandy[1];

            WeaponDefault.materials[2].mainTexture = textureCandy[1];

            WeaponToChange[0].gameObject.SetActive(false);

            WeaponToChange[1].gameObject.SetActive(true);

            WeaponToChange[2].gameObject.SetActive(false);

            PlayerPrefs.SetInt(CandyDefaultPrefsTag, 1);

            PlayerPrefs.SetInt(CandyBeePrefsTag, 2);
        }

    }
}
