using UnityEngine;

/* Handles interaction with the Enemy */

public class Enemy : MonoBehaviour
{
    //Patroling
    public Vector3 walkPoint;
    public bool sniper;
    bool walkPointSet = false;
    public float walkPointRange = 15f;
    public float pointChangeRait = 10f;

    //Attack
    public Transform Fireball;
    public Transform Pivot;
    private bool alreadyKicked = false;
    public float timeBetweenAttacks;
    private float nextKick = 0;

    //General
    public PlayerCharacter player;
    public float seeDistance = 7f;
    public float shootDistance = 5f;
    public float attackDistance = 2f;
    public float speed;
    public float health = 10f;
    private Transform target;
    public LayerMask whatIsGround;
    private Vector3 startCoord;

    void Start()
    {
        startCoord = gameObject.transform.position;
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > seeDistance) Patroling();
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance) ChasePlayer();
        if (sniper == false)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
            {
                if (alreadyKicked == false)
                {
                    alreadyKicked = true;
                    player.Hurt(1);
                }
                AttackPlayer();
            }
            else
            {
                alreadyKicked = false;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) < shootDistance + 0.5f)
            {
                if (alreadyKicked == false)
                {
                    alreadyKicked = true;
                    player.Hurt(1);
                }
                AttackPlayer();
            }
            else
            {
                alreadyKicked = false;
            }
        }
    }
    private void Patroling()
    {
        if (!walkPointSet) SetWalkPoints();
        if (walkPointSet)
        {
            transform.LookAt(walkPoint);
            transform.Translate(new Vector3(0, 0, 0.1f * Time.deltaTime));
            if (Vector3.Distance(transform.position, walkPoint) < 1)
            {
                walkPointSet = false;
            }
        }
    }
    private void SetWalkPoints()
    {
        float randZ = Random.Range(-walkPointRange, walkPointRange);
        float randX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(startCoord.x + randX, startCoord.y, startCoord.z + randZ);
        walkPointSet = true;
    }
    private void ChasePlayer()
    {
        if (sniper == false)
        {
            transform.LookAt(target.transform);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        else
        {
            transform.LookAt(target.transform);
            if (Vector3.Distance(transform.position, target.transform.position) > shootDistance)
            {
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
        }
    }
    private void AttackPlayer()
    {
        transform.LookAt(target.transform);
        if (sniper == false)
        {
            if (nextKick < timeBetweenAttacks)
            {
                nextKick += Time.deltaTime;
            }
            if (nextKick > timeBetweenAttacks)
            {
                player.Hurt(1);
                nextKick = 0;
            }
        }
        else
        {
            if (nextKick < timeBetweenAttacks)
            {
                nextKick += Time.deltaTime;
            }
            if (nextKick > timeBetweenAttacks)
            {
                Instantiate(Fireball, Pivot.position, Pivot.rotation);
                nextKick = 0;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        player.score += 10;
        health -= damage;
        if (health < 1)
        {
            player.score += 30;
            Destroy(gameObject);
        }
    }
}