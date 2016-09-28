using UnityEngine;
using System.Collections;

public class PlayerCtr2 : MonoBehaviour {

    [HideInInspector]
    public bool isFacingRight = true; // 플레이어가 보는 방향 (오른쪽 : true)
    [HideInInspector]
    public bool isJumping = false; // 점프상태인지
    [HideInInspector]
    public bool isGrounded = false; // 땅에 닿아있는지
    [HideInInspector]
    public float move;              /* 본래 void Update()함수 부분에서 선언됬던 float형 지역변수였으나
                                       PlayerChest와 PlayerLeg에서 값을 받아올 수 있도록 클래스 내 Public 전역변수로 선언. 
                                       스크립트 44행에서 사용                                                            */
    public float Speed = 7.0f;
    public float jumpForce = 800.0f;

    public Transform groundCheck;
    public LayerMask groundLayers;

    private float groundCheckRadius = 0.2f;
    private Animator anim;

    public GameObject bulletPoint;
    public GameObject playerBulletRight;
    public GameObject playerBulletLeft;


    Rigidbody2D rb2D;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); // 물리 컴포넌트 잡아줌
        anim = GetComponent<Animator>(); // 애니메이터 컴포넌트 잡아줌

    }

    // Update is called once per frame
    void Update()
    {


        move = Input.GetAxisRaw("Horizontal"); // 화살표나 A D 를 누르면
        Vector2 moveDir = new Vector2(move * Speed, rb2D.velocity.y); // x 축으로 Speed 만큼 이동, y 축은 기존의 y 값을 대입
        rb2D.velocity = moveDir;
        anim.SetFloat("Speed", Mathf.Abs(move)); // 애니메이션 파라미터 Speed 값을 잡아줌
        anim.SetBool("Ground", isGrounded); // 애니메이션 파라미터 Ground 값을 잡아줌
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers); // 오브젝트가 Ground 레이어에 닿아있는지 값을 isGrounded에 넣어줌

        if (((move > 0.0f && isFacingRight == false) || (move < 0.0f && isFacingRight == true)))
        { // 오른쪽을 향하고 있고, 오른쪽을 보지않으면 flip 함수실행
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        { // 스페이스 키를 입력하면 

            if (isGrounded == true)
            { // 땅에 닿아있으면
                rb2D.velocity = new Vector2(rb2D.velocity.x, 0); // x 축으로 이동가능
                rb2D.AddForce(new Vector2(0, jumpForce)); // y 축으로 jumpForce 만큼 힘을 준다
            }
        }

        //미사일 발사 함수
        if (Input.GetKeyDown("c") && isFacingRight == true)
        { // c 버튼을 누르고 오른쪽을 보고있으면
            GameObject rBullet = (GameObject)Instantiate(playerBulletRight); // rbullet 에 대입해준 오브젝트 생성
            rBullet.transform.position = bulletPoint.transform.position;
        }

        if (Input.GetKeyDown("c") && isFacingRight == false) // c버튼을 누르고 왼쪽을 보고있으면
        {
            GameObject lBullet = (GameObject)Instantiate(playerBulletLeft); // lbullet에 대입해준 오브젝트 생성
            lBullet.transform.position = bulletPoint.transform.position;
        }

    }


    void Flip() // 좌우 반전 함수
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1; // 반전 시켜줌
        transform.localScale = playerScale;
    }

}
