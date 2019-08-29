using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// バブルソートを改良したシェーカーソートを行うスクリプトです。
/// </Summary>
public class ShakerSortCheck : PerformanceBase {
    protected override void ExecuteSort(int index){
        // ソートしたい配列を定義します。
        int[] targetArray = GetTargetArray(index);

        // デバッグ用
        CheckArrayPart(targetArray, 100);

        // 開始時刻を記録します。
        startTime = System.DateTime.Now.Ticks;

        // 交換対象の範囲で先頭のインデックスを格納する変数です。
        int topIndex = 0;

        // 交換対象の範囲で最後尾のインデックスを格納する変数です。
        int bottomIndex = targetArray.Length - 1;

        // シェーカーソートで配列の中身を昇順で並べ替えます。
        while (true){
            // 最後に交換したインデックスを格納する変数です。
            int lastSwapIndex = topIndex;

            // 配列の前から後ろに向かって比較を行います。
            for (int i = topIndex; i < bottomIndex; i++){

                // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                if (targetArray[i] > targetArray[i + 1]){

                    // 配列の要素の交換を行います。
                    SwapElement(targetArray, i, i + 1);

                    // 交換を行なった要素のインデックスを保存します。
                    lastSwapIndex = i;
                }
            }

            // 最後に交換を行なったインデックスを後方の開始インデックスに設定します。
            bottomIndex = lastSwapIndex;

            // 交換範囲の確認を行い、全ての交換が終わっていたらwhileループを抜けます。
            if (topIndex == bottomIndex){
                break;
            }

            // 配列の後ろから前に向かって比較を行います。
            lastSwapIndex = bottomIndex;

            for (int i = bottomIndex; i > topIndex; i--){

                // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                if (targetArray[i] < targetArray[i - 1]){

                    // 配列の要素の交換を行います。
                    SwapElement(targetArray, i, i - 1);

                    // 交換を行なった要素のインデックスを保存します。
                    lastSwapIndex = i;
                }
            }

            // 最後に交換を行なったインデックスを前方の開始インデックスに設定します。
            topIndex = lastSwapIndex;

            // 交換範囲の確認を行い、全ての交換が終わっていたらwhileループを抜けます。
            if (topIndex == bottomIndex){
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
