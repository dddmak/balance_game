using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {
	public string sceneName;
	Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	public void click () {
		Debug.Log ("click");
			SceneManager.LoadScene (sceneName);
	}
}
