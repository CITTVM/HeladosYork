using UnityEngine;
using System.Collections;
using System;

public class AttackState : IEnemyState
{
    private Enemy enemy;


    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("Estoy atacandote");
        Attack();
        
    }

    public void Exit()
    {
        if (enemy.Target == null)
        {
            enemy.ChangeState(new IdleState());
        }

    }

    public void OnTriggerEnter(Collider2D other)
    {

    }

    public void Attack()
    {
        enemy.MyAnimation.SetBool("attack", true);
        enemy.MyAnimation.SetBool("muere", false);
        enemy.Ataque();
    }
}
