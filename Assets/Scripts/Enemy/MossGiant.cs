using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }
    protected override void Init()
    {
        base.Init();
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
        
    }

}
