using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    wndering,
    Attacking
}
public class NPC : MonoBehaviour
{
    [Header("Stats")] 
    public int health;
    public float walkSpeed;
    public float runSpeed;
    public ItemData[] dropOnDeath;
    
    [Header("AI")]
    private NavMeshAgent agent;
    public float detectDistance;
    private AIState aiState;
    
    [Header("Wanderoing")]
    public float minWanderDistance;
    public float maxWanderDistance;
    public float minWanderWaitTime;
    public float maxWanderWaitTime;

    [Header("Cambat")] 
    public int damage;
    public float attackRate;
    private float LastAttackTime;
    public float AttackDistance;

    private float playerDistance;

    public float fieldOfView = 120f; // npc 시아각
    
    private Animator animator;
    private SkinnedMeshRenderer skinRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
