using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] public Button button1;
    [SerializeField] public Button button2;
    [SerializeField] public Button button3;
    [SerializeField] public GameObject indicator;
    [SerializeField] private Text _scoreLabel;
    [SerializeField] private Text _currencyLabel;
    [SerializeField] private GameObject currencyManager;
    [SerializeField] private int passingScore;
    [SerializeField] private UIPopup winning;
    [SerializeField] private UIPopup canvas;
    private CurrencyManagement _currencyManagement;
    private int score = 0;
    private int selectedButton;

    // Start is called before the first frame update

    void Awake()
    {
        Messenger.AddListener(GameEvent.UNIT_PASSED, UpdateScore);
        Messenger.AddListener(GameEvent.CURRENCY_UPDATE, UpdateCurrency);
    }
    void Start() {
        winning.Close();
        if(button1 != null)
           button1.onClick.AddListener(clickButton1);
        if(button2 != null)
            button2.onClick.AddListener(clickButton2);
        if (button3 != null)
            button3.onClick.AddListener(clickButton3);
        selectedButton = 1;
        _scoreLabel.text = "Score: " + score + "/" + passingScore;
        _currencyManagement = currencyManager.GetComponent<CurrencyManagement>();
        _currencyLabel.text = "Currency: " + _currencyManagement.amount;
    }

    void clickButton1()
    {
        selectedButton = 1;
        indicator.transform.position = new Vector3(615, 600, 0);
    }

    void clickButton2()
    {
        selectedButton = 2;
        indicator.transform.position = new Vector3(615, 568, 0);
    }

    void clickButton3()
    {
        selectedButton = 3;
        indicator.transform.position = new Vector3(615, 535, 0);
    }

    public int getButton()
    {
        return selectedButton;
    }

    private void UpdateScore()
    {
        score++;
        if (!_scoreLabel)
        {
            Debug.Log("SCORE LABEL NOT FOUND"); // TODO: score label not being found, but somehow still updates label??
            return;
        }
            _scoreLabel.text = "Score: " + score + "/" + passingScore; /* TODO: This Text is getting destroyed! */
        if (score >= passingScore)
        {
            canvas.Close();
            winning.Open();
        }
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
