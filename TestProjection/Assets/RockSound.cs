using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSound : MonoBehaviour {

    public bool PlaySound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (PlaySound)
        {
            if (!this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("rockturnloop"))
            {
                this.GetComponent<AudioSource>().Play();

                PlaySound = false;
            }
        }
	}
}
