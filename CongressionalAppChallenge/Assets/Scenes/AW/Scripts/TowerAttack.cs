using UnityEngine;

public class TowerAttack : MonoBehaviour
{

    [Header("General")]
    public float range = 5f;

    [Header("Use Bullets (default)")]
    public float fireRate = 1f;
    public string enemyTag = "Enemy";

    [Header("Use Constant Damage")]
    public bool useConstantDamage = false;
    public int damageOverTime = 30;
    public float slowAmount = .5f;
    public LineRenderer lineRenderer;

    [Header("Unity Setup")]
    public GameObject bulletPrefab;

    private float startFireRate;
    private Transform target;
    private EnemyHP targetEnemyHP;
    private float fireCountdown = 0f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        startFireRate = fireRate;
    }

    void UpdateTarget()
    {
        //if you already have a target, see if its in range and attackable
        if (target != null)
        {
            float currentTargetDistance = Vector2.Distance(transform.position, target.transform.position);
            //if the target is in range and can be attacked, keep attacking it
            if(currentTargetDistance <= range && target.gameObject.GetComponent<EnemyChase>().cannotAttack == false)
            {
                return;
            }
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemyHP = nearestEnemy.GetComponent<EnemyHP>();
        }
        else
            target = null;

    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            if (useConstantDamage)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }

            }
            return;
        }

        //see if the enemy is in map bounds
        if(target.gameObject.GetComponent<EnemyChase>().cannotAttack)
        {
            return;
        }

        LockOnTarget();

        if (useConstantDamage)
            Laser();
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
            fireRate = startFireRate;
        }
    }

    void LockOnTarget()
    {
        Vector2 dir = target.position - transform.position;

    }

    void Laser()
    {
        targetEnemyHP.TakeDamage(damageOverTime * Time.deltaTime);
        //targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }


        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void Shoot()
    {
        if(bulletPrefab == null)
        {
            Debug.LogError("TOWERATTACK -- SHOOT: You haven't given tower " + gameObject + " a bullet prefab!");
            return;
        }



        //Spawn on top of tower sprite
        GameObject bulletGO = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
        //spawn below
        //GameObject bulletGO = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target, enemyTag);
    }

    public void EnhancedFireRate(float _increase)
    {
        fireRate = startFireRate * _increase;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
