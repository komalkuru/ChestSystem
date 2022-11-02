using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestUnlocker : MonoBehaviour
{
    [HideInInspector]
    public ChestController chestController;
    [HideInInspector]
    [Header("Explore Chest Information")]
    public Text CardCount;
    [SerializeField] private Image unlockChestImage;

    private void Start()
    {

        CardCount.text = chestController.chestModel.CardCount.ToString();
        unlockChestImage.sprite = chestController.chestModel.UnlockChestSprite;
    }
}
