using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sceleton : Enemy
{
    protected override void Init()
    {
        base.Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (childAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        MoveBetweeenPoints();
    }
}
