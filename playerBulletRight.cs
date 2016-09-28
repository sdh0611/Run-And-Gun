using UnityEngine;
using System.Collections;

public class playerBulletRight : MonoBehaviour {

    public float speed;      //미사일의 속도값을 저장하는 변수.
                             //Unity내에서 속도값을 조절할 수 있도록 public으로 변경하였음. 

    void Start () {

    }
	

	void Update () {

        Vector2 position = transform.position; 

        position = new Vector2(position.x + speed * Time.deltaTime * 1, position.y); // 시간당 미사일의 x좌표값을 speed * 1 만큼 바꿔준다 

        transform.position = position;

        Vector2 max= Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // max 값은 카메라 오른쪽 경계선

        if (transform.position.x > max.x) // 카메라 오른쪽 경계선을 넘으면 오브젝트 삭제
        {
            Destroy(gameObject);
        }
    }
}

