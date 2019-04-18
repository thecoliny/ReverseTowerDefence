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
            Vector3 _position1 = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Vector3 _position2 = new Vector3(this.transform.position.x + 0.4f , this.transform.position.y, this.transform.position.z + 0.4f);
            Vector3 _position3 = new Vector3(this.transform.position.x - 0.4f, this.transform.position.y, this.transform.position.z - 0.4f);
            Destroy(this.gameObject);
            GameObject _baby1 = Instantiate(baby) as GameObject;
            GameObject _baby2 = Instantiate(baby) as GameObject;
            GameObject _baby3 = Instantiate(baby) as GameObject;
            _baby1.transform.position = _position1;
            _baby2.transform.position = _position2;
            _baby3.transform.position = _position3;
        }
    }
}
