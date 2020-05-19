using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    [SerializeField]
    private int MAXHP = 100;
    private int hp;
    [SerializeField]
    private string DamageObjTag;

    void Start()
    {
        hp = MAXHP;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Contains(DamageObjTag)) {
            hp--;
        }
    }

    public int getMaxHP() {
        return MAXHP;
    }

    public int getHp() {
        return hp;
    }
}
