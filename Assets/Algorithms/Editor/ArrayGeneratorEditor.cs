using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ArrayGenerator))]
public class ArrayGeneratorEditor : Editor {

    public override void OnInspectorGUI(){
		var generateArray = target as ArrayGenerator;
		DrawDefaultInspector();

        if (GUILayout.Button("配列データ作成")){

            if (generateArray.arraySize <= 0){
                return;
            }
            
            long startTime = System.DateTime.Now.Ticks;

            List<int> valueList = new List<int>();

			// ボタンを押されたら指定されたサイズで配列を生成します。
			for (int i = 0; i < generateArray.arraySize; i++){
                int value = Random.Range(1, 1000000);
                valueList.Add(value);
            }

            // リストを配列に変換します。
            int[] generatedArray = valueList.ToArray();

            // 生成した配列を持つScriptableObjectを生成します。
            string fileName = "targetArrayData.asset";
            string path = "Assets/Algorithms/" + fileName;
            var arrayHolder = CreateInstance<ArrayHolder>();

            arrayHolder.targetArray = generatedArray;

            // インスタンス化したものをアセットとして保存
            var asset = (ArrayHolder)AssetDatabase.LoadAssetAtPath(path, typeof(ArrayHolder));
            if (asset == null){
                AssetDatabase.CreateAsset(arrayHolder, path);
            } else {
                EditorUtility.CopySerialized(arrayHolder, asset);
                AssetDatabase.SaveAssets();
            }
            AssetDatabase.Refresh();

            long processTime = System.DateTime.Now.Ticks - startTime;
            Debug.Log($"処理時間は {processTime / 10000}ms でした。");
		}
    }
}
