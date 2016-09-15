using UnityEngine;
using System.Collections;

public class playerBulletLeft : MonoBehaviour
{
    float speed;
    // Use this for initialization
    void Start()
    {
        speed = 13.0f;
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
