using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsController : GenericSingleton<SlotsController>
{
    [SerializeField]
    private Slots[] Slots;
    [SerializeField]
    private ChestConfigs chestConfiguration;
    public bool isUnlocking;

    private void Start()
    {
        isUnlocking = false;
    }

    //If slot is empty, spawn the chest in that slot.
    public void SpawnRandomChestIfEmpty()
    {
        int slot = GetEmptySlot();
        if (slot == -1)
        {
            UIHandler.Instance.ToggleSlotsFullPopup(true);
        }
        else
        {
            Slots[slot].SpawnRandomChest(chestConfiguration.ChestConfigurationMap[Random.Range(0, 4)].ChestSO);
        }
    }

    private int GetEmptySlot()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Slots[i].isEmpty)
            {
                return i;
            }
        }
        return -1;
    }

}
