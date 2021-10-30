using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;

public class ScenarioUseCase : MonoBehaviour
{
    [SerializeField]
    private Button _button;
   
    //  スクリプトデータ格納場所の用意
    private ScriptModel _scriptModel = null;
    // Start is called before the first frame update
    void Start()
    {
        //  実体を生成
        _scriptModel = new ScriptModel();
        _button.OnClickAsObservable()
             .ThrottleFirst(TimeSpan.FromMilliseconds(100))
             .Subscribe(_ => Debug.Log("button click"))
             .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _scriptModel.LoadScript("scenario");
        }
    }
}
