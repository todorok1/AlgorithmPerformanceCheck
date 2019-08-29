using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// クイックソートを行うスクリプトです。
/// </Summary>
public class QuickSortCheck : PerformanceBase {
    protected override void ExecuteSort(int index){
        // ソートしたい配列を定義します。
        int[] targetArray = GetTargetArray(index);

        // デバッグ用
        CheckArrayPart(targetArray, 100);

        // 開始時刻を記録します。
        startTime = System.DateTime.Now.Ticks;

        // クイックソートを行います。
        ExecuteQuickSort(targetArray, 0, targetArray.Length - 1);

        // 計測した時間を表示します。
        ShowResultTime();

        // デバッグ用
        CheckArrayPart(targetArray, 100);
        CheckArrayOrder(targetArray);
    }

    /// <Summary>
    /// 引数で渡された値の中から中央値を返します。
    /// </Summary>
    /// <param id="top">確認範囲の最初の要素</param>
    /// <param id="mid">中確認範囲の真ん中の要素</param>
    /// <param id="bottom">確認範囲の最後の要素</param>
    int GetMediumValue(int top, int mid, int bottom){
        if (top < mid){
            if (mid < bottom){
                return mid;
            } else if (bottom < top){
                return top;
            } else {
                return bottom;
            }
        } else {
            if (bottom < mid){
                return mid;
            } else if (top < bottom){
                return top;
            } else {
                return bottom;
            }
        }
    }

    /// <Summary>
    /// クイックソートを行います。
    /// </Summary>
    /// <param id="array">ソート対象の配列</param>
    /// <param id="left">ソート範囲の最初のインデックス</param>
    /// <param id="right">ソート範囲の最後のインデックス</param>
    void ExecuteQuickSort(int[] array, int left, int right){
        // 確認範囲が1要素しかない場合は処理を抜けます。
        if (left >= right){
            return;
        }

        // 左から確認していくインデックスを格納します。
        int i = left;

        // 右から確認していくインデックスを格納します。
        int j = right;

        // ピボット選択に使う配列の真ん中のインデックスを計算します。
        int mid = (left + right) / 2;

        // ピボットを決定します。
        int pivot = GetMediumValue(array[i], array[mid], array[j]);

        // 全ての値が同じだった場合は分割せず処理を終了します。
        if (pivot == -1){
            return;
        }

        while (true){
            // ピボットの値以上の値を持つ要素を左から確認します。
            while (array[i] < pivot){
                i++;
            }

            // ピボットの値以下の値を持つ要素を右から確認します。
            while (array[j] > pivot){
                j--;
            }

            // 左から確認したインデックスが、右から確認したインデックス以上であれば外側のwhileループを抜けます。
            if (i >= j){
                break;
            }

            // そうでなければ、見つけた要素を交換します。
            SwapElement(array, i, j);

            // 交換を行なった要素の次の要素にインデックスを進めます。
            i++;
            j--;
        }
    
        // 左側の範囲について再帰的にソートを行います。
        ExecuteQuickSort(array, left, i - 1);

        // 右側の範囲について再帰的にソートを行います。
        ExecuteQuickSort(array, j + 1, right);
    }
}
