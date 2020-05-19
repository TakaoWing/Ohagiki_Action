using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Player引っ張って飛ばす */
/* Playerと指(マウス)の座標から飛ばす方向を指定*/
public class PlayerShot : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 FingerPos; // 指の座標
    [SerializeField]
    private float shotSpeed;
    [SerializeField]
    private float deceleration = 0.995f;
    private Vector2 startPos, endPos, shotDirection;
    public float shotPower; // 飛ばす力

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (this.rb.velocity.magnitude > 0.1f) return; // プレイヤーの速さがほぼゼロ→プレイヤーが止まったるまで以下の処理をしない

        if(Input.GetMouseButton(0)) setShotPower(); // ボタンが押された時のみパワーを変化

        if (Input.GetMouseButtonDown(0)) {
            shotPower = 0f;
            this.startPos = Input.mousePosition; //マウスを押した時の座標を取得
        }else if (Input.GetMouseButtonUp(0)) {
            this.endPos = Input.mousePosition;　//マウスを離した時の座標を取得
            this.shotDirection = -1 * (endPos - startPos).normalized; // 飛ばす方向を指定
            this.shotSpeed = shotPower * 20.0f + 0.1f; 
            this.rb.AddForce(shotDirection * shotSpeed, ForceMode2D.Impulse);
        }

    }

    void FixedUpdate() {
        /*減速*/
        this.rb.velocity *= deceleration;
    }

    private void setShotPower() {
        shotPower += 0.025f;
        if(shotPower > 1.025f) {
            shotPower = 0;
        }
    }
}
