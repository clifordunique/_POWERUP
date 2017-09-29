﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class UIManager : MonoBehaviour {

    public static UIManager Singleton;

    public GameObject UIObject;

    public string quoteText;

    private GameObject quote;

    [HideInInspector]
    public GameObject TitleScreen, PowerUplogo, aGameBy;
    public GameObject CharacterQuote, QuoteContainer; 
    public SpriteRenderer powerUpScreen;
    private Text creditsCookiez, creditsFlo, creditsPietro, creditsTom;

    private Player player;

    // Use this for initialization

    void Awake()
    {

        if (Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this);
        }

        TitleScreen = UIObject.transform.GetChild(0).GetChild(0).gameObject;

        PowerUplogo = TitleScreen.transform.GetChild(1).gameObject;
        aGameBy = TitleScreen.transform.GetChild(3).gameObject;
        creditsCookiez = aGameBy.transform.GetComponentsInChildren<Text>()[1];
        creditsFlo = aGameBy.transform.GetComponentsInChildren<Text>()[2];
        creditsPietro = aGameBy.transform.GetComponentsInChildren<Text>()[3];
        creditsTom = aGameBy.transform.GetComponentsInChildren<Text>()[4];


        player = ReInput.players.GetPlayer(0);

        

    }

    void Start () {

        if(GameObject.Find("VeryBeginning") != null)
        {

            AudioManager.Singleton.GetComponentsInChildren<AudioSource>()[0].volume = .2f;

            TitleScreen.GetComponent<CanvasGroup>().DOFade(1, 1.5f);

            DOVirtual.DelayedCall(2.5f, () => {

                //aGameBy.transform.DOLocalMoveX(-10, 0);
                aGameBy.GetComponent<Text>().DOFade(1, .35f).OnComplete(() => {
                    DOVirtual.DelayedCall(.3f, () =>
                    {
                        creditsCookiez.transform.DOLocalMoveY(20, 0);
                        creditsCookiez.transform.DOLocalMoveY(-125, 0.2f).SetEase(Ease.InBounce);
                        creditsCookiez.GetComponent<RainbowColor>().enabled = true;
                        creditsCookiez.DOFade(1, .2f);
                        DOVirtual.DelayedCall(.25f, () =>
                        {
                            creditsFlo.transform.DOLocalMoveY(20, 0);
                            creditsFlo.transform.DOLocalMoveY(-125, 0.2f).SetEase(Ease.InBounce);
                            creditsFlo.GetComponent<RainbowColor>().enabled = true;
                            creditsFlo.DOFade(1, .2f);
                            DOVirtual.DelayedCall(.25f, () =>
                            {
                                creditsPietro.transform.DOLocalMoveY(20, 0);
                                creditsPietro.transform.DOLocalMoveY(-125, 0.2f).SetEase(Ease.InBounce);
                                creditsPietro.GetComponent<RainbowColor>().enabled = true;
                                creditsPietro.DOFade(1, .2f);
                                DOVirtual.DelayedCall(.25f, () =>
                                {
                                    creditsTom.transform.DOLocalMoveY(20, 0);
                                    creditsTom.transform.DOLocalMoveY(-125, 0.2f).SetEase(Ease.InBounce);
                                    creditsTom.GetComponent<RainbowColor>().enabled = true;
                                    creditsTom.DOFade(1, .2f);
                                });
                            });
                        });
                    });

                });
            });
        }

	}

    public void QuoteCharacterStart(float timeQuote)
    {
        quote = Instantiate(CharacterQuote, QuoteContainer.transform.position, Quaternion.identity, QuoteContainer.transform);
        quote.transform.localScale = Vector3.one;
        quote.GetComponent<Text>().text = quoteText;
        //Debug.Log("StartQuote");
        //UIManager.Singleton.CharacterQuote.SetActive(true);
        //CharacterQuote.GetComponent<RainbowColor>().enabled = true;
        //CharacterQuote.GetComponent<RainbowScale>().enabled = true;
        DOVirtual.DelayedCall(timeQuote, () => {
            QuoteCharacterStop();
        });
    }

    public void QuoteCharacterStop()
    {
        //Debug.Log("StopQuote");
        Destroy(quote);
        /*UIManager.Singleton.CharacterQuote.GetComponent<RainbowColor>().enabled = false;
        CharacterQuote.GetComponent<RainbowScale>().enabled = false;
        UIManager.Singleton.CharacterQuote.GetComponent<Text>().DOFade(0, .3f).OnComplete(() => {
            UIManager.Singleton.CharacterQuote.SetActive(false);
        });*/
    }

    // Update is called once per frame
    void Update () {


        if(quote != null)
        {

            Vector2 tmpPos = GameManager.Singleton.player.transform.position;
            tmpPos.y -= 1;
            quote.transform.position = tmpPos;

        }
        //CharacterQuote.transform.DOMove(GameManager.Singleton.player.transform.position,0);
        //TitleScreen.transform.position = 
    }
}
