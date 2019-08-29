using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// ノームソートを行うスクリプトです。
/// </Summary>
public class GnomeSortCheck : PerformanceBase {
    protected override void ExecuteSort(int index){
        // ソートしたい配列を定義します。
        int[] targetArray = GetTargetArray(index);

        // デバッグ用
        CheckArrayPart(targetArray, 100);

        // 開始時刻を記録します。
        startTime = System.DateTime.Now.Ticks;

        // 確認対象のインデックスを保持します。
        int gnome = 1;

        // ノームソートで配列の中身を昇順で並べ替えます。
        while (gnome < targetArray.Length){

            // ひとつ前の要素と比較し、順序が逆であれば入れ替えます。
            if (targetArray[gnome] < targetArray[gnome - 1]){
                // 配列の要素の交換を行います。
                SwapElement(targetArray, gnome, gnome - 1);

                // 確認対象のインデックスをひとつ戻します。
                gnome--;

                if (gnome == 0){
                    // 配列の最小インデックスの場合は次のインデックスに進みます。
                    gnome++;
                }
            } else {
                // 順序が正しい場合は次のインデックスに進みます。
                gnome++;
            }
        }

        // 計測した時間を表示します。
        ShowResultTime();

        // デバッグ用
        CheckArrayPart(targetArray, 100);
        CheckArrayOrder(targetArray);
    }
}
