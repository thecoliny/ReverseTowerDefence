using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject units;
    [SerializeField] private GameObject projectilePrefab;
    private GameObject _projectile;
    [SerializeField] private float range;
    [SerializeField] private float towerRotationSpeed;
    [SerializeField] private float projectileRotationSpeed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float attackSpeed;
    GameObject target = null;
    private bool inRange = false;
    private bool cdReady = true; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(_projectile);
        }
        if(target == null || !inRange)
        {
            target = GameObject.FindGameObjectWithTag("unit");
        }

            Vector3 towerLoc = this.transform.position;
            Vector3 targetLoc = target.transform.position;
            Vector3 towerToTarget = targetLoc - towerLoc;
            // Rotate tower towards target
            Vector3 towerDirection = towerToTarget.normalized;
            Quaternion towerLookRotation = Quaternion.LookRotation(towerDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, towerLookRotation, Time.deltaTime * towerRotationSpeed);


            // If tower in range...
            if (range * range > towerToTarget.sqrMagnitude)
            {
                inRange = true;
                // spawn a projectile if doesn't exist already
                if (cdReady)
                {
                cdReady = false;
                _projectile = Instantiate(projectilePrefab) as GameObject;
                _projectile.transform.position = transform.TransformPoint(Vector3.forward * 0.0f);
                _projectile.transform.rotation = transform.rotation;
                StartCoroutine(Wait());
                    
                }
            }
            else
            {
                inRange = false;
            }

            // update any existing projectiles
            if (_projectile != null)
                {

                    Vector3 projectileDirection = (target.transform.position - _projectile.transform.position).normalized;

                    Quaternion projectileLookRotation = Quaternion.LookRotation(projectileDirection);

                    _projectile.transform.rotation = Quaternion.Slerp(_projectile.transform.rotation, projectileLookRotation, Time.deltaTime * projectileRotationSpeed);
                    _projectile.transform.position = _projectile.transform.TransformPoint(Vector3.forward * Time.deltaTime * projectileSpeed);
                }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f - attackSpeed);
        cdReady = true;
 
    }
}
