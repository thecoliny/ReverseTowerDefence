﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Unit[] units;
    [SerializeField] private UIController _UIController;
    [SerializeField] GameObject currencyManager;
    [SerializeField] TutorialManager tutorialManager;
    private CurrencyManagement _currencyManagement;

    private void Start()
    {
        _currencyManagement = currencyManager.GetComponent<CurrencyManagement>();
    }

    // Update is called once per frame
    void Update()
    {

        int selectedButton = _UIController.getButton();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Path")
                {
                    SpawnArea spawnArea = hit.collider.gameObject.GetComponent<SpawnArea>();
                    Vector3 direction = Vector3.right;
                    switch (spawnArea.spawnFacingDirection)
                    {
                        case "right":
                            direction = Vector3.right;
                            break;
                        case "left":
                            direction = Vector3.left;
                            break;
                        case "up":
                            direction = Vector3.up;
                            break;
                        case "down": //TODO not facing down!
                            direction = Vector3.down;
                            break;
                    }
                    if (_currencyManagement.spendCurrency(units[selectedButton - 1].GetComponent<Unit>().Cost))
                    {
                        Unit _unit = Instantiate(units[selectedButton - 1], new Vector3(hit.collider.gameObject.transform.position.x, 2, hit.collider.gameObject.transform.position.z), Quaternion.LookRotation(direction)) as Unit;
                        _unit.end = spawnArea.end;
                    }
                }
            }

        }
    }
}
