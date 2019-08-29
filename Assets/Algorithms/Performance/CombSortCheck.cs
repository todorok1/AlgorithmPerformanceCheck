using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// コムソート(コームソート)を行うスクリプトです。
/// </Summary>
public class CombSortCheck : PerformanceBase {
    protected override void ExecuteSort(int index){
        // ソートしたい配列を定義します。
        int[] targetArray = GetTargetArray(index);

        // デバッグ用
        CheckArrayPart(targetArray, 100);

        // 開始時刻を記録します。
        startTime = System.DateTime.Now.Ticks;

        // 交換が発生したかどうかのフラグです。
        bool isChanged = false;

        // 櫛の間隔を定義します。
        int h = targetArray.Length;

        // コムソートで配列の中身を昇順で並べ替えます。
        while (isChanged || h > 1){

            // 櫛の間隔を計算します。
            if (h > 1){
                h = Mathf.FloorToInt(h / 1.3f);
            }

            isChanged = false;
            for (int i = 0; i < targetArray.Length - h; i++){

                // 指定した間隔の要素と比較し、順序が逆であれば入れ替えます。
                if (targetArray[i] > targetArray[i + h]){
                    // 配列の要素の交換を行います。
                    SwapElement(targetArray, i, i + h);

                    // 交換フラグをtrueにします。
                    isChanged = true;
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
