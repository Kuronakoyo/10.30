using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptModel
{
    //  待機フラグ
    public bool IsWait { get; set; } = false;
    //  実行する行番号
    public int DoLineNum { get; set; } = 0;
    //  スクリプトを行単位で分けたリスト
    private List<string> _scriptStrings = new List<string>();
    //  ラベルを辞書化
    private Dictionary<string, int> _labelLineNums = new Dictionary<string, int>();

    /// <summary>
    /// スクリプトファイルの読み込み
    /// </summary>
    /// <param name="scriptFileName">スクリプトファイル名(拡張子は記述しない)</param>
    public void LoadScript(string scriptFileName)
    {
        //  Scenarioフォルダの下にあるファイルなのでこのようにファイル名を変更する
        //  "Scenario/scritFileName" というファイル名になる
        scriptFileName = "Scenario/" + scriptFileName;
        //  スクリプトをテキストで読み込む
        var scripts = Resources.Load<TextAsset>(scriptFileName);
        //  改行コード"\n"に統一する
        var scriptsText = scripts.text.Replace("\r\n", "\n").Replace("\r","\n");
        //  改行コードで文字列を分割する
        var splitTexts = scriptsText.Split('\n');
        //  「//」で始まる行と何もない行は無視する
        _scriptStrings = splitTexts.Where(x => x.IndexOf("//") < 0 && !string.IsNullOrWhiteSpace(x)).ToList();
    }
}
