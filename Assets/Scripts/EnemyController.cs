using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    float speed = 10f;
    //Rigidbody rb;
    NavMeshAgent agent;
    Animator anim;

    [SerializeField]
    List<Transform> waypoint = new List<Transform>();
    [SerializeField]
    float waitTimeAtpoint = 2f;
    [SerializeField]
    bool patrolInLoop = true;

    int currentWaypointIndex = 0;
    bool isWaiting = false;
    bool movingForward = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        if (waypoint == null || waypoint.Count == 0) return;

        GoToCurrentWaypoint();
    }

    void Update()
    {
        if (waypoint.Count == 0 || isWaiting) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetTrigger("Stop");
            agent.speed = 0;
            StartCoroutine(WaitAtWaypoint());
        }
    }

    void GoToCurrentWaypoint()
    {
        if (waypoint.Count == 0) return;
        agent.SetDestination(waypoint[currentWaypointIndex].position);
    }

    void SelectNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoint.Count;
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTimeAtpoint);
        SelectNextWaypoint();
        anim.SetTrigger("Walk");
        agent.speed = speed;
        GoToCurrentWaypoint();
        isWaiting = false;
    }

        void FixedUpdate()
    {
        //Vector3 forwardMove = transform.forward * speed;
        //rb.linearVelocity = new Vector3(forwardMove.x, rb.linearVelocity.y, forwardMove.z);
    }
}
