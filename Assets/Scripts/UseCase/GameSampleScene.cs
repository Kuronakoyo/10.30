using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSampleScene : MonoBehaviour
{
    //画面フェードのためのキャンパスグループ
    [SerializeField]
    private CanvasGroup _fadeCanvasGroup = null;
    [SerializeField]
    private float _fadeTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //フェードアウト
        if (Input.GetMouseButtonDown(0))
        {
            FadeIn().Forget();
            // StartCoroutine(FadeInCoroutine());
        }
        //フェードイン
        else if (Input.GetMouseButtonDown(1))
        {
            FadeIn().Forget();
           // StartCoroutine(FadeOutCoroutine());
        }
    }
  
    private IEnumerator FadeOutCoroutine()
    {
        //画面が表示される場合最初にこの画面のタップを有効にして下の画面のボタンを押せないようにする
        _fadeCanvasGroup.GetComponent<Image>().raycastTarget = true;
        //不透明に設定
        _fadeCanvasGroup.alpha = 0;
        //透明になるまで繰り返し
        while (_fadeCanvasGroup.alpha > 0)
        {
            //とりあえず１秒でフェードアウトするように
            //アルファ値を減らす
            _fadeCanvasGroup.alpha += Time.deltaTime * (1.0f / _fadeTime);
            //値が０～１の範囲外ならば０または１を返す１
            //０より小さい場合は０に、１より大きい場合は１にする
            _fadeCanvasGroup.alpha = Mathf.Clamp01(_fadeCanvasGroup.alpha);
            //１フレーム待つ
            yield return null;
        }
    }
    private IEnumerator FadeInCoroutine()
    {
        //画面が表示される場合最初にこの画面のタップを有効にして下の画面のボタンを押せないようにする
        _fadeCanvasGroup.GetComponent<Image>().raycastTarget = true;
        //不透明に設定
        _fadeCanvasGroup.alpha = 0;
        //透明になるまで繰り返し
        while (_fadeCanvasGroup.alpha > 0)
        {
            //とりあえず１秒でフェードアウトするように
            //アルファ値を減らす
            _fadeCanvasGroup.alpha -= Time.deltaTime * (1.0f / _fadeTime);
            //値が０～１の範囲外ならば０または１を返す１
            //０より小さい場合は０に、１より大きい場合は１にする
            _fadeCanvasGroup.alpha = Mathf.Clamp01(_fadeCanvasGroup.alpha);
            //１フレーム待つ
            yield return null;
        }
    }
    private async UniTask FadeIn()
    {
        //画面が表示される場合最初にこの画面のタップを有効にして下の画面のボタンを押せないようにする
        _fadeCanvasGroup.GetComponent<Image>().raycastTarget = true;
        //不透明に設定
        _fadeCanvasGroup.alpha = 0;
        //透明になるまで繰り返し
        while(_fadeCanvasGroup.alpha > 0)
        {
            //とりあえず１秒でフェードアウトするように
            //アルファ値を減らす
            _fadeCanvasGroup.alpha -= Time.deltaTime * (1.0f / _fadeTime);
            //値が０～１の範囲外ならば０または１を返す１
            //０より小さい場合は０に、１より大きい場合は１にする
            _fadeCanvasGroup.alpha = Mathf.Clamp01(_fadeCanvasGroup.alpha);
            //引数の２番目０と書かれているところに最小値
            //引数の３番目１と書かれているところに最大値
            _fadeCanvasGroup.alpha = Mathf.Clamp(_fadeCanvasGroup.alpha, 0, 1) ;
            //アルファが1を超えたら１に設定しなおす
            // if (_fadeCanvasGroup.alpha > 1)
            //    _fadeCanvasGroup.alpha = 1;
            //１フレーム待つ
            await UniTask.Yield(PlayerLoopTiming.Update);
        }
    }
}
