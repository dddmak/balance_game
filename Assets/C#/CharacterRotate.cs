using UnityEngine;
using System.Collections;

public class CharacterRotate : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Rotate (1f,0f,0f);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Rotate (-1f,0f,0f);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate (0f,0f,-1f);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate (0f,0f,1f);
        }
    }
}
