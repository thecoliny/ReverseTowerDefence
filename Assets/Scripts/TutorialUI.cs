using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : UIPopup
{
    [SerializeField] public Text objectName;
    [SerializeField] public Text type;
    [SerializeField] public Text description;
    [SerializeField] public Text stats;
    [SerializeField] public Image image;

    private void Start()
    {
        Close();
    }
}
