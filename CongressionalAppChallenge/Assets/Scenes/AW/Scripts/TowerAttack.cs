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
    //private Enemy targetEnemy;
    private float fireCountdown = 0f;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        startFireRate = fireRate;
    }

    void UpdateTarget()
    {
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
            //targetEnemy = nearestEnemy.GetComponent<Enemy>();
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
        //targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
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
