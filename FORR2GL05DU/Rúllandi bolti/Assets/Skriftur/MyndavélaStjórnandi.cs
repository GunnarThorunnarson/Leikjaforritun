using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyndavélaStjórnandi : MonoBehaviour {

    public GameObject spilari;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start() {
        offset = transform.position - spilari.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.position = spilari.transform.position + offset;
    }
}
