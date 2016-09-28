using UnityEngine;
using System.Collections;


/* Chest Animator Component의 Parameter값을 잡아주기 위해
 * 외부 스크립트인 PlayerCtr2.cs, PlayerAttack.cs로부터
 * 변수값을 받아오기 위한 스크립트임.                  */



public class PlayerLeg1 : MonoBehaviour
{
    private Animator anim;  // Animator Component를 잡기위한 변수 anim 선언

    Rigidbody2D rb2D;


    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Get();
       
    }

    void Get()
    {
        var Out = GameObject.FindObjectOfType<PlayerCtr2>();    // 스크립트 PlayerCtr2.cs의 변수 isGrounded, move를 받아오기 위한 var 변수 선언

        anim.SetFloat("Speed", Mathf.Abs(Out.move));            // Chest의 Animator Component의 Parameter인 Speed의 값을 잡아준다.
        anim.SetBool("Ground", Out.isGrounded);                 // Chest의 Animator Component의 Parameter인 Ground의 값을 잡아준다.

    }

}
