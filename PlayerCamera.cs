using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {
    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMax;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float yMin;
        
    private Transform target;
   // private PlayerStats  playerStats;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("player3").transform;
      //  playerStats = GameObject.FindObjectOfType<PlayerStats>();
    }
	
	// Update is called once per frame
	void LateUpdate () {

        if (target == null)
            target = GameObject.Find("playerDeath(Clone)").transform;

        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);       

	}
}
