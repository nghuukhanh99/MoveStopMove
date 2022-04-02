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
                         RemoveAdsButton, VibrateButton, ExpButton;

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
        PlayButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        ZombieModeButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        SoundButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        RemoveAdsButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        VibrateButton.DOAnchorPos(new Vector2(600f, transform.position.y), 0.5f);

        SkinShopButton.DOAnchorPos(new Vector2(-1000f, transform.position.y), 0.5f);

        WeaponShopButton.DOAnchorPos(new Vector2(-1000f, transform.position.y), 0.5f);

        ExpButton.DOAnchorPos(new Vector2(-600f, transform.position.y), 0.5f);
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
    }
}
