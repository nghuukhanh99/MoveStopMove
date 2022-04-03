using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GUIManager : MonoBehaviour
{
    public static GUIManager Instance;

    public List<Image> _imgList = new List<Image>();

    public RectTransform PlayButton, SkinShopButton, WeaponShopButton,
                         ZombieModeButton, GoldButton, SoundButton,
                         RemoveAdsButton, VibrateButton, ExpButton, SkinSelector, CloseButton;

    private void Awake()
    {
        InitializeSingleton();
    }

    private void InitializeSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayButtonClick()
    {
        GameManager.Instance.isGameActive = true;

        PlayButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        ZombieModeButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        SoundButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        RemoveAdsButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        VibrateButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        SkinShopButton.DOAnchorPos(new Vector2(-1000f, transform.position.y), 0.5f);

        WeaponShopButton.DOAnchorPos(new Vector2(-1000f, transform.position.y), 0.5f);

        ExpButton.DOAnchorPos(new Vector2(-600f, transform.position.y), 0.5f);

        GoldButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);
    }

    public void WeaponShopButtonClick()
    {
        PlayButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        ZombieModeButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        SoundButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        RemoveAdsButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        VibrateButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        SkinShopButton.DOAnchorPos(new Vector2(-600f, transform.position.y), 0.5f);

        WeaponShopButton.DOAnchorPos(new Vector2(-600f, transform.position.y), 0.5f);

        ExpButton.DOAnchorPos(new Vector2(-600f, transform.position.y), 0.5f);
    }

    public void SkinShopButtonClick()
    {
        PlayButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        ZombieModeButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        SoundButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        RemoveAdsButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        VibrateButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        SkinShopButton.DOAnchorPos(new Vector2(-600f, transform.position.y), 0.5f);

        WeaponShopButton.DOAnchorPos(new Vector2(-600f, transform.position.y), 0.5f);

        ExpButton.DOAnchorPos(new Vector2(-600f, transform.position.y), 0.5f);

        SkinSelector.DOAnchorPos(new Vector2(-370f, -1620f), 0.5f);

        CloseButton.DOAnchorPos(new Vector2(-90f, -1400f), 0.5f);
    }

    public void closeButtonClick()
    {
        CloseButton.DOAnchorPos(new Vector2(800, transform.position.y), 0.5f);

        PlayButton.DOAnchorPos(new Vector2(-128f, 228f), 0.5f);

        ZombieModeButton.DOAnchorPos(new Vector2(-161f, -334f), 0.5f);

        SoundButton.DOAnchorPos(new Vector2(-24.5f, -148.9f), 0.5f);

        RemoveAdsButton.DOAnchorPos(new Vector2(-24.5f, -238f), 0.5f);

        VibrateButton.DOAnchorPos(new Vector2(-24.5f, -323), 0.5f);

        SkinShopButton.DOAnchorPos(new Vector2(170f, 155), 0.5f);

        WeaponShopButton.DOAnchorPos(new Vector2(170f, 305f), 0.5f);

        ExpButton.DOAnchorPos(new Vector2(50f, -50f), 0.5f);

        GoldButton.DOAnchorPos(new Vector2(-51f, -61f), 0.5f);

        SkinSelector.DOAnchorPos(new Vector2(-1723f, -1620f), 0.5f);
    }
}
