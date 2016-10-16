using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    [HideInInspector]
    public bool isFacingRight = false;
    public float Speed = 1.5f;

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x = enemyScale.x * -1;
        transform.localScale = enemyScale;
    }
}
