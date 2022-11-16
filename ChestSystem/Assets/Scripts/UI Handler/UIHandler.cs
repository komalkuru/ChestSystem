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
    //[SerializeField]
    //private GameObject unlockChestPopup;
    [SerializeField]
    private GameObject insufficientResourcesPopup;
    [SerializeField]
    public GameObject rewardPopup;

    public Text coinText;
    public Text GemsText;

    public int totalCoins;
    public int totalGems;    

    public Text rewardReceivedText;

    public Image rewardedCoinImage;
    public Image rewardedGemsImage;
    public Text randomCoinGenerated;
    public Text randomGemsGenerated;

    [HideInInspector] public int rewardedCoins;
    [HideInInspector] public int rewardedGems;

    public GameObject sliverChestPopUp;
    public GameObject goldenChestPopUp;
    public GameObject giantChestPopUp;
    public GameObject magicalChestPopUp;

    public int CoinInitializer()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoinsText", +totalCoins);
        return totalCoins;
    }

    public int GemsInitializer()
    {
        totalGems = PlayerPrefs.GetInt("TotalGemsText", + totalGems);
        return totalGems;
    }

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
        //unlockChestPopup.SetActive(setActive);
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

    public void UpdateGemsUI(int gems)
    {
        valueOfGems.text = gems.ToString();
    }

    public void UpdateCoinsUI(int coins)
    {
        valueOfCoins.text = coins.ToString();
        Debug.Log(valueOfCoins.text);
        //valueOfCoins.text = PlayerPrefs.SetString("TotalCoinsText" + valueOfCoins);
    }

    public void Close()
    {
        slotsFullPopup.gameObject.SetActive(false);
    }

    public void Okay()
    {
        busyUnlockingPopup.gameObject.SetActive(false);
    }
}
