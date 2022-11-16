using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : GenericSingleton<ChestService>
{
    [HideInInspector]
    public ChestController selectedController;

    public ChestController GetChest(ChestScriptableObject randomChestSO, ChestView chestView)
    {
        ChestModel chestModel = new ChestModel(randomChestSO);
        ChestController chestController = new ChestController(chestModel, chestView);
        return chestController;
    }

    public void OnClickStartTimer()
    {
        selectedController.chestView.EnteringUnlockingState();
        UIHandler.Instance.ToggleUnlockChestPopup(false, ChestType.None);
        
    }

    public void OnClickOpenInstantlyWithGems()
    {
        if (ResourceHandler.Instance.gems < selectedController.GetGemCost())
        {
            UIHandler.Instance.ToggleUnlockChestPopup(false, ChestType.None);
            UIHandler.Instance.ToggleInsufficientResourcesPopup(true);
        }
        else
        {
            ResourceHandler.Instance.DecreaseGems(selectedController.GetGemCost());
            selectedController.chestView.OpenInstantly();
            UIHandler.Instance.ToggleUnlockChestPopup(false,ChestType.None);
        }
    }


    public bool ToggleRewardsPopup(bool setActive)
    {
        if (!setActive)
        {
            selectedController = null;
        }
        UIHandler.Instance.rewardPopup.SetActive(setActive);
        return setActive;
    }
}
