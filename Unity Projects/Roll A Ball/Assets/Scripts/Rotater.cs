using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        // We will not using forces , therefore we will using Update() rather than FixedUpdate()
        // We already set our transform rotation to 45, 45 , 45 on rotation axis
        // But those values don't change by themselves. Therefore , we are going to do it here.
        // Make cube spin
        // To make it , don't use transform rotation , but to make rotate the transform
        // Docs : https://docs.unity3d.com/ScriptReference/Transform.html
        // We are going to use transform.Rotate . Docs : https://docs.unity3d.com/ScriptReference/Transform.Rotate.html

        // In order to make a smooth rotation , we should multiply them by Time.deltaTime
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
