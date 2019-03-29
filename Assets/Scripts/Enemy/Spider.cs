using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    void Start()
    {

        Init();

       // childAnimator = animator;
    }

    protected override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        if(childAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        MoveBetweeenPoints();
    }
}
