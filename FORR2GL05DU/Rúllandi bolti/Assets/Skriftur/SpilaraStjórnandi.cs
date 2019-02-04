using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpilaraStjórnandi : MonoBehaviour {
    public float hraði;
    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        float hreifingLárétt = Input.GetAxis ("Horizontal");
        float hreifingLóðrétt = Input.GetAxis ("Vertical");

        Vector3 hreifing = new Vector3 (hreifingLárétt, 0, hreifingLóðrétt);

        rb.AddForce (hreifing * hraði);
    }
}
