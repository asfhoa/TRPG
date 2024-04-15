using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    public float hp;
    public float speed;
    public float damage;
    public float defanse;

    public Status(float hp, float speed, float damage, float defance)
    {
        this.hp = hp;
        this.speed = speed;
        this.damage = damage;
        this.defanse = defance;
    }
}
