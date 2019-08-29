# AlgorithmPerformanceCheck
交換ソートのアルゴリズムをC#で実装し、性能比較を行ったスクリプトです。  

以下のブログで性能比較と結果の評価を行なっています。  
https://ekulabo.com/algorithm-performance 
<br>
<br>
## ソートアルゴリズム
このプロジェクトでは以下のソートアルゴリズムの性能比較を行っています。  
<br>
1. バブルソート  
2. シェーカーソート  
3. 奇偶転置ソート  
4. コムソート  
5. ノームソート  
6. クイックソート  
<br>
<br>

## 配列格納用のScriptableObjectについて
[Assets/Create/Algorithm/Array Generator]からArray Generatorを作成できます。  
<br>
このArray Generatorでは任意の長さの配列を持ったArrayHolderのデータを作成できるので、お好きな長さの配列を作成してください。
<br>
配列生成のスクリプトについてはAlgorithm/EditorにあるArrayGeneratorEditorをご覧ください。 
<br>
<br>

## 性能テストの実施について
Algorithmのシーンを開き、PerformanceManagerのオブジェクトにArrayHolderをアタッチします。  
<br>

任意のソートアルゴリズムの名前が付いたGameObjectをアクティブの状態にしてゲームを実行すると、30フレームおきに処理が実行されます。 
<br>

配列が正しくソートできたかどうかは処理時間の後に表示される「配列の順序 : OK」の表示を確認します。 
<br>

もし順序がおかしい場合はNGが表示されるのでアルゴリズムが間違っているかもしれません。 
(連絡をいただけると嬉しいです。) 
<br>
<br>

## 実行結果の例
5回ずつ実行して処理時間の平均値を取ると以下のような結果となりました。単位はミリ秒(ms)です。 
<br>
<br>

![algorithm_performance_list](https://user-images.githubusercontent.com/38154899/63930232-dd174500-ca8d-11e9-9e9b-1e3ae0e9fdd7.jpg)
<br>
<br>

要素数が少なければコムソート、要素数が多ければクイックソートを使うと安定して速そうです。  
もし自分でソートアルゴリズムを作成する場合はこの辺りも考慮に入れて素敵なアルゴリズムを作ってくださいな。
<br>
<br>


