﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GameStart() {
        SceneManager.LoadScene("GameScene");
    }


}
