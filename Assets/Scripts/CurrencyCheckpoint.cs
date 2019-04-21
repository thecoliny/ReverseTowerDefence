using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject currencyManager;
    [SerializeField] private int initialBonus;
    private CurrencyManagement _currencyManagement;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        _currencyManagement = currencyManager.GetComponent<CurrencyManagement>();
        count = 0;
    }

    public void reactToCheckpointReach()
    {
        if(initialBonus > 0)
        {
            _currencyManagement.addCurrency(initialBonus);
            if (initialBonus != 1)
            {
                initialBonus--;
            }
            else
            {
                count++;
                if (count >= 5)
                {
                    initialBonus--;
                }
            }
        }
    }
}
