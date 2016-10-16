using UnityEngine;
using System.Collections;

public class FlightPoints : MonoBehaviour {

    [HideInInspector]
    public bool isFacingRight = false;
    public GameObject waypointA;
    public GameObject waypointB;
    public float speed = 1;
    private bool directionAB = true;

    public bool shouldChangeFacing = false;


	void FixedUpdate () {
        if (transform.position == waypointA.transform.position
            && directionAB == false || transform.position
            == waypointB.transform.position && directionAB == true)
        {
            directionAB = !directionAB;
            if (shouldChangeFacing == true)
            {
               Flip();
            }
        }

        if (directionAB == true)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                waypointB.transform.position, speed * Time.fixedDeltaTime);
        }

        else {
            transform.position =
                Vector3.MoveTowards(transform.position,
                waypointA.transform.position, speed * Time.fixedDeltaTime);
        }
	}

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x = enemyScale.x * -1;
        transform.localScale = enemyScale;
    }
}
