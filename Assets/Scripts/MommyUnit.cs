using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MommyUnit : Unit
{
    [SerializeField] private GameObject baby;

    public override void ReactToHit(float damage)
    {
         Health = Health - damage;
        if (Health <= 0.0f)
        {
            Vector3 _position = this.transform.position;
            Destroy(this.gameObject);
            GameObject _baby1 = Instantiate(baby) as GameObject;
            GameObject _baby2 = Instantiate(baby) as GameObject;
            GameObject _baby3 = Instantiate(baby) as GameObject;
            _baby1.transform.position = _position;
            _baby2.transform.position = _position;
            _baby3.transform.position = _position;
        }
    }
}
