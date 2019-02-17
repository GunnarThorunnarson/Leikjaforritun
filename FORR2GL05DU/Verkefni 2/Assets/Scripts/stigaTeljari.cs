using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// Ég sæki þetta til þess að geta unnið með UI í scriptu
using UnityEngine.SceneManagement;// Hérna sæki ég það sem ég nota til þess að restarta leiknum

public class stigaTeljari : MonoBehaviour {

    // Hérna bý ég til breytur sem þurfa ekki að vera stilltar í unity editorinum
    private float stig;
    private bool buid;
    private bool respawn;

    // Hérna sæki ég breytur sem er hægt að breyta í unity editorinum
    public GameObject byrjunarStaður;
    public Text stigaTextabox;
    public Text sigurTextabox;
    public Text tímaTextabox;
    public string stigaTexti;
    public string sigurTexti;
    public string tapTexti;
    public string tímaTexti;
    public float fjoldiMarkmiða;
    public GameObject feliMynd;

    // Start is called before the first frame update
    void Start() {// Hérna seti ég nokkrar breytur
        stig = 0;
        UppfæraStigaTexta();
        sigurTextabox.text = "";
        respawn = false;
        buid = false;
    }

    void Update() {
        if (buid is false) {// Þetta uppfærir tíma skjáinn ef spilarinn er ekki búinn að vinna
            tímaTextabox.text = tímaTexti + System.Math.Round(Time.timeSinceLevelLoad,2).ToString();// Þetta námundar tímann síðan levelið byrjaði að tveimur aukastöfum, breytir því í streng og bætir því svo við á skjáinn
        }
        if (Input.GetButtonDown("Restart") == true) {// Þetta gerist ef spilarinn ýtir á r
            ByrjaUppANytt();
        }
    }
    void FixedUpdate() {
        if (respawn is true){//Þetta sendir spilarann á upphafstaðinn ef hann lendir í sjónum og þetta virkaði bara í fixedUpdate vegna þess að annars færði firstPersonControllerin spilarann til baka
            transform.position = byrjunarStaður.transform.position;// Þetta færir spilarann aftur á default spawnpointinn
            if (buid is false) {// Þetta passar að maður tapi ekki hversu langt maður er kominn ef maður er búinn að vinna
                sigurTextabox.text = tapTexti;// Þetta setir taptextann á skjáinn
                ByrjaUppANytt();
            }
        }
    }

    void OnTriggerEnter(Collider hlutur) {
        if (hlutur.gameObject.CompareTag("peningur")) {// Þetta gerist ef spilarinn snertir pening
            hlutur.gameObject.SetActive(false);// Þetta felur peninginn
            stig += 1;// Þetta er stigateljarinn
            UppfæraStigaTexta();
            if (stig >= fjoldiMarkmiða) {// Þetta gerist bara ef spilarinn er kominn með jafn mörg stig og komu inn með breytuni fjoldiMarkmida sem er annaðhvort fjöldi peninganna eða 1 þegar ég er að debugga endaskjáinn
                sigurTextabox.text = sigurTexti;
                buid = true;// Þetta er til þess að láta vats colliderinn vita að drepa spilarann ekki og til þess að segja tímanum að stoppa
                feliMynd.SetActive(true);// Þetta er til þess að skjárinn verði svartur þegar maður vinnur leikinn (fyrir utan allan texta)
            }
        }
        if (hlutur.gameObject.CompareTag("sjór")) {// Þetta gerist ef spilarinn snertir sjóinn
            respawn = true;// Kóðinn til þess að senda spilarann til baka er ekki hérna vegna þess að þá tók FirstPersonControlerin yfir og setti spilarann til baka nema að þetta væri í FixedUpdate
        }
    }

    void UppfæraStigaTexta() {// Þetta fall uppfærir bara stigaskjáinn
        stigaTextabox.text = stigaTexti + stig.ToString();
    }
    void ByrjaUppANytt() {//Þetta fall byrjar levelið upp á nýtt
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);// Þetta byrjar að fá nafnið á levelinu sem er í gangi núna og loadar því svo svo að levelið endurræsist
    }
}
