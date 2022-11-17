using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : GenericSingleton<UIHandler>
{
    [SerializeField]
    private Text valueOfGems;
    [SerializeField]
    private Text valueOfCoins;
    [SerializeField]
    private GameObject slotsFullPopup;
    [SerializeField]
    private GameObject busyUnlockingPopup;
    [SerializeField]
    private GameObject insufficientResourcesPopup;
    [SerializeField]
    public GameObject rewardPopup;

    public Text coinText;
    public Text GemsText;


    public GameObject rewardedCoinObject;
    public GameObject rewardedGemsObject;

    public Text rewardedCoinText;
    public Text rewardedGemsText;

    [HideInInspector] public int rewardedCoins;
    [HideInInspector] public int rewardedGems;

    [SerializeField]
    private GameObject sliverChestPopUp;
    [SerializeField]
    private GameObject goldenChestPopUp;
    [SerializeField]
    private GameObject giantChestPopUp;
    [SerializeField]
    private GameObject magicalChestPopUp;

    public void ToggleSlotsFullPopup(bool setActive)
    {
        slotsFullPopup.SetActive(setActive);
    }

    public void ToggleIsBusyUnlockingPopup(bool setActive)
    {
        busyUnlockingPopup.SetActive(setActive);
    }

    public bool ToggleUnlockChestPopup(bool setActive, ChestType currentChestType)
    {
        if (setActive == false)
        {
            ChestService.Instance.selectedController = null;
            sliverChestPopUp.SetActive(setActive);
            goldenChestPopUp.SetActive(setActive);
            giantChestPopUp.SetActive(setActive);
            magicalChestPopUp.SetActive(setActive);
        }

        if(setActive == true && currentChestType == ChestType.Silver)
        {
            sliverChestPopUp.SetActive(setActive);
            goldenChestPopUp.SetActive(false);
            giantChestPopUp.SetActive(false);
            magicalChestPopUp.SetActive(false);
        }

        else if(setActive == true && currentChestType == ChestType.Golden)
        {
            goldenChestPopUp.SetActive(setActive);
            sliverChestPopUp.SetActive(false);
            giantChestPopUp.SetActive(false);
            magicalChestPopUp.SetActive(false);
        }

        else if (setActive == true && currentChestType == ChestType.Giant)
        {
            giantChestPopUp.SetActive(setActive);
            sliverChestPopUp.SetActive(false);
            goldenChestPopUp.SetActive(false);
            magicalChestPopUp.SetActive(false);
        }

        else if (setActive == true && currentChestType == ChestType.Magical)
        {
            magicalChestPopUp.SetActive(setActive);
            sliverChestPopUp.SetActive(false);
            goldenChestPopUp.SetActive(false);
            giantChestPopUp.SetActive(false);
        }

        return setActive;
    }

    public void ToggleInsufficientResourcesPopup(bool setActive)
    {
        insufficientResourcesPopup.SetActive(setActive);
    }

    public void UpdateGemsUI(int totalGems)
    {
        if (PlayerPrefs.HasKey("") != null)
        {
            totalGems = PlayerPrefs.GetInt("", +totalGems);
            valueOfGems.text = totalGems.ToString();
        }
        
    }

    public void UpdateCoinsUI(int totalCoins)
    {
        if (PlayerPrefs.HasKey("") != null)
        {            
            totalCoins = PlayerPrefs.GetInt("", +totalCoins);
            valueOfCoins.text = "" +totalCoins.ToString();
        }
    }

    public void Close()
    {
        slotsFullPopup.gameObject.SetActive(false);
    }

    public void Okay()
    {
        busyUnlockingPopup.gameObject.SetActive(false);
    }

    public void CloseSilverPopUp()
    {
        sliverChestPopUp.SetActive(false);
    }

    public void CloseGoldenPopUp()
    {
        goldenChestPopUp.SetActive(false);
    }
    public void CloseMagicalPopUp()
    {
        magicalChestPopUp.SetActive(false);
    }
    public void CloseGiantPopUp()
    {
        giantChestPopUp.SetActive(false);
    }

}
