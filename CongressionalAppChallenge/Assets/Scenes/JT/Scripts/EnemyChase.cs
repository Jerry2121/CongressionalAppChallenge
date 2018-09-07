using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float chaseSpeed = 2.0f;
	private bool home = true;
	private Vector3 homePos;

	private Vector2 moveDirection;

	public float maxMoveDistance = 10.0f;
	public float chaseTriggerDistance = 1.0f;

	void Start () {
		homePos = transform.position;
        

    }
	
	// Update is called once per frame
	void Update () {

		Vector3 playerPosition = GameObject.Find("TownHallTile(Clone)").transform.position;
		moveDirection = new Vector2 (0 - transform.position.x, 0 - transform.position.y);

        moveDirection.Normalize();
        home = false;
        GetComponent<Rigidbody2D>().velocity = moveDirection * chaseSpeed;
	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Base")
        {
            Destroy(this.gameObject);
        }
    }
}
