using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stigaTeljari : MonoBehaviour {

    private float stig;
    private bool buid;
    private bool respawn;

    public GameObject spilari;
    public GameObject byrjunarStaður;
    public Text stigaTextabox;
    public Text sigurTextabox;
    public Text tímaTextabox;
    public string stigaTexti;
    public string sigurTexti;
    public string tapTexti;
    public float tapBið;
    public string tímaTexti;
    public float fjoldiMarkmiða;

    // Start is called before the first frame update
    void Start() {
        stig = 0;
        UppfæraStigaTexta();
        sigurTextabox.text = "";
        respawn = false;
        buid = false;
    }

    // Update is called once per frame
    void Update() {
        if (buid is false) {
            tímaTextabox.text = tímaTexti + System.Math.Round(Time.timeSinceLevelLoad,2).ToString();
        }
    }
    void FixedUpdate() {
        if (respawn is true){//Þetta sendir spilarann á upphafstaðinn ef hann lendir í sjónum
            transform.position = byrjunarStaður.transform.position;
            respawn = false;
            if (buid is false) {// Þetta passar að maður tapi ekki hversu langt maður er kominn ef maður er búinn að vinna
                sigurTextabox.text = tapTexti;
                SceneManager.LoadScene (SceneManager.GetActiveScene ().name);//Þetta byrjar levelið upp á nýtt
            }
        }
    }

    void OnTriggerEnter(Collider hlutur) {
        if (hlutur.gameObject.CompareTag("peningur")) {
            hlutur.gameObject.SetActive(false);
            stig += 1;
            UppfæraStigaTexta();
            if (stig >= 10) {
                sigurTextabox.text = sigurTexti;
                buid = true;
            }
        }
        if (hlutur.gameObject.CompareTag("sjór")) {
            respawn = true;
        }
    }

    void UppfæraStigaTexta() {
        stigaTextabox.text = stigaTexti + stig.ToString();
    }
}
