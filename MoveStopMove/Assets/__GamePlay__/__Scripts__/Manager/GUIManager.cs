using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public static GUIManager Instance;

    private string AnimGUITagOpen = "IsOpen";

    private string AnimGUITagClose = "IsClose";

    public List<Image> _imgList = new List<Image>();

    public Button SettingButton;

    public Button HomeButton;

    public Button PlayButton;

    public Button ZombieMode;

    public Button GoldButton;

    public Button SoundButton;

    public Button RemoveAdsButton;

    public Button VibrateButton;

    public Button ExpButton;

    public Button SkinShopButton;

    public Button WeaponShopButton;

    public Button closeButton;

    public Button ContinueButton;

    public GameObject showCasePant;

    public GameObject pantPanel;

    public GameObject headPanel;

    public GameObject CanvasSkin;

    public GameObject CanvasGameplay;

    public GameObject CanvasFade;

    public GameObject CanvasWinner;

    public GameObject CanvasLose;

    public GameObject CanvasTopButton;

    public GameObject ControlBoard;

    public GameObject CanvasEnemyCount;

    public Toggle changeSound;

    public Toggle changeVibrate;

    public Image BgchangeSound;

    public Image BgchangeVibrate;

    public TextMeshProUGUI EnemyCountNumber;

    public TextMeshProUGUI CoinsText;

    public Button AddCoinsButton;

    public float timerDelay;

    public Button PantShopButton;

    public Button HeadShopButton;

    public Button ShieldShopButton;

    public Button SkinSetShopButton;

    public GameObject PantShowCase;

    public GameObject HeadShowCase;

    public GameObject ShieldShowCase;

    public GameObject SkinSetShowCase;


    //public GameObject CanvasPlayButton;
    private void Awake()
    {
        InitializeSingleton();
    }
    void Update()
    {
        if(GameManager.Instance.isWin == true)
        {
            timerDelay += Time.deltaTime;
            if(timerDelay >= 1.2f)
            {
                CanvasWinner.SetActive(true);

                CanvasGameplay.SetActive(false);
            }
        }

        if(GameManager.Instance.isLose == true)
        {
            timerDelay += Time.deltaTime;

            if(timerDelay >= 1.2f)
            {
                CanvasLose.SetActive(true);

                CanvasGameplay.SetActive(false);
            }
        }

        EnemyCountNumber.text = GameManager.Instance.TotalAlive.ToString();
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

        PlayButton.animator.SetTrigger(AnimGUITagClose);

        ZombieMode.animator.SetTrigger(AnimGUITagClose);

        GoldButton.animator.SetTrigger(AnimGUITagClose);

        SoundButton.animator.SetTrigger(AnimGUITagClose);

        RemoveAdsButton.animator.SetTrigger(AnimGUITagClose);

        VibrateButton.animator.SetTrigger(AnimGUITagClose);

        ExpButton.animator.SetTrigger(AnimGUITagClose);

        SkinShopButton.animator.SetTrigger(AnimGUITagClose);

        WeaponShopButton.animator.SetTrigger(AnimGUITagClose);

        SettingButton.gameObject.SetActive(true);

        CanvasEnemyCount.gameObject.SetActive(true);

        Invoke("ShowSettingDelay", 1.2f);

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
        PlayButton.animator.SetTrigger(AnimGUITagClose);

        ZombieMode.animator.SetTrigger(AnimGUITagClose);

        SoundButton.animator.SetTrigger(AnimGUITagClose);

        RemoveAdsButton.animator.SetTrigger(AnimGUITagClose);

        VibrateButton.animator.SetTrigger(AnimGUITagClose);

        ExpButton.animator.SetTrigger(AnimGUITagClose);

        SkinShopButton.animator.SetTrigger(AnimGUITagClose);

        WeaponShopButton.animator.SetTrigger(AnimGUITagClose);

        Invoke("showSkinShopDelay", 1.3f);
    }

    public void closeButtonClick()
    {
        PlayButton.animator.SetTrigger(AnimGUITagOpen);

        ZombieMode.animator.SetTrigger(AnimGUITagOpen);

        SoundButton.animator.SetTrigger(AnimGUITagOpen);

        RemoveAdsButton.animator.SetTrigger(AnimGUITagOpen);

        VibrateButton.animator.SetTrigger(AnimGUITagOpen);

        ExpButton.animator.SetTrigger(AnimGUITagOpen);

        SkinShopButton.animator.SetTrigger(AnimGUITagOpen);

        WeaponShopButton.animator.SetTrigger(AnimGUITagOpen);

        CanvasSkin.gameObject.SetActive(false);

        closeButton.gameObject.SetActive(false);
    }
    public void HomeButtonClick()
    {

        CanvasFade.gameObject.SetActive(true);


        StartCoroutine(loadSceneDelay(0));
    }

    public void NextLevel()
    {
        CanvasFade.gameObject.SetActive(true);

        StartCoroutine(loadSceneDelay(1));

    }

    public void ContinueButtonClick()
    {
        ControlBoard.SetActive(false);

        CanvasGameplay.SetActive(true);
    }

    public void settingButtonClick()
    {
        ControlBoard.SetActive(true);

        CanvasGameplay.SetActive(false);

    }

    IEnumerator loadSceneDelay(int buildIndex)
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + buildIndex);
    }

    public void ShowSettingDelay()
    {
        SettingButton.gameObject.SetActive(true);
    }

    public void showSkinShopDelay()
    {
        closeButton.gameObject.SetActive(true);

        CanvasSkin.SetActive(true);
    }

    public void SoundToggle()
    {
        if(changeSound.isOn == true)
        {
            BgchangeSound.rectTransform.DOAnchorPosX(50, 0.25f);
        }
        else
        {
            BgchangeSound.rectTransform.DOAnchorPosX(-50, 0.25f);
        }
    }

    public void VibrateToggle()
    {
        if (changeVibrate.isOn == true)
        {
            BgchangeVibrate.rectTransform.DOAnchorPosX(50, 0.25f);
        }
        else
        {
            BgchangeVibrate.rectTransform.DOAnchorPosX(-50, 0.25f);
        }
    }

    public void PantShowCaseButtonClick()
    {
        PantShowCase.SetActive(true);

        HeadShowCase.SetActive(false);

        ShieldShowCase.SetActive(false);

        SkinSetShowCase.SetActive(false);
    }

    public void HeadShowCaseButtonClick()
    {
        PantShowCase.SetActive(false);

        HeadShowCase.SetActive(true);

        ShieldShowCase.SetActive(false);

        SkinSetShowCase.SetActive(false);
    }

    public void ShieldShowCaseButtonClick()
    {
        PantShowCase.SetActive(false);

        HeadShowCase.SetActive(false);

        ShieldShowCase.SetActive(true);

        SkinSetShowCase.SetActive(false);
    }

    public void SkinSetShowCaseButtonClick()
    {
        PantShowCase.SetActive(false);

        HeadShowCase.SetActive(false);

        ShieldShowCase.SetActive(false);

        SkinSetShowCase.SetActive(true);
    }
}
