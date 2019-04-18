using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject units;
    [SerializeField] private GameObject projectilePrefab;
    private List<GameObject> _projectiles;
    [SerializeField] private float range;
    [SerializeField] private float towerRotationSpeed;
    [SerializeField] private float projectileRotationSpeed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float cooldownTime;
    GameObject target = null;
    private bool inRange = false;
    private bool cdReady = true; 


    // Start is called before the first frame update
    void Start()
    {
        _projectiles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //Cleanup from potential hits:
        _projectiles.RemoveAll(x => x==null);


        if (target == null)
        {
            foreach (GameObject projectile in _projectiles)
            {
                Destroy(projectile);
            }

        }
        if(target == null || !inRange)
        {
            target = GameObject.FindGameObjectWithTag("unit");
        }
        if (target != null)
        {

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
                    GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;
                    newProjectile.transform.position = transform.TransformPoint(Vector3.forward * 0.0f);
                    newProjectile.transform.Translate(0.0f, -0.1f, 0.0f);
                    newProjectile.transform.rotation = transform.rotation;
                    _projectiles.Add(newProjectile);
                    StartCoroutine(Wait());
                }
            }
            else
            {
                inRange = false;
            }

            // update any existing projectiles
            foreach (GameObject projectile in _projectiles)
            {
                Vector3 projectileDirection = (target.transform.position - projectile.transform.position).normalized;
                Quaternion projectileLookRotation = Quaternion.LookRotation(projectileDirection);

                projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, projectileLookRotation, Time.deltaTime * projectileRotationSpeed);
                projectile.transform.position = projectile.transform.TransformPoint(Vector3.forward * Time.deltaTime * projectileSpeed);
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(cooldownTime);
        cdReady = true;
 
    }
}
