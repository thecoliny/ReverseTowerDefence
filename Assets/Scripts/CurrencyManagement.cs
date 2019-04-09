using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManagement : MonoBehaviour
{
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        amount = 0;
    }

    public void addCurrency(int amount)
    {
        this.amount += amount;
    }

    public bool canAfford(int price)
    {
        return price < amount;
    }

    public bool spendCurrency(int amount)
    {
        if (canAfford(amount))
        {
            this.amount -= amount;
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
