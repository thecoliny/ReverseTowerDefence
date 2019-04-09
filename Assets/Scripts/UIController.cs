using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] public Button button1;
    [SerializeField] public Button button2;
    [SerializeField] private Text _scoreLabel;
    [SerializeField] private Text _currencyLabel;
    [SerializeField] private GameObject currencyManager;
    private CurrencyManagement _currencyManagement;
    private int score = 0;
    public int selectedButton;

    // Start is called before the first frame update

    void Awake()
    {
        Messenger.AddListener(GameEvent.UNIT_PASSED, UpdateScore);
        Messenger.AddListener(GameEvent.CURRENCY_UPDATE, UpdateCurrency);
    }
    void Start() {
        button1.onClick.AddListener(clickButton1);
        button2.onClick.AddListener(clickButton2);
        selectedButton = 1;
        _scoreLabel.text = "Score: " + score;
        _currencyManagement = currencyManager.GetComponent<CurrencyManagement>();
        _currencyLabel.text = "Currency: " + _currencyManagement.amount;
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
        _scoreLabel.text = "Score: " + score;
    }

    private void UpdateCurrency()
    {
        _currencyLabel.text = "Currency: " + _currencyManagement.amount;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
