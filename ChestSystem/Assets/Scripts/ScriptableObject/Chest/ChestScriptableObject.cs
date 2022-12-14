using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ChestSO", menuName = "ScriptableObjects/Chests/ChestSO")]
public class ChestScriptableObject : ScriptableObject
{
    public string ChestName;
    public Sprite ChestSprite;
    public ChestType chestType;
    public string UnlockTime;
    public float UnlockDuration;
    public int MinCoins;
    public int MaxCoins;
    public int MinGems;
    public int MaxGems;
    public int UnlockCost;

    [Header("Explore Chest Information")]
    public int CardCount;
    public Sprite UnlockChestSprite;
}
