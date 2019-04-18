using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManagement : MonoBehaviour
{
    [System.NonSerialized] public int amount;
    private LevelManager _levelManager;

    public void Start()
    {
        _levelManager = this.GetComponentInParent<LevelManager>();
        this.amount = _levelManager.startingCurrency;
        Messenger.Broadcast(GameEvent.CURRENCY_UPDATE);
    }

    public void addCurrency(int amount)
    {
        this.amount += amount;
        Messenger.Broadcast(GameEvent.CURRENCY_UPDATE);
    }

    public bool canAfford(int price)
    {
        return price <= amount;
    }

    public bool spendCurrency(int amount)
    {
        if (canAfford(amount))
        {
            this.amount -= amount;
            Messenger.Broadcast(GameEvent.CURRENCY_UPDATE);
            return true;
        }
        else
        {
            return false;
        }
    }
}
