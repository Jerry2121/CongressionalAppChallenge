using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
    public GameObject townBase;
    public float chaseSpeed = 2.0f;
    public int damage = 1;
	private bool home = true;
    public bool cannotAttack;
	private Vector3 homePos;
    private Animator animator;
    public float timer;

    private Vector2 moveDirection;

    public Vector3[] path;
    int targetIndex;

    public float maxMoveDistance = 10.0f;
	public float chaseTriggerDistance = 1.0f;

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

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, chaseSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void Start () {
        target = GameObject.Find("TownHallTile(Clone)");
        PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
        homePos = transform.position;
        townBase = target;
        cannotAttack = false;
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            Debug.Log("TESTINGTESTING");
            chaseSpeed = 2.0f;
            animator.SetBool("Attack", false);
            target = townBase;
            path = new Vector3[0];
            PathRequestManager.RequestPath(transform.position, target.transform.position, OnPathFound);
        }

        
        timer += Time.deltaTime;
        /*
        Vector3 playerPosition = GameObject.Find("TownHallTile(Clone)").transform.position;
		moveDirection = new Vector2 (0 - transform.position.x, 0 - transform.position.y);

        moveDirection.Normalize();
        home = false;
        GetComponent<Rigidbody2D>().velocity = moveDirection * chaseSpeed;
        */

    }
   /* public void OnCollisionEnter2D(Collision2D collision)
    {
        //Production Structure
        if (collision.gameObject.layer == 10)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            Debug.Log("EnemyChase: Enemiesleft--");
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //Village Structure
        if (collision.gameObject.layer == 11)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            Debug.Log("EnemyChase: Enemiesleft--");
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //Tower Structure
        if (collision.gameObject.layer == 12)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            Debug.Log("EnemyChase: Enemiesleft--");
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //Defense Structure
        if (collision.gameObject.layer == 13)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            Debug.Log("EnemyChase: Enemiesleft--");
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }*/
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Base" && collision.gameObject == target)
        {
            chaseSpeed = 0;
            //Enemies 1 (Templar)
            /*if (collision.GetComponent<Collider2D>().gameObject.layer == 8)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    GameObject.Find("GameManager").GetComponent<GameManagerScript>().ModifyTownHallHP(-damage);
                    timer = 0;
                }
            }
            if (collision.gameObject.layer == 14)
            {
                //Enemies 2 (DarkSwordsman)
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    GameObject.Find("GameManager").GetComponent<GameManagerScript>().ModifyTownHallHP(-damage);
                    timer = 0;
                }
            }
            //Enemies 2 (DarkSwordsman)
            if (collision.gameObject.layer == 15)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    GameObject.Find("GameManager").GetComponent<GameManagerScript>().ModifyTownHallHP(-damage);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (collision.gameObject.layer == 16)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    GameObject.Find("GameManager").GetComponent<GameManagerScript>().ModifyTownHallHP(-damage);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (collision.gameObject.layer == 17)
            {*/
            if (timer >= 1)
            {
                animator.SetBool("Attack", true);
                GameObject.Find("GameManager").GetComponent<GameManagerScript>().ModifyTownHallHP(-damage);
                timer = 0;
            }
            //}
        }

        if (collision.gameObject.layer == 10 && collision.gameObject == target)
        {
            chaseSpeed = 0;
            //Enemies 1 (Templar)
            /*if (gameObject.GetComponent<Collider2D>().gameObject.layer == 8)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(1);
                    timer = 0;
                }
            }
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 14)
            {
                //Enemies 2 (DarkSwordsman)
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(2);
                    timer = 0;
                }
            }
            //Enemies 2 (DarkSwordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 15)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(3);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 16)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(4);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 17)
            {*/
            if (timer >= 1)
            {
                animator.SetBool("Attack", true);
                collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
                timer = 0;
            }
            //}
        }

        if (collision.gameObject.layer == 11 && collision.gameObject == target)
        {
            chaseSpeed = 0;
            //Enemies 1 (Templar)
            /*if (gameObject.GetComponent<Collider2D>().gameObject.layer == 8)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(1);
                    timer = 0;
                }
            }
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 14)
            {
                //Enemies 2 (DarkSwordsman)
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(2);
                    timer = 0;
                }
            }
            //Enemies 2 (DarkSwordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 15)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(3);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 16)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(4);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 17)
            {*/
            if (timer >= 1)
            {
                animator.SetBool("Attack", true);
                collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
                timer = 0;
            }
            //}
        }
        if (collision.gameObject.layer == 12 && collision.gameObject == target)
        {
            chaseSpeed = 0;
            //Enemies 1 (Templar)
            /*if (gameObject.GetComponent<Collider2D>().gameObject.layer == 8)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(1);
                    timer = 0;
                }
            }
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 14)
            {
                //Enemies 2 (DarkSwordsman)
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(2);
                    timer = 0;
                }
            }
            //Enemies 2 (DarkSwordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 15)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(3);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 16)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(4);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 17)
            {*/
            if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
                    timer = 0;
                }
            //}
        }
        if (collision.gameObject.layer == 13 && collision.gameObject == target)
        {
            chaseSpeed = 0;
            //Enemies 1 (Templar)
            /*if (gameObject.GetComponent<Collider2D>().gameObject.layer == 8)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(1);
                    timer = 0;
                }
            }
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 14)
            {
                //Enemies 2 (DarkSwordsman)
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(2);
                    timer = 0;
                }
            }
            //Enemies 2 (DarkSwordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 15)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(3);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 16)
            {
                if (timer >= 1)
                {
                    animator.SetBool("Attack", true);
                    collision.gameObject.GetComponent<StructureHP>().TakeDamage(4);
                    timer = 0;
                }
            }
            //Enemies 3 (Swordsman)
            if (gameObject.GetComponent<Collider2D>().gameObject.layer == 17)
            {*/
            if (timer >= 1)
            {
                animator.SetBool("Attack", true);
                collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
                timer = 0;
            }
            //}
        }


        if (collision.gameObject.tag == "OutsideBarrier")
        {
            cannotAttack = true;
        }
        else
        {
            cannotAttack = false;
        }
    }

    public void OnDrawGizmos()
    {
        if (path != null)
        {
            for (int i = targetIndex; i < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], Vector3.one);

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i - 1], path[i]);
                }
            }
        }
    }
}
