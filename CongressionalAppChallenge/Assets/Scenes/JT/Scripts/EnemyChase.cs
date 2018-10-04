using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float chaseSpeed = 2.0f;
    public int damage = 1;
	private bool home = true;
    public bool cannotAttack;
	private Vector3 homePos;
    private Animator animator;
    public float timer;

    private Vector2 moveDirection;

	public float maxMoveDistance = 10.0f;
	public float chaseTriggerDistance = 1.0f;

	void Start () {
		homePos = transform.position;
        cannotAttack = false;
        animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Vector3 playerPosition = GameObject.Find("TownHallTile(Clone)").transform.position;
		moveDirection = new Vector2 (0 - transform.position.x, 0 - transform.position.y);

        moveDirection.Normalize();
        home = false;
        GetComponent<Rigidbody2D>().velocity = moveDirection * chaseSpeed;
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
        chaseSpeed = 0;
        if (collision.gameObject.tag == "Base")
        {
            //Enemies 1 (Templar)
            if (collision.GetComponent<Collider2D>().gameObject.layer == 8)
            {
                if (timer >= 2)
                {
                    animator.SetBool("Attack", true);
                    GameObject.Find("GameManager").GetComponent<GameManagerScript>().ModifyTownHallHP(-damage);
                    timer = 0;
                }
            }
            else
            {
                animator.SetBool("Attack", false);
                chaseSpeed = 2.0f;
            }
        }
        if (collision.gameObject.layer == 13)
        {
            //Enemies 2 (DarkSwordsman)
            if (timer >= 1)
            {
                animator.SetBool("Attack", true);
                collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
                timer = 0;
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            chaseSpeed = 2.0f;
        }
        //Enemies 2 (DarkSwordsman)
        if (collision.gameObject.layer == 14 && timer >= 1)
        {
            Debug.Log("Foo");
            animator.SetBool("Attack", true);
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            timer = 0;
        }
        else
        {
            animator.SetBool("Attack", false);
            chaseSpeed = 2.0f;
            }
        //Enemies 3 (Swordsman)
        if (collision.gameObject.layer == 15 && timer >= 1)
        {
            Debug.Log("Foo");
            animator.SetBool("Attack", true);
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            timer = 0;
        }
        else
        {
            chaseSpeed = 2.0f;
        }
        if(collision.gameObject.tag == "OutsideBarrier")
        {
            cannotAttack = true;
        }
        else
        {
            cannotAttack = false;
        }
    }
}
