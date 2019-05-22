using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MommyUnit : Unit
{
    [SerializeField] private Unit baby;

    public override void ReactToHit(float damage)
    {
        Health = Health - damage;
        if (Health <= 0.0f)
        {
            playParticleEffect(deathParticle);
            float posX = this.transform.position.x;
            float posY = this.transform.position.y;
            float posZ = this.transform.position.z;

            Vector3 _position1 = this.transform.position;
            //Vector3 _position2 = new Vector3(posX + 0.5f, posY, posZ + 0.5f);
            //Vector3 _position3 = new Vector3(posX - 0.5f, posY, posZ - 0.5f);
            Vector3 _position2 = this.transform.position + this.transform.forward * 0.5f;
            Vector3 _position3 = this.transform.position + this.transform.forward * - 0.5f;
            Destroy(this.gameObject);
            Unit _baby1 = Instantiate(baby, _position1, this.transform.rotation) as Unit;
            _baby1.end = end;
            Unit _baby2 = Instantiate(baby, _position2, this.transform.rotation) as Unit;
            _baby2.end = end;
            Unit _baby3 = Instantiate(baby, _position3, this.transform.rotation) as Unit;
            _baby3.end = end;
            // _baby1.transform.position = _position1;
            //_baby1.transform.rotation = this.transform.rotation;
            //_baby2.transform.position = _position4;
            // _baby2.transform.rotation = this.transform.rotation;
            // _baby3.transform.position = _position5;
            //_baby3.transform.rotation = this.transform.rotation;
        }
        else
        {
            playParticleEffect(hitParticle);
        }
    }
}
