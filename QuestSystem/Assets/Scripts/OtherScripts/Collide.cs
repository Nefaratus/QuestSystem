using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		col.GetComponent<Destination> ().destination = gameObject.name;
	}
}
