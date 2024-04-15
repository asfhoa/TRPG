using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    class Turn
    {
        public Character character;
        public float reamining;

        public void Action(Turn actor)
        {
            reamining -= actor.reamining;
        }

        public void Reset()
        {
            reamining = 10000 / character.Speed;
        }
    }

    Character[] characters;     //��� ĳ���� �迭
    List<Turn> turnQueue;       //������ ���� ť
    Character currentCharacter; //���� ���� ĳ����

    private void Start()
    {
        characters = FindObjectsOfType<Character>();
        characters.OrderByDescending(x => x.Speed).ToArray();
        turnQueue = characters.Select(x=> new Turn { character = x }).ToList(); //��� ĳ���͸� Turnť�� �߰�
        turnQueue.ForEach(x => x.Reset());                                      //���� �Ÿ��� ����

        NextTurn();
        ShowActionQueue();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NextTurn();
            ShowActionQueue();
        }
    }

    private void NextTurn()
    {
        Turn next = turnQueue[0];               //���� �տ� �ִ� ĳ���� ����
        turnQueue.RemoveAt(0);                  //ť���� ����
        turnQueue.ForEach(x => x.Action(x));    //���� Turn�� �����Ų��
        turnQueue.Add(next);                    //next�� �ٽ� ť�� �ִ´�
        next.Reset();                           //next�� turn�� �ʱ�ȭ�Ѵ�
        turnQueue.OrderBy(x => x.reamining);    //���� �Ÿ��� ���� ����
        currentCharacter = next.character;      //���� �� ĳ���� ��ȯ
    }

    public void ShowActionQueue()
    {
        Debug.Log(string.Join("->", turnQueue.Select(x => x.character.name).ToArray()));
    }
}
