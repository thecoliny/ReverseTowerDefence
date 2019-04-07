using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] public Button button1;
    [SerializeField] public Button button2;
    public int selectedButton;

    // Start is called before the first frame update
    void Start() {
        button1.onClick.AddListener(clickButton1);
        button2.onClick.AddListener(clickButton2);
        selectedButton = 1;
    }

    void clickButton1()
    {
        selectedButton = 1;
    }

    void clickButton2()
    {
        selectedButton = 2;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
