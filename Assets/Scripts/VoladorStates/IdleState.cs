using UnityEngine;
using System.Collections;
using System;

public class IdleState : IEnemyState {

    private Enemy enemy;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("Estoy en mi estado idle");
        Idler();
        if (enemy.Target != null)
        {
            enemy.ChangeState(new AttackState());
        }

    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }

    private void Idler()
    {
        enemy.MyAnimation.SetBool("attack", false);
        enemy.MyAnimation.SetBool("muere", false);
    }
}
