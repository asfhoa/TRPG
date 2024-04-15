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

    Character[] characters;     //모든 캐릭터 배열
    List<Turn> turnQueue;       //순서에 따른 큐
    Character currentCharacter; //현재 턴인 캐릭터

    private void Start()
    {
        characters = FindObjectsOfType<Character>();
        characters.OrderByDescending(x => x.Speed).ToArray();
        turnQueue = characters.Select(x=> new Turn { character = x }).ToList(); //모든 캐락터를 Turn큐에 추가
        turnQueue.ForEach(x => x.Reset());                                      //남은 거리를 리셋

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
        Turn next = turnQueue[0];               //가장 앞에 있는 캐릭터 빼기
        turnQueue.RemoveAt(0);                  //큐에서 제거
        turnQueue.ForEach(x => x.Action(x));    //남은 Turn을 진행시킨다
        turnQueue.Add(next);                    //next를 다시 큐에 넣는다
        next.Reset();                           //next의 turn을 초기화한다
        turnQueue.OrderBy(x => x.reamining);    //남은 거리에 따라 정렬
        currentCharacter = next.character;      //다음 턴 캐릭터 반환
    }

    public void ShowActionQueue()
    {
        Debug.Log(string.Join("->", turnQueue.Select(x => x.character.name).ToArray()));
    }
}
