using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject[] towers;
    public Text _textLabel;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateScore()
    {
        Debug.Log("Enter");
        score++;
        _textLabel.text = "score: " + score;

    }
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
                }

            }

        }
    }
}
