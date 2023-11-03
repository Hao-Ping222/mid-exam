using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform groundpoint;
    public Transform attackpoint;
    public float attackrange = 3f;
    private float InputX;

    private Rigidbody2D rig;
    private Animator ani;

    private bool isFlip = false;
    private bool isGrounded = false;
    private bool canAttack = true;

    
    public LayerMask groundMask,enemymask;
    
    

 
    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    public void Update()
    {
        rig.velocity = new Vector2(moveSpeed * InputX, rig.velocity.y);

        //判斷 使用者是否有輸入移動控制 有的話 讓角色進行跑步動畫的播放
        ani.SetBool("isRun", Mathf.Abs(rig.velocity.x)>0);
        ani.SetBool("isGrounded", isGrounded);
        ani.SetFloat("yvelocity",rig.velocity.y);
       

        if (!isFlip)
        {
            if(rig.velocity.x < 0)
            {
                isFlip = true;
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }
        else
        {
            if(rig.velocity.x > 0)
            {
                isFlip = false;
                transform.Rotate(0.0f, 180.0f, 0.0f);
            }
        }
        Debug.Log(Physics2D.OverlapCircle(groundpoint.position, .2f, groundMask));
        isGrounded=Physics2D.OverlapCircle(groundpoint.position, .2f,groundMask);
        canAttack = isGrounded;
    }

    public void Move(InputAction.CallbackContext context)
    {
        InputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rig.velocity = new Vector2(rig.velocity.x, 5);
        }
        
    }


    public void Attack(InputAction.CallbackContext context)
    {
        //檢查玩家是否可以攻擊
        if (canAttack)
        {
            ani.SetBool("attack", true);
        }
    }

    private void CheckAttackHit()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemymask);
        foreach (Collider2D collider in detectedObjects)
        {
            Debug.Log(collider.gameObject.name);
            collider.gameObject.SendMessage("onDamage", 10.0f);
        }
    }

    public void EndAttack()
    {
        ani.SetBool("attack", false);
    }



    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(groundpoint.position, .2f);
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
    
        
    


}
