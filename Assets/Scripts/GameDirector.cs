using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*ユーザーの情報などからUIを操作するプログラム*/
public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private Slider shotPowerGauge;
    [SerializeField]
    private Scrollbar playerHPBar;
    [SerializeField]
    private GameObject player;
    private PlayerShot playerShot;
    private HPController playerHPController;
    private int playerHP,playerMAXHP;

    [SerializeField]
    private GameObject gameEndPanel;
    [SerializeField]
    private Text panelText;

    [SerializeField]
    private int enemyNum;

    void Start()
    {
        gameEndPanel.SetActive(false);
        playerShot = player.GetComponent<PlayerShot>();
        playerHPController = player.GetComponent<HPController>();
        playerMAXHP = playerHPController.getMaxHP();
    }

    void Update()
    {
        shotPowerGauge.value = playerShot.shotPower;
        playerHP = playerHPController.getHp();
        playerHPBar.size = (float)playerHP / playerMAXHP;

        enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyNum == 0) {
            panelText.text = "GAME\n CLEAR";
            panelText.color = Color.yellow;
            gameEndPanel.SetActive(true);
        }else if(playerHP <= 0) {
            panelText.text = "GAME\n OVER";
            panelText.color = Color.blue;
            gameEndPanel.SetActive(true);
        }
        
    }

    
}
