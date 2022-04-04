using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public static GUIManager Instance;

    public List<Image> _imgList = new List<Image>();

    public RectTransform PlayButton;

    public Button pantIcon;

    public Button HeadIcon;

    public Button SettingButton;

    public Button HomeButton;

    public GameObject pantPanel;

    public GameObject headPanel;

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

        PlayButton.DOMoveX(200f, 0.5f);

        if (CameraSwitcher.IsActiveCamera(GameManager.Instance.cameraOnMenu))
        {
            CameraSwitcher.SwitchCamera(GameManager.Instance.cameraOnShop);
        }
        else if (CameraSwitcher.IsActiveCamera(GameManager.Instance.cameraOnShop))
        {
            CameraSwitcher.SwitchCamera(GameManager.Instance.cameraOnMenu);
        }
    }

    public void WeaponShopButtonClick()
    {
        
    }

    public void SkinShopButtonClick()
    {
        
    }

    public void closeButtonClick()
    {
        
    }

    public void openHeadTab()
    {
        pantPanel.gameObject.SetActive(false);

        headPanel.gameObject.SetActive(true);
    }

    public void openPantTab()
    {
        pantPanel.gameObject.SetActive(true);

        headPanel.gameObject.SetActive(false);
    }

    public void HomeButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void settingButtonClick()
    {
        HomeButton.gameObject.SetActive(true);
    }
}
