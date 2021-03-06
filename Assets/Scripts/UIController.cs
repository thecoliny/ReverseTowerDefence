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
    [SerializeField] private float selectedButtonScale = 1.1f;
    [SerializeField] private int defaultButton = 1;
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

        selectedButton = defaultButton;

        if (button1Active)
        {
            button1.onClick.AddListener(clickButton1);
            UnitButton unitButton1 = button1.gameObject.GetComponent<UnitButton>();
            unitButton1.tutorialManager = tutorialManager;
            unitButton1.unit = unitManager.units[0].gameObject;
            if (selectedButton == 1) button1.transform.localScale = new Vector3(selectedButtonScale, selectedButtonScale, selectedButtonScale);
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
            if (selectedButton == 2) button3.transform.localScale = new Vector3(selectedButtonScale, selectedButtonScale, selectedButtonScale);
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
            if (selectedButton == 2) button3.transform.localScale = new Vector3(selectedButtonScale, selectedButtonScale, selectedButtonScale);
        }
        else
        {
            button3.gameObject.SetActive(false);
        }

        _scoreLabel.text = score + "/" + passingScore;
    }

    void clickButton1()
    {
        selectedButton = 1;
        button1.transform.localScale = new Vector3(selectedButtonScale, selectedButtonScale, selectedButtonScale);
        button2.transform.localScale = Vector3.one;
        button3.transform.localScale = Vector3.one;
    }

    void clickButton2()
    {
        selectedButton = 2;
        button1.transform.localScale = Vector3.one;
        button2.transform.localScale = new Vector3(selectedButtonScale, selectedButtonScale, selectedButtonScale);
        button3.transform.localScale = Vector3.one;
    }

    void clickButton3()
    {
        selectedButton = 3;
        button1.transform.localScale = Vector3.one;
        button2.transform.localScale = Vector3.one;
        button3.transform.localScale = new Vector3(selectedButtonScale, selectedButtonScale, selectedButtonScale);
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
            _scoreLabel.text = score + "/" + passingScore; /* TODO: This Text is getting destroyed! */
        if (score >= passingScore)
        {
            canvas.Close();
            winning.Open();

        }
    }

    private void UpdateCurrency()
    {
        _currencyLabel.text = _currencyManagement.amount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
