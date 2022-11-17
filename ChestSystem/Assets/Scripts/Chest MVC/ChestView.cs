using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChestView : MonoBehaviour { 
    [HideInInspector]
    public ChestController chestController;
    [HideInInspector]
    public Slots slotReference;

    [Header("Chest Information")]
    [SerializeField] private Image EmptySlotSprite;
    [SerializeField] private Image BackgroundImage;
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

    [Header("Explore Chest Information")]
    public Text CardCount;
    [SerializeField] private Image unlockChestImage;

    private ChestState currentState;

    private ChestType chestType;
    private int clickCount;

    private bool isToggleRewardsPopup;


    public void SetControllerReference(ChestController chestController)
    {
        this.chestController = chestController;
    }

    private void Start()
    {
        InitializeEmptyChestView();
        isToggleRewardsPopup = false;
    }

    private void Update()
    {
        if (isToggleRewardsPopup == true)
        {
            GetMouseDown();
        }
    }
    public void InitializeEmptyChestView()
    {
        EmptySlotSprite.gameObject.SetActive(true);
        BackgroundImage.gameObject.SetActive(false);
        LockText.gameObject.SetActive(false);
        UnlockText.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);
        TimeText.gameObject.SetActive(false);
        chestSprite.gameObject.SetActive(false);
        OpenNowText.gameObject.SetActive(false);
        ArenaText.gameObject.SetActive(false);
        GemsCountText.gameObject.SetActive(false);
        GemsImage.gameObject.SetActive(false);
        OpenChestText.gameObject.SetActive(false);
        ChestButton.gameObject.SetActive(false);

        currentState = ChestState.None;
    }

    public void InitialiseViewUIForLockedChest()
    {
        EmptySlotSprite.gameObject.SetActive(false);
        BackgroundImage.gameObject.SetActive(true);
        LockText.gameObject.SetActive(true);
        UnlockText.gameObject.SetActive(false);
        TimerText.gameObject.SetActive(false);

        TimeText.gameObject.SetActive(true);
        TimeText.text = chestController.chestModel.UnlockTimeString;

        chestSprite.gameObject.SetActive(true);
        chestSlotSprite.sprite = chestController.chestModel.ChestSprite;

        OpenNowText.gameObject.SetActive(false);
        ArenaText.gameObject.SetActive(true);
        GemsCountText.gameObject.SetActive(false);
        GemsImage.gameObject.SetActive(false);
        OpenChestText.gameObject.SetActive(false);
        ChestButton.gameObject.SetActive(true);

        ChestButton.enabled = true;
        currentState = ChestState.Locked;
        chestType = chestController.chestModel.ChestCurrentType;

       // Debug.Log(chestType);
    }

    public void InitialiseViewUIForUnlockingChest()
    {
        EmptySlotSprite.gameObject.SetActive(false);
        BackgroundImage.gameObject.SetActive(true);
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
        ChestButton.gameObject.SetActive(true);

        ChestButton.enabled = true;
        currentState = ChestState.Unlocking;
    }

    public void InitialiseViewUIForUnlockedChest()
    {
        EmptySlotSprite.gameObject.SetActive(false);
        BackgroundImage.gameObject.SetActive(true);
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
        ChestButton.gameObject.SetActive(true);

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
                UIHandler.Instance.ToggleUnlockChestPopup(true, chestType);               

            }
        }
        else if (currentState == ChestState.Unlocking)
        {
           
        }
        else if (currentState == ChestState.Unlocked)
        {
            ChestService.Instance.selectedController = chestController;
            OpenChest();
            CardCount.text = chestController.chestModel.CardCount.ToString();
            unlockChestImage.sprite = chestController.chestModel.UnlockChestSprite;
            UIHandler.Instance.ToggleUnlockChestPopup(false, chestType);

            ChestService.Instance.ToggleRewardsPopup(true);
            isToggleRewardsPopup = ChestService.Instance.ToggleRewardsPopup(true);
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

        CardCount.text = chestController.chestModel.CardCount.ToString();
        unlockChestImage.sprite = chestController.chestModel.UnlockChestSprite;
        UIHandler.Instance.ToggleUnlockChestPopup(false, chestType);

        ChestService.Instance.ToggleRewardsPopup(true);
        isToggleRewardsPopup = ChestService.Instance.ToggleRewardsPopup(true);
        slotReference.chestController = null;
    }

    public void EnteringUnlockedState()
    {
        SlotsController.Instance.isUnlocking = false;
        InitialiseViewUIForUnlockedChest();
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

        UIHandler.instance.rewardedCoins = chestController.chestModel.CoinsReward;
        UIHandler.instance.rewardedGems = chestController.chestModel.GemsReward;
        Debug.Log("ReceiveChestRewards");
        ResourceHandler.Instance.IncreaseCoins(UIHandler.instance.rewardedCoins);
        ResourceHandler.Instance.IncreaseGems(UIHandler.instance.rewardedGems);
    }  

    public void ShowCounter(int cardCounter, int mouseClickCounter)
    {
        string convertedCardCounter = cardCounter.ToString();
        CardCount.text = convertedCardCounter;

        if (CardCount.text == 0.ToString() )
        {
            UIHandler.instance.rewardedGemsObject.gameObject.SetActive(false);
            UIHandler.instance.rewardedGemsText.gameObject.SetActive(false);
            isToggleRewardsPopup = ChestService.Instance.ToggleRewardsPopup(false);
        }
    }
    
    public void GetMouseDown()
    {
        clickCount = 0;
       
        if (clickCount == 0)
        {
            Debug.Log("clockcount 1: " + clickCount);
            UIHandler.instance.rewardedCoinObject.gameObject.SetActive(true);
            UIHandler.instance.rewardedCoinText.gameObject.SetActive(true);
            UIHandler.instance.rewardedCoinText.text = "+ " + UIHandler.instance.rewardedCoins.ToString();
        } 
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;
            chestController.GetCardCount(CardCount.text, clickCount);
            UIHandler.instance.rewardedCoinObject.gameObject.SetActive(false);
            UIHandler.instance.rewardedCoinText.gameObject.SetActive(false);

            UIHandler.instance.rewardedGemsObject.gameObject.SetActive(true);
            UIHandler.instance.rewardedGemsText.gameObject.SetActive(true);
            UIHandler.instance.rewardedGemsText.text = "+ " + UIHandler.instance.rewardedGems.ToString();
        }
    }
}
