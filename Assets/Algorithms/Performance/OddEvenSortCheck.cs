using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// バブルソートを改良した奇偶転置ソートを行うスクリプトです。
/// </Summary>
public class OddEvenSortCheck : PerformanceBase {
    protected override void ExecuteSort(int index){
        // ソートしたい配列を定義します。
        int[] targetArray = GetTargetArray(index);

        // デバッグ用
        CheckArrayPart(targetArray, 100);

        // 開始時刻を記録します。
        startTime = System.DateTime.Now.Ticks;

        // 奇偶転置ソートで配列の中身を昇順で並べ替えます。
        while (true){

            // 交換が発生したか確認するフラグを用意します。
            bool isChanged = false;

            // 開始インデックスが偶数の要素から後ろに向かってペアを作り比較を行います。
            for (int i = 0; i < targetArray.Length - 1; i += 2){

                // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                if (targetArray[i] > targetArray[i + 1]){

                    // 配列の要素の交換を行います。
                    SwapElement(targetArray, i, i + 1);

                    // 交換を行なったのでフラグをtrueにセットします。
                    isChanged = true;
                }
            }

            // 開始インデックスが奇数の要素から後ろに向かってペアを作り比較を行います。
            for (int i = 1; i < targetArray.Length - 1; i += 2){

                // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                if (targetArray[i] > targetArray[i + 1]){

                    // 配列の要素の交換を行います。
                    SwapElement(targetArray, i, i + 1);

                    // 交換を行なったのでフラグをtrueにセットします。
                    isChanged = true;
                }
            }

            // 交換が発生しなければwhileループを抜けます。
            if (!isChanged){
                break;
            }
        }

        // 計測した時間を表示します。
        ShowResultTime();

        // デバッグ用
        CheckArrayPart(targetArray, 100);
        CheckArrayOrder(targetArray);
    }
}
