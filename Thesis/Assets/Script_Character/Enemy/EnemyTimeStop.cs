using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTimeStop : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private Animator anim;
    private TimeManager timemanager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        timemanager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timemanager.TimeIsStopped)
        {
            agent.velocity = Vector3.zero; // stop moving
            anim.speed = 0f;  //stop the animation
            return;
        }
        anim.speed = 1;

    }
}