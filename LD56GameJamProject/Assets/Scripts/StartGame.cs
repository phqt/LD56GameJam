using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class StartGame : MonoBehaviour
{
    public float fadeDuration = 3f;

    public RawImage startCanvasColor;
    public GameObject thePlayer;
    public GameObject startCanvas;
    public RawImage blackScreen;
    public Image startButton;
    public TMP_Text startText;
    public Image endButton;
    public TMP_Text endText;
    public TMP_Text titleText;
    public TMP_Text byText;

    public void startTheGame()
    {
        startCanvasColor.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
        byText.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
        titleText.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
        startButton.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
        startText.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
        endButton.DOFade(0, fadeDuration).SetEase(Ease.InOutSine);
        endText.DOFade(0, fadeDuration).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            thePlayer.GetComponent<PlayerMovement>().enabled = true;
            Destroy(startCanvas);
        });
    }
}
