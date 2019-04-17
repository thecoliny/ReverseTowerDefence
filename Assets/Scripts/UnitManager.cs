using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject[] units;
    public UIController UIController;
    [SerializeField] GameObject currencyManager;
    private CurrencyManagement _currencyManagement;

    private void Start()
    {
        _currencyManagement = currencyManager.GetComponent<CurrencyManagement>();
    }

    // Update is called once per frame
    void Update()
    {

        int selectedButton = UIController.getButton();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Path")
                {
                    if (_currencyManagement.spendCurrency(units[selectedButton - 1].GetComponent<Unit>().Cost))
                    {
                        Vector3 position = new Vector3(hit.collider.gameObject.transform.position.x, 5, hit.collider.gameObject.transform.position.z);
                        GameObject _unit = Instantiate(units[selectedButton - 1]) as GameObject;
                        _unit.transform.position = position;
                    }
                }

            }

        }/*
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Path")
                {

                    Vector3 position = new Vector3(hit.collider.gameObject.transform.position.x, 5, hit.collider.gameObject.transform.position.z);
                    GameObject _tower = Instantiate(towers[1]) as GameObject;
                    _tower.transform.position = position;
                    _tower.transform.SetParent(units.transform);
                }

            }

        }*/
    }
}
