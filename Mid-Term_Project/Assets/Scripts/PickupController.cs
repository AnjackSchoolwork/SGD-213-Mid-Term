using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

    public float rotate_speed;
    public float bob_height;
    

    private ArrayList pickups;

	// Use this for initialization
	void Start () {
		foreach (GameObject pickup_instance in GameObject.FindGameObjectsWithTag("pickup"))
        {
            pickups.Add(pickup_instance);
        }
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject pickup_instance in GameObject.FindGameObjectsWithTag("pickup"))
        {
            pickup_instance.transform.Rotate(Vector3.up, rotate_speed * Time.deltaTime);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<PlayerStatsController>().score += 10;
            Destroy(this.gameObject);
        }
    }
}
