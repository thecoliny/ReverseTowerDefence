using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject currencyManager;
    [SerializeField] private int initialBonus;
    [SerializeField] private int perUnitBonus;
    private bool _reached;
    private CurrencyManagement _currencyManagement;
    // Start is called before the first frame update
    void Start()
    {
        _currencyManagement = currencyManager.GetComponent<CurrencyManagement>();
        _reached = false;
    }

    public void reactToCheckpointReach()
    {
        if (!_reached)
        {
            _currencyManagement.addCurrency(initialBonus);
            _reached = true;
        }
        _currencyManagement.addCurrency(perUnitBonus);
    }
}
