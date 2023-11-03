using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float hp;
    private Animator ani;


    private void Start()
    {
        ani = GetComponent<Animator>();
        hp = 100.0f;
        //Debug.Log("hi my hp is:" +  hp);
    }

    public void onDamage(float damage) {
        hp -= damage;
        ani.SetTrigger("onDamage");
        Debug.Log("now hp:" + hp);
        if (hp <= 0) {
            ani.SetBool("Death", true);
        }
    }
}
