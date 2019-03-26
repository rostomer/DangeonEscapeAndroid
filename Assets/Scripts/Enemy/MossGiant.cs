using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{

    private Animator childAnimator;
    private Vector3 currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        childAnimator = GetComponentInChildren<Animator>();

        pointA = GameObject.Find("PointA").transform;
        pointB = GameObject.Find("PointB").transform;

        Attack();
    }

    // Update is called once per frame

    public override void Attack()
    {
        base.Attack();
        Debug.Log("Moss Giant Attack");
    }

    public override void Update()
    {
        if (childAnimator.GetCurrentAnimatorStateInfo(0).IsName("Moss Giant Idle"))
            return;

        MoveBetweeenPoints();


        //Output the name of the starting clip
        
    }

    private void MoveBetweeenPoints()
    {
        float movementSpeed = speed * Time.deltaTime;

        if (transform.position.x == pointA.position.x)
        {
            childAnimator.SetTrigger("Idle");
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            currentTarget = pointB.position;
        }
        else if (transform.position.x == pointB.position.x)
        {
            childAnimator.SetTrigger("Idle");
            gameObject.transform.localScale = new Vector3(-1f,1f,1f);
            currentTarget = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, movementSpeed);
    }
}
