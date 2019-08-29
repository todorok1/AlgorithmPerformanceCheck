using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// バブルソートを行うスクリプトです。
/// </Summary>
public class BubbleSortCheck : PerformanceBase {

    protected override void ExecuteSort(int index){
        // ソートしたい配列を定義します。
        int[] targetArray = GetTargetArray(index);

        // デバッグ用
        CheckArrayPart(targetArray, 100);

        // 開始時刻を記録します。
        startTime = System.DateTime.Now.Ticks;

        // バブルソートで配列の中身を昇順で並べ替えます。
        for (int i = 0; i < targetArray.Length; i++){

            // 要素の比較を行います。最後の要素は外側のループが終了するごとに確定します。
            for (int j = 1; j < targetArray.Length - i; j++){
                
                // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                if (targetArray[j] < targetArray[j - 1]){

                    // 配列の要素の交換を行います。
                    SwapElement(targetArray, j, j - 1);
                }
            }
        }

        // 計測した時間を表示します。
        ShowResultTime();

        // デバッグ用
        CheckArrayPart(targetArray, 100);
        CheckArrayOrder(targetArray);
    }
}
