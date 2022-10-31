using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : GenericSingleton<ResourceHandler>
{
    public int coins;
    public int gems;

    private void Start()
    {
        coins = UIHandler.instance.CoinInitializer();
        gems = UIHandler.instance.GemsInitializer();
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
    public void DecreaseCoins(int valueToDecrease)
    {
        coins -= valueToDecrease;
        UIHandler.Instance.UpdateCoinsUI(coins);
    }
}
