using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject units;
    [SerializeField] public GameObject projectilePrefab;
    private List<GameObject> _projectiles;
    [SerializeField] public float range;
    [SerializeField] public float towerRotationSpeed;
    [SerializeField] private float projectileRotationSpeed;
    [SerializeField] public float projectileSpeed;
    [SerializeField] public float cooldownTime;
    [SerializeField] private Sprite rangeIndicatorSprite;
    private GameObject _rangeIndicator;
    Unit target = null;
    private bool cdReady = true; 


    // Start is called before the first frame update
    void Start()
    {
        _projectiles = new List<GameObject>();

        _rangeIndicator = new GameObject();
        _rangeIndicator.SetActive(false);
        _rangeIndicator.transform.position = transform.position;
        _rangeIndicator.transform.localEulerAngles = new Vector3(90, 0, 0);
        SpriteRenderer rangeIndicatorSpriteRenderer = _rangeIndicator.AddComponent<SpriteRenderer>();
        rangeIndicatorSpriteRenderer.sprite = rangeIndicatorSprite;
        rangeIndicatorSpriteRenderer.drawMode = SpriteDrawMode.Simple;
        rangeIndicatorSpriteRenderer.transform.localScale = new Vector3(range * 2, range * 2, 1);
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
        if(target == null || !InRange(target))
        {
            GameObject[] temp_targets = GameObject.FindGameObjectsWithTag("unit");
            foreach(GameObject temp_target in temp_targets)
            {
                Unit temp_target_unit = temp_target.GetComponent<Unit>();
                if (InRange(temp_target_unit))
                {
                    target = temp_target_unit;
                }
            }
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
            if (InRange(target) && cdReady)
            {
                // spawn a projectile if doesn't exist already
                    cdReady = false;
                    GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;
                    newProjectile.transform.position = transform.TransformPoint(Vector3.forward * 0.0f);
                    newProjectile.transform.Translate(0.0f, -0.5f, 0.0f);
                    newProjectile.transform.rotation = transform.rotation;
                    newProjectile.GetComponent<ProjectileStats>().target = target;
                    _projectiles.Add(newProjectile);
                    StartCoroutine(Wait());
            }

            // update any existing projectiles
            foreach (GameObject projectile in _projectiles)
            {

                projectile.GetComponent<ProjectileStats>().target = target;
                Vector3 projectileDirection = (target.transform.position - projectile.transform.position).normalized;
                Quaternion projectileLookRotation = Quaternion.LookRotation(projectileDirection);

                projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, projectileLookRotation, Time.deltaTime * projectileRotationSpeed);
                projectile.transform.position = projectile.transform.TransformPoint(Vector3.forward * Time.deltaTime * projectileSpeed);
            }
        }
    }

    private bool InRange(Unit target)
    {
        Vector3 towerLoc = this.transform.position;
        Vector3 targetLoc = target.transform.position;
        Vector3 towerToTarget = targetLoc - towerLoc;
        return range * range > towerToTarget.sqrMagnitude;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(cooldownTime);
        cdReady = true;
 
    }

    public void showRangeIndicator() {
        _rangeIndicator.SetActive(true);
    }

    public void hideRangeIndicator() {
        _rangeIndicator.SetActive(false);
    }

}
