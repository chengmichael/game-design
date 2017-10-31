using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardTarget : MonoBehaviour {

    public string targetTag;
	public float speed;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag(targetTag).transform.position, (speed * 0.1f));
    }

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.CompareTag ("Despawn"))
		{
			Destroy(gameObject);
		}
	}
}
