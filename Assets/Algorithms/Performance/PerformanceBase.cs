using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// パフォーマンス計測用スクリプトのベースクラスです。
/// </Summary>
public class PerformanceBase : MonoBehaviour {

    // 開始時刻を保持する変数です。
    protected long startTime;

    // 終了時刻を保持する変数です。
    protected long finishTime;

    // 交換回数を保持する変数です。
    protected long swapNum = 0;

    // パフォーマンス計測に使う配列を保持します。
    protected List<ArrayHolder> targetArrays;

    // 確認対象となる配列を持ったArrayHolderのインデックスです。
    protected int index;

    protected void Start(){
        SetTargetArrayReference();
        ShowClassName();
    }

    protected void Update(){
        PerformanceCheck();
    }

    /// <Summary>
    /// パフォーマンス計測のマネージャーへの参照を取得し、対象の配列を取得します。
    /// </Summary>
    protected void SetTargetArrayReference(){
        // マネージャーオブジェクトへの参照を取得します。
        GameObject managerObj = GameObject.Find("PerformanceManager");

        // マネージャースクリプトへの参照を取得します。
        PerformanceManager performanceManager = managerObj.GetComponent<PerformanceManager>();

        // マネージャースクリプトにアタッチされた計測用配列への参照をセットします。
        targetArrays = performanceManager.arrayHolders;

        // インデックスをセットします。
        index = 0;
    }

    /// <Summary>
    /// 確認対象のクラス名をコンソールに表示します。
    /// </Summary>
    protected void ShowClassName(){
        string className = this.GetType().Name;
        Debug.Log($"{className}の処理を開始します。");
    }

    /// <Summary>
    /// パフォーマンス計測用の処理を呼び出します。
    /// </Summary>
    protected void PerformanceCheck(){
        // インデックスがtargetArraysの範囲外にある場合は処理を行いません。
        if (index >= targetArrays.Count){
            return;
        }

        // 他のスクリプトで処理が行われる初期フレームを避け、30フレームごとにソートを呼び出します。
        int targetFrame = (index + 1) * 30;
        if (Time.frameCount != targetFrame){
            return;
        }

        // 配列の要素数をコンソールに表示します。
        int elementNum = targetArrays[index].targetArray.Length;
        Debug.Log($"要素数 {elementNum} の配列に対してExecuteSort()を開始します。");

        // パラメータをリセットします。
        ResetParam();

        // ソートを実行します。
        ExecuteSort(index);

        // 処理終了後にインデックスを増加させます。
        index++;
    }

    /// <Summary>
    /// ソート処理を行います。
    /// 継承したスクリプトで詳細なソート処理を記述します。
    /// </Summary>
    protected virtual void ExecuteSort(int index){

    }

    /// <Summary>
    /// 計測用配列リストから、確認対象の配列をコピーして返します。
    /// </Summary>
    /// <param id="index">リスト内のインデックス</param>
    protected int[] GetTargetArray(int index){
        // 対象のArrayHolderを取得します。
        ArrayHolder holder = targetArrays[index];

        // ArrayHolderから配列をコピーして返します。
        int[] array = (int[]) holder.targetArray.Clone();
        return array;
    }

    /// <Summary>
    /// 配列の指定範囲をコンソールに表示します。
    /// </Summary>
    /// <param id="array">表示対象の配列</param>
    /// <param id="range">配列を表示する範囲</param>
    protected void CheckArrayPart(int[] array, int range){
        // 配列の大きさより広い範囲が指定されていたら配列の大きさにセットし直します。
        if (range > array.Length){
            range = array.Length;
        }

        // 結果格納用のStringBuilderを作成します。
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        // 出力用のテキストをアペンドします。
        sb.Append($"配列 :");

        for (int i = 0; i < range; i++){
            // 配列の中身をアペンドします。
            sb.Append(" ").Append(array[i]).Append(",");
        }

        // 最後のカンマを削除します。
        sb.Remove(sb.Length - 1, 1);

        // コンソールに出力します。
        Debug.Log(sb.ToString());
    }

    /// <Summary>
    /// 配列要素の交換を行います。
    /// </Summary>
    /// <param id="array">対象の配列</param>
    /// <param id="targetA">交換する要素のインデックス</param>
    /// <param id="targetB">交換する要素のインデックス</param>
    protected void SwapElement(int[] array, int targetA, int targetB){
        int temp = array[targetA];
        array[targetA] = array[targetB];
        array[targetB] = temp;

        // 交換回数を増やします。
        swapNum++;
    }

    /// <Summary>
    /// 計測した時間をコンソールに出力します。
    /// </Summary>
    protected void ShowResultTime(){

        // 処理が終了した時点での時刻を取得します。
        long finishTime = System.DateTime.Now.Ticks;

        // 処理時間を計算します。
        long processTime = finishTime - startTime;

        // 処理時間をミリ秒単位に変換します。
        float millisecondsTime = processTime / 10000f;

        Debug.Log($"処理時間は {millisecondsTime}ms でした。");
        Debug.Log($"交換回数は {swapNum} 回でした。");
    }

    /// <Summary>
    /// 計測用パラメータを初期化します。
    /// </Summary>
    protected void ResetParam(){
        startTime = 0;
        finishTime = 0;
        swapNum = 0;
    }

    /// <Summary>
    /// ソート後の配列の順序が正しく昇順になっていることを確認します。
    /// </Summary>
    protected void CheckArrayOrder(int[] array){
        string arrayCondition = "OK";
        for (int i = 1; i < array.Length; i++){
            if (array[i] < array[i - 1]){
                arrayCondition = "NG";
                break;
            }
        }

        Debug.Log($"配列の順序 : {arrayCondition}");
    }
}
