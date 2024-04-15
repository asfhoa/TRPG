using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]protected string characterName;         //ĳ���� �̸�
    [SerializeField]protected Sprite sprite;                //ĳ���� �̹���
    [SerializeField]protected Status status;                //ĳ������ ����

    public float Speed => status.speed;

    public abstract bool SkillQ();

    public abstract bool SkillE();

    public abstract bool SkillR();
}
