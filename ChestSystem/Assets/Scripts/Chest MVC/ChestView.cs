using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestView : MonoBehaviour
{
    [HideInInspector]
    public ChestController chestController;
    [HideInInspector]
    public Slots slotReference;

    [SerializeField] private Sprite EmptySlotSprite;
    public Text LockText;
    public Text UnlockText;
    public Text TimerText;
    public Text TimeText;
    [SerializeField] private Image chestSprite;
    public Text OpenNowText;
    public Text ArenaText;
    public Text GemsCountText;
    [SerializeField] private Image GemsImage;
    public Text OpenChestText;
    [SerializeField] private Button ChestButton;

    [SerializeField] private Image chestSlotSprite;

    private ChestState currentState;

    public void SetControllerReference(ChestController chestController)
    {
        this.chestController = chestController;
    }   

    private void Start()
    {
        InitializeEmptyChestView();
    }

    public void InitializeEmptyChestView()
    {
        chestSlotSprite.sprite = EmptySlotSprite;
        LockText.gameObject.SetActive(true);
        UnlockText.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);
        TimeText.gameObject.SetActive(true);
        chestSprite.gameObject.SetActive(true);
        OpenNowText.gameObject.SetActive(false);
        ArenaText.gameObject.SetActive(true);
        GemsCountText.gameObject.SetActive(false);
        GemsImage.gameObject.SetActive(false);
        OpenChestText.gameObject.SetActive(false);

        currentState = ChestState.None;
    }

    public void InitialiseViewUIForLockedChest()
    {
        LockText.gameObject.SetActive(true);
        UnlockText.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);
        TimeText.gameObject.SetActive(true);
        chestSprite.gameObject.SetActive(true);
        chestSlotSprite.sprite = chestController.chestModel.ChestSprite;

        OpenNowText.gameObject.SetActive(false);
        ArenaText.gameObject.SetActive(true);
        GemsCountText.gameObject.SetActive(false);
        GemsImage.gameObject.SetActive(false);
        OpenChestText.gameObject.SetActive(false);

        ChestButton.enabled = true;
        currentState = ChestState.Locked;
    }

    public void InitialiseViewUIForUnlockingChest()
    {
        LockText.gameObject.SetActive(false);
        UnlockText.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(true);
        TimeText.gameObject.SetActive(false);
        chestSprite.gameObject.SetActive(true);
        chestSlotSprite.sprite = chestController.chestModel.ChestSprite;

        OpenNowText.gameObject.SetActive(true);
        ArenaText.gameObject.SetActive(false);
        GemsCountText.gameObject.SetActive(true);
        GemsCountText.text = chestController.GetGemCost().ToString();
        GemsImage.gameObject.SetActive(true);
        OpenChestText.gameObject.SetActive(false);

        ChestButton.enabled = true;
        currentState = ChestState.Unlocking;
    }

    public void InitialiseViewUIForUnlockedChest()
    {
        LockText.gameObject.SetActive(false);
        UnlockText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(false);
        TimeText.gameObject.SetActive(false);
        chestSprite.gameObject.SetActive(true);
        chestSlotSprite.sprite = chestController.chestModel.ChestSprite;

        OpenNowText.gameObject.SetActive(false);
        ArenaText.gameObject.SetActive(false);
        GemsCountText.gameObject.SetActive(false);
        GemsImage.gameObject.SetActive(false);
        OpenChestText.gameObject.SetActive(true);

        ChestButton.enabled = true;
        currentState = ChestState.Unlocked;
    }


    public void OnClickChestButton()
    {
        if (currentState == ChestState.Locked)
        {
            if (SlotsController.Instance.isUnlocking)
            {
                UIHandler.Instance.ToggleIsBusyUnlockingPopup(true);
            }
            else
            {
                ChestService.Instance.selectedController = chestController;
                UIHandler.Instance.ToggleUnlockChestPopup(true);
            }



            /*
            
            0. Check if any other Chest is still unlocking usingSlotsController.isUnlocking and if yes then show the "Wait for your Chest to unlock" Popup.
            1. Open a dialog box with option to either Start the timer through coins or Instantly open through gems.
            2. The POPUP will open. When any button of the two is clicked in the popup, a method in view is called which checks if enough resources are there or not.
            3. If not then a popup using UIHandler shows saying Insufficient Resources.
            4. If enough resources are present then we will call a method EnteringUnlockingState() or OpenInstantly() from the ChestView.

             */
        }
        else if (currentState == ChestState.Unlocking)
        {
            /*
            
            1. Show a popup using UIHandler to UNLOCK Chest through gems(cost calculated by controller) instantly.
            2. If option chosen then call method EnteringUnlockedState() from the ChestView.

             */
        }
        else if (currentState == ChestState.Unlocked)
        {
            ChestService.Instance.selectedController = chestController;
            OpenChest();
            ChestService.Instance.ToggleRewardsPopup(true);

            /*
            
            1. Call a method OpenChest() from ChestView.

             */
        }
    }


    public void EnteringUnlockingState()
    {
        SlotsController.Instance.isUnlocking = true;
        InitialiseViewUIForUnlockingChest();
        chestController.StartTimer();

    }

    public void OpenInstantly()
    {
        InitializeEmptyChestView();
        ReceiveChestRewards();
        ChestService.Instance.selectedController = chestController;
        slotReference.isEmpty = true;
        ChestService.Instance.ToggleRewardsPopup(true);
        slotReference.chestController = null;
    }

    public void EnteringUnlockedState()
    {
        SlotsController.Instance.isUnlocking = false;
        InitialiseViewUIForUnlockedChest();
        TimerText.text = "OPEN!";
    }

    public void OpenChest()
    {
        InitializeEmptyChestView();
        ReceiveChestRewards();
        slotReference.isEmpty = true;
        slotReference.chestController = null;
    }

    public void ReceiveChestRewards()
    {
        ResourceHandler.Instance.IncreaseCoins(chestController.chestModel.CoinsReward);
        ResourceHandler.Instance.IncreaseGems(chestController.chestModel.GemsReward);
    }
}
