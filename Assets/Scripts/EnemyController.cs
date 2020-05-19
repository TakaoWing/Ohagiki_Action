using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private HPController hpContoller;
    private Slider hpGauge;
    private int MAXHP,hp;

    void Start() {
        hpContoller = this.GetComponent<HPController>();
        hpGauge = this.transform.GetChild(0).transform.GetChild(0).GetComponent<Slider>();// Enemy > Canvas > HPGauge
        MAXHP = hpContoller.getMaxHP();
    }

    void Update() {
        this.hp = hpContoller.getHp();
        hpGauge.value = (float)this.hp / MAXHP;
        if(this.hp <= 0) {
            Destroy(this.gameObject);
        }
    }
}
