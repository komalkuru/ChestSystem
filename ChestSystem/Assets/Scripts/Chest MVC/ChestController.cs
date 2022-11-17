using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    public ChestModel chestModel;
    public ChestView chestView { get; }
    public float unlockTimer;
    public int gemsCost;

    public ChestController(ChestModel chestModel, ChestView chestView)
    {
        this.chestModel = chestModel;
        this.chestView = chestView;
        InitializeView();
        unlockTimer = this.chestModel.UnlockDuration;
        gemsCost = this.chestModel.UnlockGemsCost;
    }

    public void InitializeView()
    {
        chestView.SetControllerReference(this);
        chestView.InitialiseViewUIForLockedChest();
    }

    public int GetGemCost()
    {
        gemsCost = chestModel.UnlockGemsCost;
        return gemsCost;
    }

    public async void StartTimer()
    {
        while (unlockTimer > 0)
        {
            chestView.TimerText.text = unlockTimer.ToString() + " s";
            await new WaitForSeconds(1f);
            unlockTimer -= 1;
        }
        chestView.EnteringUnlockedState();
        return;
    }

    public void GetCardCount(string totalCardsInChest, int mouseClickCount)
    {
        int cardTotalCount = int.Parse(totalCardsInChest);
        
        if (mouseClickCount != cardTotalCount)
        {
            cardTotalCount -= 1;
            mouseClickCount += 1;

            chestView.ShowCounter(cardTotalCount);
        }
    }
}
