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
    private float timer;


    Vector3[] path;
    int targetIndex;

    public GameObject target;
    public GameObject townBase;

    public bool cannotAttack;

    private Animator animator;

    private Vector2 moveDirection;

    private float fireCountdown = 0f;


    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }

        else if (!pathSuccessful)
        {
            GameObject[] structures = GameObject.FindGameObjectsWithTag("Structure");
            float dist = 1000;
            for (int i = 0; i < structures.Length; i++)
            {
                if ((structures[i].transform.position - transform.position).magnitude < dist)
                {
                    target = structures[i];
                    dist = (target.transform.position - transform.position).magnitude;
                }

            }
            PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];

        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, movementSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void Start () {
        target = GameObject.Find("TownHallTile(Clone)");
        PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
        cannotAttack = false;
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        //If there is no target, target the town hall
        if (target == null)
        {
            target = townBase;
            PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
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
        timer += Time.deltaTime;
        if (bulletPrefab == null)
        {
            Debug.LogError("ARCHERCHASE -- SHOOT: You haven't given tower " + gameObject + " a bullet prefab!");
            return;
        }
        if (timer >= 1)
        {
            animator.SetBool("Attack", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            //Spawn on top of Archer sprite
            GameObject bulletGO = Instantiate(bulletPrefab, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
            //spawn below
            //GameObject bulletGO = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
                bullet.Seek(target.transform, enemyTag);
            timer = 0;
        }
    }

   /* public void OnCollisionEnter2D(Collision2D collision)
    {
        //Production Structure
        if (collision.gameObject.layer == 10)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            Debug.Log("ArcherChase: Enemiesleft--");
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
        //Village Structure
        else if (collision.gameObject.layer == 11)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            Debug.Log("ArcherChase: Enemiesleft--");
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
        //Attack Structure
        else if (collision.gameObject.layer == 12)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            Debug.Log("ArcherChase: Enemiesleft--");
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
        //Defense Structure
        else if (collision.gameObject.layer == 13)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            Debug.Log("ArcherChase: Enemiesleft--");
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(collisionDamage);
            Destroy(gameObject);
        }
    }*/
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
