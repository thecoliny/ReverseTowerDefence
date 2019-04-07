using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private GameObject units;
    public GameObject[] towers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Path")
                {
                    
                    Vector3 position = new Vector3(hit.collider.gameObject.transform.position.x, 5, hit.collider.gameObject.transform.position.z);
                    GameObject _tower = Instantiate(towers[0]) as GameObject;
                    _tower.transform.position = position;
                    _tower.transform.SetParent(units.transform);
                }

            }

        }
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

        }
    }
}
