using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimTest : MonoBehaviour 
{
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.A)) {
			GetComponent<SimpleAnimation> ().Play("Jump");
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			GetComponent<SimpleAnimation> ().Play("Walk");
		}
	}
}