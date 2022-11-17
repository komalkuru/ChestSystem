using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : GenericSingleton<ResourceHandler>
{
    public int coins;
    public int gems;


    private void Start()
    {
        UIHandler.Instance.UpdateGemsUI(gems);
        UIHandler.Instance.UpdateCoinsUI(coins);
    }

    public void IncreaseGems(int valueToIncrease)
    {
        gems += valueToIncrease;
        UIHandler.Instance.UpdateGemsUI(gems);
    }
    public void DecreaseGems(int valueToDecrease)
    {
        gems -= valueToDecrease;
        UIHandler.Instance.UpdateGemsUI(gems);
    }
    public void IncreaseCoins(int valueToIncrease)
    {
        coins += valueToIncrease;
        UIHandler.Instance.UpdateCoinsUI(coins);
    }

    public void ExploreCards(int _totalCards)
    {
        int totalCards = _totalCards;
    }
}
