using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI_Template : MonoBehaviour {

    public int[] unitTargetsArray;

    public List<GameObject> unitTargetsList = new List<GameObject>();

    public float moveSpeed;
    public GameObject unitTarget;
    private Vector2 moveDirection;
    private float distanceToUnitTarget;

    void Start()
    {
        // unitTargets = new int[unitTargetsList];
    }

    void Update()
    {


        Vector3 unitTargetPosition = unitTarget.transform.position;
        moveDirection = new Vector2(unitTargetPosition.x - transform.position.x, unitTargetPosition.y - transform.position.y);
        distanceToUnitTarget = moveDirection.magnitude;
        moveDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = moveDirection * moveSpeed;
    }

    public void ResetUnitsTarget()
    {
        List<float> priorityValues = new List<float>();
        

        for (int i = 0; i < unitTargetsArray.Length; i++)
        {

        }
    }
}
