using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    CanvasGroup Team;

    [SerializeField]
    CanvasGroup Title;

    [SerializeField]
    CanvasGroup Cover;

    [SerializeField]
    CanvasGroup Play;

    [SerializeField]
    RectTransform AllChars;

    [SerializeField]
    AudioClip CiroMumble;

    [SerializeField]
    AudioSource Audio;

    [SerializeField]
    Image CiroFull;

    // Start is called before the first frame update
    void Start()
    {
        Team.alpha = 1;
        Title.alpha = 0;
        Play.alpha = 0;
        Cover.alpha = 1;
        Cover.DOFade(0, 3);
        CiroFull.gameObject.SetActive(false);

        DOVirtual.DelayedCall(4, () =>
        {
            Cover.DOFade(1, 1).OnComplete(() =>
            {
                Team.alpha = 0;
                Title.alpha = 1;
                Cover.DOFade(0, 2).OnComplete(() =>
                {
                    Audio.clip = CiroMumble;
                    Audio.Play();
                    AllChars.DOAnchorPosX(900, 7).SetLoops(-1,LoopType.Restart).OnComplete(() => {
                        //CiroFull.gameObject.SetActive(true);
                        //AllChars.DOAnchorPosX(-600, 0);
                        Audio.Play();
                    });
                    foreach (var carat in AllChars.GetComponentsInChildren<Image>())
                    {
                        carat.rectTransform.DOAnchorPosY(Random.Range(-40,40), .5f).SetLoops(-1, LoopType.Yoyo);
                    }
                    Play.DOFade(1, 2);
                });
            });
        });
    }

    public void DoPlay()
    {
        SceneManager.LoadScene("gioco");
    }
}
