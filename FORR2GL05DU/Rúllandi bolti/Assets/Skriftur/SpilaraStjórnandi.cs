using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpilaraStjórnandi : MonoBehaviour {

    public float hraði;
    public Text stigaTextabox;
    public string stigaTexti;
    public Text sigurTextabox;
    public string sigurTexti;
    public float fjoldiMarkmida;

    private Rigidbody rb;
    private float stig;

    void Start () {
        rb = GetComponent<Rigidbody>();
        stig = 0;
        BreytaStigaTexta();
        sigurTextabox.text = "";
    }

    void FixedUpdate () {
        float hreifingLárétt = Input.GetAxis ("Horizontal");
        float hreifingLóðrétt = Input.GetAxis ("Vertical");

        Vector3 hreifing = new Vector3 (hreifingLárétt, 0, hreifingLóðrétt);

        rb.AddForce (hreifing * hraði);
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Markmið")) {
            other.gameObject.SetActive(false);
            stig += 1;
            BreytaStigaTexta();
            if (stig >= fjoldiMarkmida) {
                sigurTextabox.text = sigurTexti;
            }
        }
    }
    void BreytaStigaTexta() {
        stigaTextabox.text = stigaTexti + stig.ToString();
    }
}