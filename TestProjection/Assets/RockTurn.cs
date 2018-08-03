using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);

        other.gameObject.GetComponent<RockSound>().PlaySound = true;

        other.gameObject.GetComponent<Animator>().Play("rockturnloop");
    }
}
