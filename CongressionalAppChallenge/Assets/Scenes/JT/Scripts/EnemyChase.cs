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

		Vector3 playerPosition = GameObject.Find("TownHallTile(Clone)").transform.position;
		moveDirection = new Vector2 (0 - transform.position.x, 0 - transform.position.y);

        moveDirection.Normalize();
        home = false;
        GetComponent<Rigidbody2D>().velocity = moveDirection * chaseSpeed;
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Production Structure
        if (collision.gameObject.layer == 10)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //Village Structure
        if (collision.gameObject.layer == 11)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //Tower Structure
        if (collision.gameObject.layer == 12)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
        //Defense Structure
        if (collision.gameObject.layer == 13)
        {
            GameObject.Find("TownHallTile(Clone)").GetComponent<TownHallScript>().Enemiesleft--;
            collision.gameObject.GetComponent<StructureHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Base")
        {
            if (gameObject.layer == 15)
            {
                animator.SetBool("Attack", true);
            }
            chaseSpeed = 0;
        }
        else if (gameObject.layer == 15)
        {
            animator.SetBool("Attack", false);
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
