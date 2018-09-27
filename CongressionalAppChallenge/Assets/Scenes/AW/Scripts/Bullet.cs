using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 50;
    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;

    private bool hitTarget;
    private string enemyTag = "Enemies";
    private Transform target;

    public void Seek(Transform _target, string _enemyTag)
    {
        target = _target;
        enemyTag = _enemyTag;
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
            if (col.tag == enemyTag)
                Damage(col.transform);
        }
        Destroy(gameObject);
    }

    void Damage(Transform _enemy)
    {
        EnemyHP enemy = _enemy.GetComponent<EnemyHP>();
        if (enemy != null)
            enemy.TakeDamage(damage);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
