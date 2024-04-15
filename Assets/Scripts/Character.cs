using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]protected string characterName;         //캐릭터 이름
    [SerializeField]protected Sprite sprite;                //캐릭터 이미지
    [SerializeField]protected Status status;                //캐릭터의 스탯

    public float Speed => status.speed;

    public abstract bool SkillQ();

    public abstract bool SkillE();

    public abstract bool SkillR();
}
