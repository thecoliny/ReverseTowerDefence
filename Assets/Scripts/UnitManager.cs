using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Enter");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Enter2");
                if (hit.collider.tag == "Path")
                {
                    
                    Debug.Log("Enter3");
                    Vector3 position = new Vector3(hit.collider.gameObject.transform.position.x, 5, hit.collider.gameObject.transform.position.z);
                    GameObject _tower = Instantiate(tower) as GameObject;
                    _tower.transform.position = position;
                }

            }

        }
    }
}
