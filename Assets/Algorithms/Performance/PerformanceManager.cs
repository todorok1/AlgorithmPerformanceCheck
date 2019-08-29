using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <Summary>
/// パフォーマンス計測のマネージャクラスです。
/// </Summary>
public class PerformanceManager : MonoBehaviour {

    // 各スクリプトで共通してソートを行う元データを保持します。
    public List<ArrayHolder> arrayHolders;
    
}
