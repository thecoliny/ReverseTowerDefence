using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] public Button button1;
    [SerializeField] public Button button2;
    [SerializeField] public Text _textLabel;
    private int score = 0;
    public int selectedButton;

    // Start is called before the first frame update

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_Passed, UpdateScore);
    }
    void Start() {
        button1.onClick.AddListener(clickButton1);
        button2.onClick.AddListener(clickButton2);
        selectedButton = 1;
        _textLabel.text = "score: " + score;
    }

    void clickButton1()
    {
        selectedButton = 1;
    }

    void clickButton2()
    {
        selectedButton = 2;
    }
    
    private void UpdateScore()
    {
        score++;
        _textLabel.text = "score: " + score;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
