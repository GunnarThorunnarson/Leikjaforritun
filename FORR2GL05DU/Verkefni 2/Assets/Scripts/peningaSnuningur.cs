using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peningaSnuningur : MonoBehaviour {

    public float hraði;

    // Update is called once per frame
    void Update() {
        transform.Rotate(new Vector3(0, hraði * 10, 0) * Time.deltaTime);
    }
}
