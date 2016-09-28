using UnityEngine;
using System.Collections;

public class playerBulletLeft : MonoBehaviour
{
    public float speed;     //미사일의 속도값을 저장하는 변수.
                            //Unity내에서 속도값을 조절할 수 있도록 public으로 변경하였음. 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x + speed * Time.deltaTime * -1, position.y);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.x < min.x )
        {
            Destroy(gameObject);
        }
    }
}
