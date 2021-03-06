﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject currencyManager;
    [SerializeField] private int initialBonus;
    [SerializeField] private TextMesh label;
    [SerializeField] private ParticleSystem checkpointParticle;
    private CurrencyManagement _currencyManagement;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        _currencyManagement = currencyManager.GetComponent<CurrencyManagement>();
        count = 0;
        label.text = initialBonus.ToString();
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
            ParticleSystem newParticle = Instantiate(checkpointParticle);
            newParticle.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        }
        label.text = initialBonus.ToString();
    }
}
