using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestModel 
{
    public ChestModel(ChestScriptableObject ChestSO)
    {
        ChestName = ChestSO.ChestName;
        UnlockTimeString = ChestSO.UnlockTime;
        ChestSprite  = ChestSO.ChestSprite;
        UnlockDuration = ChestSO.UnlockDuration;
        CoinCost = ChestSO.UnlockCost;
        CoinsReward = Random.Range(ChestSO.MinCoins, ChestSO.MaxCoins + 1);
        GemsReward = Random.Range(ChestSO.MinGems, ChestSO.MaxGems + 1);
        CardCount = ChestSO.CardCount;
        UnlockChestSprite = ChestSO.UnlockChestSprite;
        ChestCurrentType = ChestSO.chestType;
        UnlockGemsCost = ChestSO.UnlockCost;
    }

    public float UnlockDuration { get; }
    public string ChestName { get; }
    public Sprite ChestSprite { get; }
    public int UnlockCost { get; }
    public int CoinCost { get; }
    public int CoinsReward { get; }
    public int GemCost { get; }
    public int GemsReward { get; }
    public string UnlockTimeString { get; }
    public int CardCount { get; set; }
    public Sprite UnlockChestSprite { get; }
    public ChestType ChestCurrentType { get; }
    public int UnlockGemsCost { get; set; }
}
