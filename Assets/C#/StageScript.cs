using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{
    //int型を変数StageTipSizeで宣言 数値は自動生成するオブジェクトの端から端までの座標の大きさ
    const int StageTipSize = 10;
    //int型を変数currentTipIndexで宣言
    int currentTipIndex;
    //ターゲットキャラクター指定できるようにする
    public Transform character;
    //ステージチップの配列
    public GameObject[] stageTips;
    //自動生成するする際に使う変数startTipIndex
    public int startTipIndex;
    //ステージ生成も先読み個数
    public int preInstantiate;
    //作ったステージチップの保持リスト
    public List<GameObject> generatedStageList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //初期化処理
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        //キャラクターの位置から現在のステージチップのインデックスを計算
        int charaPositionIndex =(int)(character.position.x/StageTipSize);
        //次のステージチップに入ったらステージの更新処理
        if (charaPositionIndex +preInstantiate > currentTipIndex )
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }
    //指定インデックスまでのステージチップを生成して管理下に置く
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;
        //指定のステージチップまで生成
        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            generatedStageList.Add(stageObject);
        }
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();
        currentTipIndex = toTipIndex;
    }
    //指定のインデックス位置にstageオブジェクトをランダムに生成
     GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0,stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate
            (stageTips[nextStageTip],
            new Vector3(tipIndex * StageTipSize, 0, 0), Quaternion.identity) as GameObject;
            
        return stageObject;
    }
    //一番古いステージを削除
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
