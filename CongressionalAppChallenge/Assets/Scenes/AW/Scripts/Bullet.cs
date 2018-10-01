using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int damage = 50;
    [SerializeField]
    private float speed = 70f;
    [SerializeField]
    private bool towerBullet = true;
    //[SerializeField]
    //public GameObject impactEffect;
    [SerializeField]
    private float explosionRadius = 0f;

    private bool hitTarget;
    private string targetTag;
    private Transform target;

    public void Seek(Transform _target, string _targetTag)
    {
        target = _target;
        targetTag = _targetTag;
    }

    // Update is called once per frame
    void Update()
    {
        //if the target is already dead, destroy the bullet
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame && !hitTarget)
        {
            hitTarget = true;
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.right = target.position - transform.position;
    }

    void HitTarget()
    {
        //GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, .5f);


        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
    }

    void Explode()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D col in hitColliders)
        {
            if (col.tag == targetTag)
                Damage(col.transform);
        }
        Destroy(gameObject);
    }

    void Damage(Transform _target)
    {
        if (towerBullet)
        {
            EnemyHP enemyTarget = _target.GetComponent<EnemyHP>();
            if (enemyTarget != null)
                enemyTarget.TakeDamage(damage);
        }
        else
        {
            StructureHP structureTarget = _target.GetComponent<StructureHP>();
            if (structureTarget != null)
                structureTarget.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
