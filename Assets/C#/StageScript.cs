using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{
    //int�^��ϐ�StageTipSize�Ő錾 ���l�͎�����������I�u�W�F�N�g�̒[����[�܂ł̍��W�̑傫��
    const int StageTipSize = 10;
    //int�^��ϐ�currentTipIndex�Ő錾
    int currentTipIndex;
    //�^�[�Q�b�g�L�����N�^�[�w��ł���悤�ɂ���
    public Transform character;
    //�X�e�[�W�`�b�v�̔z��
    public GameObject[] stageTips;
    //�����������邷��ۂɎg���ϐ�startTipIndex
    public int startTipIndex;
    //�X�e�[�W��������ǂ݌�
    public int preInstantiate;
    //������X�e�[�W�`�b�v�̕ێ����X�g
    public List<GameObject> generatedStageList = new List<GameObject>();
    // Start is called before the first frame update
    public GameObject[] coin;
    [SerializeField]GameObject bloz;
    [SerializeField] GameObject bloz1;
    [SerializeField] GameObject bloz2;
    [SerializeField] GameObject bloz3;
    [SerializeField] GameObject bloz4;
    [SerializeField] GameObject blo5z;
    [SerializeField] GameObject sil;
    [SerializeField] GameObject gold;
    [SerializeField] GameObject gold1;
    void Start()
    {
        //����������
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        //�L�����N�^�[�̈ʒu���猻�݂̃X�e�[�W�`�b�v�̃C���f�b�N�X���v�Z
        int charaPositionIndex =(int)(character.position.x/StageTipSize);
        //���̃X�e�[�W�`�b�v�ɓ�������X�e�[�W�̍X�V����
        if (charaPositionIndex +preInstantiate > currentTipIndex )
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }
    //�w��C���f�b�N�X�܂ł̃X�e�[�W�`�b�v�𐶐����ĊǗ����ɒu��
    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;
        //�w��̃X�e�[�W�`�b�v�܂Ő���
        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            generatedStageList.Add(stageObject);
        }
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();
        currentTipIndex = toTipIndex;
    }
    //�w��̃C���f�b�N�X�ʒu��stage�I�u�W�F�N�g�������_���ɐ���
     GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0,stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate
            (stageTips[nextStageTip],
            new Vector3(tipIndex * StageTipSize, 0, 0), Quaternion.identity) as GameObject;
            bloz.SetActive(true);
            bloz1.SetActive(true);
            bloz2.SetActive(true);
            bloz3.SetActive(true);
            bloz4.SetActive(true);
            blo5z.SetActive(true);
            sil.SetActive(true);
            gold.SetActive(true);
            gold1.SetActive(true);
        return stageObject;
    }
    //��ԌÂ��X�e�[�W���폜
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
