using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;

    [SerializeField]
    protected Transform pointA, pointB;
    protected Animator childAnimator;
    protected Vector3 currentTarget;
    protected bool onPatrol;

    protected virtual void Init()
    {
        childAnimator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        Debug.Log("Parent Start() worked. I am " + gameObject.name);
        Init();
    }

    public virtual void Attack()
    {
        Debug.Log("I am " + this.gameObject.name);
    }

    public virtual void Update()
    {
          
    }

    protected virtual void MoveBetweeenPoints()
    {
        if (transform.position == pointA.position)
        {
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (transform.position == pointB.position)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        float movementSpeed = speed * Time.deltaTime;

        if (transform.position.x == pointA.position.x)
        {
            childAnimator.SetTrigger("Idle");

            currentTarget = pointB.position;
            onPatrol = false;
        }
        else if (transform.position.x == pointB.position.x)
        {
            childAnimator.SetTrigger("Idle");

            currentTarget = pointA.position;
            onPatrol = false;
        }
        else if (transform.position.x != pointA.position.x
            && transform.position.x != pointB.position.x)
        {
            float distanceToApoint = Vector2.Distance(transform.position, pointA.position);
            float distanceToBpoint = Vector2.Distance(transform.position, pointB.position);

            if (distanceToApoint > distanceToBpoint && !onPatrol)
            {
                currentTarget = pointA.position;
                gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                onPatrol = true;
            }
            else if (distanceToBpoint > distanceToApoint && !onPatrol)
            {
                currentTarget = pointB.position;
                gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                onPatrol = true;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, movementSpeed);
    }
}
