using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;

    private float attackTimer = 0; //공격 시간
    private float attackCd = 0.3f; // 공격 0.3 초 동안 활성화 시키기 위한 변수


    private Animator anim; 

    void Awake() {
        anim = gameObject.GetComponent<Animator>(); // 애니메이션 컴포넌트를 잡아줌

    }

   
    void Start()
    {

    }

  
    void Update()
    {
        anim.SetBool("Attacking", attacking);
        if (Input.GetKeyDown("c") && !attacking) // c 버튼 누르고 공격상태가 아니면 attacking 활성화
        {
            attacking = true;
            attackTimer = attackCd; // 공격시간 0.3 대입

        }

        if (attacking) {
            if (attackTimer > 0) 
            {
                attackTimer -= Time.deltaTime; // 0.3 에서 0까지 줄인다.
            }
            else {
                attacking = false; // 공격시간이 0이되면 attacking 비활성화

            }
        }
      
                
    }
}
