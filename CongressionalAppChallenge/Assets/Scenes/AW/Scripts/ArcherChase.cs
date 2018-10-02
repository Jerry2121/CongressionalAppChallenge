using UnityEngine;
using System.Collections;

public class ArcherChase : MonoBehaviour {

    [SerializeField]
	private float movementSpeed = 2.0f;
    [SerializeField]
    private float range = 5f;
    [SerializeField]
    private float fireRate = 1f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private string enemyTag = "Structure";
    [SerializeField]
    private int collisionDamage = 1;


	public GameObject target;

    public bool cannotAttack;

    private Animator animator;

    private Vector2 moveDirection;

    private float fireCountdown = 0f;
    void Start () {
        cannotAttack = false;
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        //If there is no target, target the town hall
        if (target == null)
        {
            target = GameObject.Find("TownHallTile(Clone)");
        }
        float targetDistance = Vector2.Distance(transform.position, target.transform.position);
        if (targetDistance <= range)
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
            return;
        }
        else if (targetDistance > range)
        {
            animator.SetBool("Attack", false);
            moveDirection = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
            moveDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = moveDirection * movementSpeed;
        }
	}

    void Shoot()
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("ARCHERCHASE -- SHOOT: You haven't given tower " + gameObject + " a bullet prefab!");
            return;
        }
        animator.SetBool("Attack", true);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        //Spawn on top of Archer sprite
        GameObject bulletGO = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
        //spawn below
        //GameObject bulletGO = Instantiate(bulletPrefab, transform.position, transform.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target.transform, enemyTag);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 11)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 12)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 13)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "OutsideBarrier")
        {
            cannotAttack = true;
        }
        else
        {
            cannotAttack = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
