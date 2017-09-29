﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Rewired;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine.UI;

public class LD_VeryBeginning : MonoBehaviour {

    private Player player;
    private bool startOnce, canStart;

    void Awake()
    {
        player = ReInput.players.GetPlayer(0);
    }


    void Start()
    {
        DOVirtual.DelayedCall(4.5f, () => {
            canStart = true;
        });
        PlayerMovement.Singleton.MoveRight();
        PlayerMovement.Singleton.transform.DOMoveY(15, 0);
        PlayerMovement.Singleton.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

	// Use this for initialization
	void FuckGo () {

        GameManager.Singleton.CanPlay = false;


        PlayerMovement.Singleton.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        PlayerMovement.Singleton.transform.DOMoveY(0, 1.5f).SetEase(Ease.InElastic, -1, .5f);
        //PlayerMovement.Singleton.transform.DOMoveX(-8, 0);
        PlayerMovement.Singleton.transform.DOMoveX(-15, 0);
        PlayerMovement.Singleton.transform.DOLocalMoveX(PlayerMovement.Singleton.transform.position.x + 3f, 1.5f).SetEase(Ease.InElastic, - 1, .5f).OnComplete(() => {
            PlayerMovement.Singleton.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            string ShakeName = "ShakeKill";
            ProCamera2DShake.Instance.Shake(ShakeName);
            UIManager.Singleton.quoteText = "Alright, let's kick some asses!";
            UIManager.Singleton.QuoteCharacterStart(3.5f);
            DOVirtual.DelayedCall(1, () => {
                GameManager.Singleton.CanPlay = true;
                DOVirtual.DelayedCall(3.5f, () => {

                    UIManager.Singleton.QuoteCharacterStop();
                    
                });
            });
        }); 
    }

    
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            

            if(!startOnce && canStart)
            {
                startOnce = true;

                AudioManager.Singleton.GetComponentsInChildren<AudioSource>()[0].DOFade(1, 3f);

                UIManager.Singleton.TitleScreen.transform.GetChild(1).GetComponent<RainbowRotate>().enabled = true;

                UIManager.Singleton.TitleScreen.transform.GetChild(1).DOScale(2, 1.5f);

                UIManager.Singleton.TitleScreen.GetComponent<CanvasGroup>().DOFade(0, 1.5f).OnComplete(() =>{

                    FuckGo();
                });

            }
        }
    }
}
