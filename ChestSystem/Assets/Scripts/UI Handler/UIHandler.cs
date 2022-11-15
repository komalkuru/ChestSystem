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
    private GameObject unlockChestPopup;
    [SerializeField]
    private GameObject insufficientResourcesPopup;
    [SerializeField]
    public GameObject rewardPopup;

    public Text coinText;
    public Text GemsText;

    public int totalCoins;
    public int totalGems;    

    public Text rewardReceivedText;

    public GameObject rewardedCoinImage;
    public GameObject rewardedGemsImage;
    public Text randomCoinGenerated;
    public Text randomGemsGenerated;


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

    public bool ToggleUnlockChestPopup(bool setActive)
    {
        unlockChestPopup.SetActive(setActive);
        if (setActive == false)
        {
            ChestService.Instance.selectedController = null;
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
    }
}
