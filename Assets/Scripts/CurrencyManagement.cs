using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManagement : MonoBehaviour
{
    public int amount;

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

    // Update is called once per frame
    void Update()
    {

    }
}
