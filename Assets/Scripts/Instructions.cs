using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [SerializeField] private string instructionString;
    private GameObject _instructions;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _instructionsCanvas = new GameObject("Instructions");
        _instructionsCanvas.transform.SetParent(this.transform);
        _instructionsCanvas.AddComponent<Canvas>();
        _instructions = new GameObject("Instructions");
        _instructions.transform.SetParent(_instructionsCanvas.transform);
        Text _instructionsText = _instructions.AddComponent<Text>();
        _instructionsText.text = instructionString;
        _instructions.transform.localPosition = new Vector3(0, 1, 0);
    }
}
