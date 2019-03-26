﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    protected int gems;
    protected Transform pointA, pointB;

    public virtual void Attack()
    {
        Debug.Log("I am " + this.gameObject.name);
    }

    public abstract void Update();
}
