using UnityEngine;
using System.Collections;

public class playerBulletRight : MonoBehaviour {

    float speed;

    void Start () {
        speed = 13.0f; // 미사일의 속도 
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

