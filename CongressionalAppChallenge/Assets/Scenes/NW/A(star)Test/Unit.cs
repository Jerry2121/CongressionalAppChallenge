using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public Transform target;
    public Transform townBase;
    public float speed = 20;
    Vector3[] path;
    int targetIndex;

    private void Start()
    {
        townBase = target;
        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }
    private void Update()
    {
        if(target == null)
        {
            target = townBase;
            PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
        }
    }
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
            for(int i = 0; i < structures.Length; i++)
            {
                if((structures[i].transform.position - transform.position).magnitude < dist)
                {
                    target = structures[i].transform;
                    dist = (target.transform.position - transform.position).magnitude;
                }

            }
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

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
            yield return null;
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