﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private bool button1Active;
    private bool button2Active;
    private bool button3Active;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private GameObject indicator;
    [SerializeField] private Text _scoreLabel;
    [SerializeField] private Text _currencyLabel;
    [SerializeField] private GameObject currencyManager;
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private UnitManager unitManager;
    private int passingScore;
    [SerializeField] private UIPopup winning;
    [SerializeField] private UIPopup canvas;
    private LevelManager levelManager;
    private CurrencyManagement _currencyManagement;
    private int score = 0;
    private int selectedButton;
    private int indicatorXCoord = 805;

    // Start is called before the first frame update

    void Awake()
    {
        _currencyManagement = currencyManager.GetComponent<CurrencyManagement>();
        Messenger.AddListener(GameEvent.UNIT_PASSED, UpdateScore);
        Messenger.AddListener(GameEvent.CURRENCY_UPDATE, UpdateCurrency);
    }
    void Start() {
        levelManager = transform.GetComponentInParent<LevelManager>();

        button1Active = levelManager.colinActive;
        button2Active = levelManager.fastColinActive;
        button3Active = levelManager.mommyActive;
        passingScore = levelManager.passingScore;

        canvas.Open();
        winning.Close();

        indicator.transform.position = new Vector3(indicatorXCoord, button1.transform.position.y - 5, 0);

        if (button1Active)
        {
            button1.onClick.AddListener(clickButton1);
            UnitButton unitButton1 = button1.gameObject.GetComponent<UnitButton>();
            unitButton1.tutorialManager = tutorialManager;
            unitButton1.unit = unitManager.units[0].gameObject;
            
        }
        else
        {
            button1.gameObject.SetActive(false);
        }
        if (button2Active)
        {
            button2.onClick.AddListener(clickButton2);
            UnitButton unitButton2 = button2.gameObject.GetComponent<UnitButton>();
            unitButton2.tutorialManager = tutorialManager;
            unitButton2.unit = unitManager.units[1].gameObject;
        }
        else
        {
            button2.gameObject.SetActive(false);
        }
        if (button3Active)
        {
            button3.onClick.AddListener(clickButton3);
            UnitButton unitButton3 = button3.gameObject.GetComponent<UnitButton>();
            unitButton3.tutorialManager = tutorialManager;
            unitButton3.unit = unitManager.units[2].gameObject;
        }
        else
        {
            button3.gameObject.SetActive(false);
        }

        selectedButton = 1;
        _scoreLabel.text = "Score: " + score + "/" + passingScore;
    }

    void clickButton1()
    {
        selectedButton = 1;
        indicator.transform.position = new Vector3(indicatorXCoord, button1.transform.position.y - 5, 0);
    }

    void clickButton2()
    {
        selectedButton = 2;
        indicator.transform.position = new Vector3(indicatorXCoord, button2.transform.position.y - 5, 0);
    }

    void clickButton3()
    {
        selectedButton = 3;
        indicator.transform.position = new Vector3(indicatorXCoord, button3.transform.position.y - 5, 0);
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
