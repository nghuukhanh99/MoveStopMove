using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopM : MonoBehaviour
{
    int IDPant;

    int IDHead;

    int IDShield;

    public SkinnedMeshRenderer DefaultPant;

    public GameObject posSpawnHead;

    public GameObject posSpawnShield;

    public List<Material> ListPantMaterial = new List<Material>();

    public List<GameObject> ListHead = new List<GameObject>();

    public List<GameObject> ListShield = new List<GameObject>();

    #region//String Tag
    string CoinsPrefsTag = "Coins";

    string ChambiPrefsTag = "Chambi";

    string ComyPrefsTag = "Comy";

    string DabaoPrefsTag = "Dabao";

    string BatmanPrefsTag = "Batman";

    string PokemonPrefsTag = "Pokemon";

    string OnionPrefsTag = "Onion";

    string VantimPrefsTag = "Vantim";

    string RainbowPrefsTag = "Rainbow";

    string ChambiBuyedPrefsTag = "ChambiBuyed";

    string ComyBuyedPrefsTag = "ComyBuyed";

    string DabaoBuyedPrefsTag = "DabaoBuyed";

    string BatmanBuyedPrefsTag = "BatmanBuyed";

    string PokemonBuyedPrefsTag = "PokemonBuyed";

    string OnionBuyedPrefsTag = "OnionBuyed";

    string VantimBuyedPrefsTag = "VantimBuyed";

    string RainbowBuyedPrefsTag = "RainbowBuyed";

    string ArrowHeadPrefsTag = "Arrow";

    string ArrowHeadBuyedPrefsTag = "ArrowBuyed";

    string CowboyHeadPrefsTag = "Cowboy";

    string CowboyHeadBuyedPrefsTag = "CowboyBuyed";

    string PoliceHeadPrefsTag = "Police";

    string PoliceHeadBuyedPrefsTag = "PoliceBuyed";

    string SnapHeadPrefsTag = "Snap";

    string SnapHeadBuyedPrefsTag = "SnapBuyed";

    string TaiNgheHeadPrefsTag = "TaiNghe";

    string TaiNgheHeadBuyedPrefsTag = "TaiNgheBuyed";

    string TaiThoHeadPrefsTag = "TaiTho";

    string TaiThoHeadBuyedPrefsTag = "TaiThoBuyed";

    string MuRomHeadPrefsTag = "MuRom";

    string MuRomHeadBuyedPrefsTag = "MuRomBuyed";

    string CaptainShield1PrefsTag = "CaptainShield1";

    string CaptainShield1BuyedPrefsTag = "CaptainShield1Buyed";

    string CaptainShield2PrefsTag = "CaptainShield2";

    string CaptainShield2BuyedPrefsTag = "CaptainShield2Buyed";


    #endregion
    private void Start()
    {
        #region//Load Pant
        //Pant
        if (PlayerPrefs.GetInt(ChambiPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[0]; 
        }

        if (PlayerPrefs.GetInt(ComyPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[1];
        }

        if (PlayerPrefs.GetInt(DabaoPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[2];
        }

        if (PlayerPrefs.GetInt(BatmanPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[3];
        }

        if (PlayerPrefs.GetInt(PokemonPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[4];
        }

        if (PlayerPrefs.GetInt(OnionPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[5];
        }

        if (PlayerPrefs.GetInt(VantimPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[6];
        }

        if (PlayerPrefs.GetInt(RainbowPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[7];
        }
        #endregion

        #region//Load Head
        // Head
        if (PlayerPrefs.GetInt(ArrowHeadPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject ArrowHead = Instantiate(ListHead[0], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            ArrowHead.transform.SetParent(posSpawnHead.transform);

            ArrowHead.transform.localScale = Vector3.one;
        }

        if (PlayerPrefs.GetInt(CowboyHeadPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject Cowboy = Instantiate(ListHead[1], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            Cowboy.transform.SetParent(posSpawnHead.transform);

            Cowboy.transform.localScale = Vector3.one;
        }

        if (PlayerPrefs.GetInt(PoliceHeadPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject Police = Instantiate(ListHead[2], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            Police.transform.SetParent(posSpawnHead.transform);

            Police.transform.localScale = Vector3.one;
        }

        if (PlayerPrefs.GetInt(SnapHeadPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject Snap = Instantiate(ListHead[3], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            Snap.transform.SetParent(posSpawnHead.transform);

            Snap.transform.localScale = Vector3.one;
        }

        if (PlayerPrefs.GetInt(TaiNgheHeadPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject TaiNghe = Instantiate(ListHead[4], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            TaiNghe.transform.SetParent(posSpawnHead.transform);

            TaiNghe.transform.localScale = Vector3.one;
        }

        if (PlayerPrefs.GetInt(TaiThoHeadPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject TaiTho = Instantiate(ListHead[5], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            TaiTho.transform.SetParent(posSpawnHead.transform);

            TaiTho.transform.localScale = Vector3.one;
        }

        if (PlayerPrefs.GetInt(MuRomHeadPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject MuRom = Instantiate(ListHead[6], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            MuRom.transform.SetParent(posSpawnHead.transform);

            MuRom.transform.localScale = Vector3.one;
        }
        #endregion

        #region//Load Shield
        if(PlayerPrefs.GetInt(CaptainShield1PrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnShield.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject CaptainShield1 = Instantiate(ListShield[0], posSpawnShield.transform.position, posSpawnShield.transform.rotation);

            CaptainShield1.transform.SetParent(posSpawnShield.transform);

            CaptainShield1.transform.localScale = Vector3.one;
        }

        if(PlayerPrefs.GetInt(CaptainShield2PrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnShield.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject CaptainShield2 = Instantiate(ListShield[1], posSpawnShield.transform.position, posSpawnShield.transform.rotation);

            CaptainShield2.transform.SetParent(posSpawnShield.transform);

            CaptainShield2.transform.localScale = Vector3.one;
        }
        #endregion
    }

    #region//PantButtonClick
    public void ChambiPant()
    {
        IDPant = 1;

        DefaultPant.material = ListPantMaterial[0];
    }

    public void ComyPant()
    {
        IDPant = 2;

        DefaultPant.material = ListPantMaterial[1];
    }

    public void DabaoPant()
    {
        IDPant = 3;

        DefaultPant.material = ListPantMaterial[2];
    }

    public void BatmanPant()
    {
        IDPant = 4;

        DefaultPant.material = ListPantMaterial[3];
    }

    public void PokemonPant()
    {
        IDPant = 5;

        DefaultPant.material = ListPantMaterial[4];
    }

    public void OnionPant()
    {
        IDPant = 6;

        DefaultPant.material = ListPantMaterial[5];
    }

    public void VantimPant()
    {
        IDPant = 7;

        DefaultPant.material = ListPantMaterial[6];
    }

    public void RainbowPant()
    {
        IDPant = 8;

        DefaultPant.material = ListPantMaterial[7];
    }

    #endregion

    #region//HeadButtonClick
    public void ArrowHeadButtonClick()
    {
        IDHead = 1;

        foreach(Transform Child in posSpawnHead.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject ArrowHead = Instantiate(ListHead[0], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

        ArrowHead.transform.SetParent(posSpawnHead.transform);

        ArrowHead.transform.localScale = Vector3.one;


    }

    public void CowboyHeadButtonClick()
    {
        IDHead = 2;

        foreach (Transform Child in posSpawnHead.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject Cowboy = Instantiate(ListHead[1], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

        Cowboy.transform.SetParent(posSpawnHead.transform);

        Cowboy.transform.localScale = Vector3.one;
    }

    public void PoliceHeadButtonClick()
    {
        IDHead = 3;

        foreach (Transform Child in posSpawnHead.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject Police = Instantiate(ListHead[2], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

        Police.transform.SetParent(posSpawnHead.transform);

        Police.transform.localScale = Vector3.one;
    }

    public void SnapHeadButtonClick()
    {
        IDHead = 4;

        foreach (Transform Child in posSpawnHead.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject Snap = Instantiate(ListHead[3], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

        Snap.transform.SetParent(posSpawnHead.transform);

        Snap.transform.localScale = Vector3.one;
    }

    public void TaiNgheHeadButtonClick()
    {
        IDHead = 5;

        foreach (Transform Child in posSpawnHead.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject TaiNghe = Instantiate(ListHead[4], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

        TaiNghe.transform.SetParent(posSpawnHead.transform);

        TaiNghe.transform.localScale = Vector3.one;
    }

    public void TaiThoHeadButtonClick()
    {
        IDHead = 6;

        foreach (Transform Child in posSpawnHead.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject TaiTho = Instantiate(ListHead[5], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

        TaiTho.transform.SetParent(posSpawnHead.transform);

        TaiTho.transform.localScale = Vector3.one;
    }

    public void MuRomHeadButtonClick()
    {
        IDHead = 7;

        foreach (Transform Child in posSpawnHead.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject MuRom = Instantiate(ListHead[6], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

        MuRom.transform.SetParent(posSpawnHead.transform);

        MuRom.transform.localScale = Vector3.one;
    }
    #endregion

    #region//ShieldButtonClick
    public void CaptainShield1()
    {
        IDShield = 1;

        foreach (Transform Child in posSpawnShield.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject CaptainShield1 = Instantiate(ListShield[0], posSpawnShield.transform.position, posSpawnShield.transform.rotation);

        CaptainShield1.transform.SetParent(posSpawnShield.transform);

        CaptainShield1.transform.localScale = Vector3.one;
    }

    public void CaptainShield2()
    {
        IDShield = 2;

        foreach (Transform Child in posSpawnShield.transform)
        {
            Destroy(Child.gameObject);
        }

        GameObject CaptainShield2 = Instantiate(ListShield[1], posSpawnShield.transform.position, posSpawnShield.transform.rotation);

        CaptainShield2.transform.SetParent(posSpawnShield.transform);

        CaptainShield2.transform.localScale = Vector3.one;
    }

    #endregion

    public void DeleteKey()
    {
        PlayerPrefs.DeleteAll();
    }

    public void BuyButtonClick()
    {
        // -Coins
       
        // Prefs Coins

        //Display Coins after -

        //Prefs ID Item

        switch (IDPant)
        {
            case 1:
                if(GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedItem1Status = 1;

                    PlayerPrefs.SetInt(ChambiBuyedPrefsTag, buyedItem1Status);

                    PlayerPrefs.SetInt(ChambiPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(ChambiPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(ChambiBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 2:
                if(GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedItem2Status = 2;

                    PlayerPrefs.SetInt(ComyBuyedPrefsTag, buyedItem2Status);

                    PlayerPrefs.SetInt(ComyPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(ComyPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(ComyBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 3:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedItem3Status = 3;

                    PlayerPrefs.SetInt(DabaoBuyedPrefsTag, buyedItem3Status);

                    PlayerPrefs.SetInt(DabaoPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(DabaoPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(DabaoBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 4:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedItem4Status = 4;

                    PlayerPrefs.SetInt(BatmanBuyedPrefsTag, buyedItem4Status);

                    PlayerPrefs.SetInt(BatmanPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(BatmanPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(BatmanBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 5:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedItem5Status = 5;

                    PlayerPrefs.SetInt(PokemonBuyedPrefsTag, buyedItem5Status);

                    PlayerPrefs.SetInt(PokemonPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(PokemonPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(PokemonBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 6:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedItem6Status = 6;

                    PlayerPrefs.SetInt(OnionBuyedPrefsTag, buyedItem6Status);

                    PlayerPrefs.SetInt(OnionPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(OnionPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(OnionBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 7:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedItem7Status = 7;

                    PlayerPrefs.SetInt(VantimBuyedPrefsTag, buyedItem7Status);

                    PlayerPrefs.SetInt(VantimPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(VantimPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(VantimBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 8:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedItem8Status = 8;

                    PlayerPrefs.SetInt(RainbowBuyedPrefsTag, buyedItem8Status);

                    PlayerPrefs.SetInt(RainbowPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(RainbowPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(RainbowBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;
        }

        switch (IDHead)
        {
            case 1:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHead1Status = 1;

                    PlayerPrefs.SetInt(ArrowHeadBuyedPrefsTag, buyedHead1Status);

                    PlayerPrefs.SetInt(ArrowHeadPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(ArrowHeadPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(ArrowHeadBuyedPrefsTag));
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

                    int buyedHead2Status = 2;

                    PlayerPrefs.SetInt(CowboyHeadBuyedPrefsTag, buyedHead2Status);

                    PlayerPrefs.SetInt(CowboyHeadPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(CowboyHeadPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(CowboyHeadBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 3:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHead3Status = 3;

                    PlayerPrefs.SetInt(PoliceHeadBuyedPrefsTag, buyedHead3Status);

                    PlayerPrefs.SetInt(PoliceHeadPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(PoliceHeadPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(PoliceHeadBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 4:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHead4Status = 4;

                    PlayerPrefs.SetInt(SnapHeadBuyedPrefsTag, buyedHead4Status);

                    PlayerPrefs.SetInt(SnapHeadPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(SnapHeadPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(SnapHeadBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 5:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHead5Status = 5;

                    PlayerPrefs.SetInt(TaiNgheHeadBuyedPrefsTag, buyedHead5Status);

                    PlayerPrefs.SetInt(TaiNgheHeadPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(TaiNgheHeadPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(TaiNgheHeadBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 6:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHead6Status = 6;

                    PlayerPrefs.SetInt(TaiThoHeadBuyedPrefsTag, buyedHead6Status);

                    PlayerPrefs.SetInt(TaiThoHeadPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(TaiThoHeadPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(TaiThoHeadBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;

            case 7:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedHead7Status = 7;

                    PlayerPrefs.SetInt(MuRomHeadBuyedPrefsTag, buyedHead7Status);

                    PlayerPrefs.SetInt(MuRomHeadPrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(MuRomHeadPrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(MuRomHeadBuyedPrefsTag));
                }
                else
                {
                    Debug.Log("You don't have enough money!");
                }
                break;
        }

        switch (IDShield)
        {
            case 1:
                if (GameManager.Instance.Coins >= 500)
                {
                    GameManager.Instance.Coins -= 500;

                    PlayerPrefs.SetInt(CoinsPrefsTag, GameManager.Instance.Coins);

                    GUIManager.Instance.CoinsText.text = PlayerPrefs.GetInt(CoinsPrefsTag).ToString();

                    int buyedShield1Status = 1;

                    PlayerPrefs.SetInt(CaptainShield1BuyedPrefsTag, buyedShield1Status);

                    PlayerPrefs.SetInt(CaptainShield1PrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(CaptainShield1PrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(CaptainShield1BuyedPrefsTag));
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

                    int buyedShield2Status = 2;

                    PlayerPrefs.SetInt(CaptainShield2BuyedPrefsTag, buyedShield2Status);

                    PlayerPrefs.SetInt(CaptainShield2PrefsTag, 2);

                    Debug.Log(PlayerPrefs.GetInt(CaptainShield2PrefsTag));

                    Debug.Log(PlayerPrefs.GetInt(CaptainShield2BuyedPrefsTag));
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
        #region//EquipPant
        if (IDPant == 1 && PlayerPrefs.GetInt(ChambiBuyedPrefsTag) == 1)
        {
            DefaultPant.material = ListPantMaterial[0];

            PlayerPrefs.SetInt(ChambiPrefsTag, 2);

            PlayerPrefs.SetInt(ComyPrefsTag, 1);

            PlayerPrefs.SetInt(DabaoPrefsTag, 1);

            PlayerPrefs.SetInt(BatmanPrefsTag, 1);

            PlayerPrefs.SetInt(PokemonPrefsTag, 1);

            PlayerPrefs.SetInt(OnionPrefsTag, 1);

            PlayerPrefs.SetInt(VantimPrefsTag, 1);

            PlayerPrefs.SetInt(RainbowPrefsTag, 1);
        }

        if (IDPant == 2 && PlayerPrefs.GetInt(ComyBuyedPrefsTag) == 2)
        {
            DefaultPant.material = ListPantMaterial[1];

            PlayerPrefs.SetInt(ChambiPrefsTag, 1);

            PlayerPrefs.SetInt(ComyPrefsTag, 2);

            PlayerPrefs.SetInt(DabaoPrefsTag, 1);

            PlayerPrefs.SetInt(BatmanPrefsTag, 1);

            PlayerPrefs.SetInt(PokemonPrefsTag, 1);

            PlayerPrefs.SetInt(OnionPrefsTag, 1);

            PlayerPrefs.SetInt(VantimPrefsTag, 1);

            PlayerPrefs.SetInt(RainbowPrefsTag, 1);
        }

        if (IDPant == 3 && PlayerPrefs.GetInt(DabaoBuyedPrefsTag) == 3)
        {
            DefaultPant.material = ListPantMaterial[2];

            PlayerPrefs.SetInt(ChambiPrefsTag, 1);

            PlayerPrefs.SetInt(ComyPrefsTag, 1);

            PlayerPrefs.SetInt(DabaoPrefsTag, 2);

            PlayerPrefs.SetInt(BatmanPrefsTag, 1);

            PlayerPrefs.SetInt(PokemonPrefsTag, 1);

            PlayerPrefs.SetInt(OnionPrefsTag, 1);

            PlayerPrefs.SetInt(VantimPrefsTag, 1);

            PlayerPrefs.SetInt(RainbowPrefsTag, 1);
        }

        if (IDPant == 4 && PlayerPrefs.GetInt(BatmanBuyedPrefsTag) == 4)
        {
            DefaultPant.material = ListPantMaterial[3];

            PlayerPrefs.SetInt(ChambiPrefsTag, 1);

            PlayerPrefs.SetInt(ComyPrefsTag, 1);

            PlayerPrefs.SetInt(DabaoPrefsTag, 1);

            PlayerPrefs.SetInt(BatmanPrefsTag, 2);

            PlayerPrefs.SetInt(PokemonPrefsTag, 1);

            PlayerPrefs.SetInt(OnionPrefsTag, 1);

            PlayerPrefs.SetInt(VantimPrefsTag, 1);

            PlayerPrefs.SetInt(RainbowPrefsTag, 1);
        }

        if (IDPant == 5 && PlayerPrefs.GetInt(PokemonBuyedPrefsTag) == 5)
        {
            DefaultPant.material = ListPantMaterial[4];

            PlayerPrefs.SetInt(ChambiPrefsTag, 1);

            PlayerPrefs.SetInt(ComyPrefsTag, 1);

            PlayerPrefs.SetInt(DabaoPrefsTag, 1);

            PlayerPrefs.SetInt(BatmanPrefsTag, 1);

            PlayerPrefs.SetInt(PokemonPrefsTag, 2);

            PlayerPrefs.SetInt(OnionPrefsTag, 1);

            PlayerPrefs.SetInt(VantimPrefsTag, 1);

            PlayerPrefs.SetInt(RainbowPrefsTag, 1);
        }

        if (IDPant == 6 && PlayerPrefs.GetInt(OnionBuyedPrefsTag) == 6)
        {
            DefaultPant.material = ListPantMaterial[5];

            PlayerPrefs.SetInt(ChambiPrefsTag, 1);

            PlayerPrefs.SetInt(ComyPrefsTag, 1);

            PlayerPrefs.SetInt(DabaoPrefsTag, 1);

            PlayerPrefs.SetInt(BatmanPrefsTag, 1);

            PlayerPrefs.SetInt(PokemonPrefsTag, 1);

            PlayerPrefs.SetInt(OnionPrefsTag, 2);

            PlayerPrefs.SetInt(VantimPrefsTag, 1);

            PlayerPrefs.SetInt(RainbowPrefsTag, 1);
        }

        if (IDPant == 7 && PlayerPrefs.GetInt(VantimBuyedPrefsTag) == 7)
        {
            DefaultPant.material = ListPantMaterial[6];

            PlayerPrefs.SetInt(ChambiPrefsTag, 1);

            PlayerPrefs.SetInt(ComyPrefsTag, 1);

            PlayerPrefs.SetInt(DabaoPrefsTag, 1);

            PlayerPrefs.SetInt(BatmanPrefsTag, 1);

            PlayerPrefs.SetInt(PokemonPrefsTag, 1);

            PlayerPrefs.SetInt(OnionPrefsTag, 1);

            PlayerPrefs.SetInt(VantimPrefsTag, 2);

            PlayerPrefs.SetInt(RainbowPrefsTag, 1);
        }

        if (IDPant == 8 && PlayerPrefs.GetInt(RainbowBuyedPrefsTag) == 8)
        {
            DefaultPant.material = ListPantMaterial[7];

            PlayerPrefs.SetInt(ChambiPrefsTag, 1);

            PlayerPrefs.SetInt(ComyPrefsTag, 1);

            PlayerPrefs.SetInt(DabaoPrefsTag, 1);

            PlayerPrefs.SetInt(BatmanPrefsTag, 1);

            PlayerPrefs.SetInt(PokemonPrefsTag, 1);

            PlayerPrefs.SetInt(OnionPrefsTag, 1);

            PlayerPrefs.SetInt(VantimPrefsTag, 1);

            PlayerPrefs.SetInt(RainbowPrefsTag, 2);
        }
        #endregion

        #region//EquipHead
        if (IDHead == 1 && PlayerPrefs.GetInt(ArrowHeadBuyedPrefsTag) == 1)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject ArrowHead = Instantiate(ListHead[0], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            ArrowHead.transform.SetParent(posSpawnHead.transform);

            ArrowHead.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(ArrowHeadPrefsTag, 2);

            PlayerPrefs.SetInt(CowboyHeadPrefsTag, 1);

            PlayerPrefs.SetInt(PoliceHeadPrefsTag, 1);

            PlayerPrefs.SetInt(SnapHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiNgheHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiThoHeadPrefsTag, 1);

            PlayerPrefs.SetInt(MuRomHeadPrefsTag, 1);
        }

        if (IDHead == 2 && PlayerPrefs.GetInt(CowboyHeadBuyedPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject Cowboy = Instantiate(ListHead[1], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            Cowboy.transform.SetParent(posSpawnHead.transform);

            Cowboy.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(ArrowHeadPrefsTag, 1);

            PlayerPrefs.SetInt(CowboyHeadPrefsTag, 2);

            PlayerPrefs.SetInt(PoliceHeadPrefsTag, 1);

            PlayerPrefs.SetInt(SnapHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiNgheHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiThoHeadPrefsTag, 1);

            PlayerPrefs.SetInt(MuRomHeadPrefsTag, 1);
        }

        if (IDHead == 3 && PlayerPrefs.GetInt(PoliceHeadBuyedPrefsTag) == 3)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject Police = Instantiate(ListHead[2], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            Police.transform.SetParent(posSpawnHead.transform);

            Police.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(ArrowHeadPrefsTag, 1);

            PlayerPrefs.SetInt(CowboyHeadPrefsTag, 1);

            PlayerPrefs.SetInt(PoliceHeadPrefsTag, 2);

            PlayerPrefs.SetInt(SnapHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiNgheHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiThoHeadPrefsTag, 1);

            PlayerPrefs.SetInt(MuRomHeadPrefsTag, 1);
        }

        if (IDHead == 4 && PlayerPrefs.GetInt(SnapHeadBuyedPrefsTag) == 4)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject Snap = Instantiate(ListHead[3], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            Snap.transform.SetParent(posSpawnHead.transform);

            Snap.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(ArrowHeadPrefsTag, 1);

            PlayerPrefs.SetInt(CowboyHeadPrefsTag, 1);

            PlayerPrefs.SetInt(PoliceHeadPrefsTag, 1);

            PlayerPrefs.SetInt(SnapHeadPrefsTag, 2);

            PlayerPrefs.SetInt(TaiNgheHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiThoHeadPrefsTag, 1);

            PlayerPrefs.SetInt(MuRomHeadPrefsTag, 1);
        }

        if (IDHead == 5 && PlayerPrefs.GetInt(TaiNgheHeadBuyedPrefsTag) == 5)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject TaiNghe = Instantiate(ListHead[4], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            TaiNghe.transform.SetParent(posSpawnHead.transform);

            TaiNghe.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(ArrowHeadPrefsTag, 1);

            PlayerPrefs.SetInt(CowboyHeadPrefsTag, 1);

            PlayerPrefs.SetInt(PoliceHeadPrefsTag, 1);

            PlayerPrefs.SetInt(SnapHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiNgheHeadPrefsTag, 2);

            PlayerPrefs.SetInt(TaiThoHeadPrefsTag, 1);

            PlayerPrefs.SetInt(MuRomHeadPrefsTag, 1);
        }

        if (IDHead == 6 && PlayerPrefs.GetInt(TaiThoHeadBuyedPrefsTag) == 6)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject TaiTho = Instantiate(ListHead[5], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            TaiTho.transform.SetParent(posSpawnHead.transform);

            TaiTho.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(ArrowHeadPrefsTag, 1);

            PlayerPrefs.SetInt(CowboyHeadPrefsTag, 1);

            PlayerPrefs.SetInt(PoliceHeadPrefsTag, 1);

            PlayerPrefs.SetInt(SnapHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiNgheHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiThoHeadPrefsTag, 2);

            PlayerPrefs.SetInt(MuRomHeadPrefsTag, 1);
        }

        if (IDHead == 7 && PlayerPrefs.GetInt(MuRomHeadBuyedPrefsTag) == 7)
        {
            foreach (Transform Child in posSpawnHead.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject MuRom = Instantiate(ListHead[6], posSpawnHead.transform.position, posSpawnHead.transform.rotation);

            MuRom.transform.SetParent(posSpawnHead.transform);

            MuRom.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(ArrowHeadPrefsTag, 1);

            PlayerPrefs.SetInt(CowboyHeadPrefsTag, 1);

            PlayerPrefs.SetInt(PoliceHeadPrefsTag, 1);

            PlayerPrefs.SetInt(SnapHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiNgheHeadPrefsTag, 1);

            PlayerPrefs.SetInt(TaiThoHeadPrefsTag, 1);

            PlayerPrefs.SetInt(MuRomHeadPrefsTag, 2);
        }
        #endregion

        #region//EquipShield
        if (IDShield == 1 && PlayerPrefs.GetInt(CaptainShield1BuyedPrefsTag) == 1)
        {
            foreach (Transform Child in posSpawnShield.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject CaptainShield1 = Instantiate(ListShield[0], posSpawnShield.transform.position, posSpawnShield.transform.rotation);

            CaptainShield1.transform.SetParent(posSpawnShield.transform);

            CaptainShield1.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(CaptainShield1PrefsTag, 2);

            PlayerPrefs.SetInt(CaptainShield2PrefsTag, 1);
        }

        if (IDShield == 2 && PlayerPrefs.GetInt(CaptainShield2BuyedPrefsTag) == 2)
        {
            foreach (Transform Child in posSpawnShield.transform)
            {
                Destroy(Child.gameObject);
            }

            GameObject CaptainShield2 = Instantiate(ListShield[1], posSpawnShield.transform.position, posSpawnShield.transform.rotation);

            CaptainShield2.transform.SetParent(posSpawnShield.transform);

            CaptainShield2.transform.localScale = Vector3.one;

            PlayerPrefs.SetInt(CaptainShield1PrefsTag, 1);

            PlayerPrefs.SetInt(CaptainShield2PrefsTag, 2);
        }
        #endregion
    }

    public void closeButtonClick()
    {
        GUIManager.Instance.PlayButton.animator.SetTrigger(GUIManager.Instance.AnimGUITagOpen);

        GUIManager.Instance.ZombieMode.animator.SetTrigger(GUIManager.Instance.AnimGUITagOpen);

        GUIManager.Instance.SoundButton.animator.SetTrigger(GUIManager.Instance.AnimGUITagOpen);

        GUIManager.Instance.RemoveAdsButton.animator.SetTrigger(GUIManager.Instance.AnimGUITagOpen);

        GUIManager.Instance.VibrateButton.animator.SetTrigger(GUIManager.Instance.AnimGUITagOpen);

        GUIManager.Instance.ExpButton.animator.SetTrigger(GUIManager.Instance.AnimGUITagOpen);

        GUIManager.Instance.SkinShopButton.animator.SetTrigger(GUIManager.Instance.AnimGUITagOpen);

        GUIManager.Instance.WeaponShopButton.animator.SetTrigger(GUIManager.Instance.AnimGUITagOpen);

        GUIManager.Instance.CanvasSkin.gameObject.SetActive(false);

        GUIManager.Instance.closeButton.gameObject.SetActive(false);
    }
}
