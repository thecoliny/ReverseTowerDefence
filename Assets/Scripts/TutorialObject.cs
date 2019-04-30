using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObject : MonoBehaviour
{
    [SerializeField] public string objectName;
    [SerializeField] public string description;
    [SerializeField] public Sprite sprite;

    private List<string> stats;
    private string objectType;

    public virtual List<string> GetStats()
    {
        return stats;
    }
    public string getObjectType()
    {
        return objectType;
    }

    public void setObjectType(string objectType)
    {
        this.objectType = objectType;
    }

    public void setStats(List<string> stats)
    {
        this.stats = stats;
    }

    public virtual void onShow() { 
    
    }

    public virtual void onClose()
    {

    }


}
