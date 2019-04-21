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
            float posX = this.transform.position.x;
            float posY = this.transform.position.y;
            float posZ = this.transform.position.z;
            Vector3 _position1 = this.transform.position;
            Vector3 _position2 = this.transform.position + this.transform.forward;
            Vector3 _position3 = this.transform.position + this.transform.forward * -1;
            Destroy(this.gameObject);
            GameObject _baby1 = Instantiate(baby) as GameObject;
            GameObject _baby2 = Instantiate(baby) as GameObject;
            GameObject _baby3 = Instantiate(baby) as GameObject;
            _baby1.transform.position = _position1;
            _baby1.transform.rotation = this.transform.rotation;
            _baby2.transform.position = _position2;
            _baby2.transform.rotation = this.transform.rotation;
            _baby3.transform.position = _position3;
            _baby3.transform.rotation = this.transform.rotation;
        }
    }
}
