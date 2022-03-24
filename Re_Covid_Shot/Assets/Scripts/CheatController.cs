using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheatController : Singleton<CheatController>
{
    [SerializeField] GameObject cheatPanel;
    GameManager gameManager => GameManager.Instance;
    Player player => Player.Instance;

    [SerializeField] TMP_InputField stageInput;
    [SerializeField] TMP_InputField HPInput;
    [SerializeField] TMP_InputField painInput;

    void Start()
    {
        cheatPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InvisibilityTrue();
        InvisbilityFalse();
        AllEnemyDead();
        SpawnRed();
        SpawnWhite();
        CheatPanelShow();
        PowerUP();
    }

    private void PowerUP()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            
        }
    }

    public bool isInvisbilityCheat;
    void InvisibilityTrue()
    {
        

        if (Input.GetKeyDown(KeyCode.I))
        {
            isInvisbilityCheat = true;
            player.isInvisibility = true;
        }
    }

    private void InvisbilityFalse()
    {
        if (Input.GetKeyDown(KeyCode.O) && isInvisbilityCheat)
        {
            player.isInvisibility = false;
        }
    }

    private void AllEnemyDead()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++)
            {
                Enemy enemyLogic = enemies[i].GetComponent<Enemy>();
                enemyLogic.Dead();
            }
        }
    }

    private void SpawnRed()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnPoints.Instance.RedSpawn();
        }
    }

    private void SpawnWhite()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnPoints.Instance.WhiteSpawn();
        }
    }

    private void CheatPanelShow()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cheatPanel.SetActive(true);
            HPInput.text = "";
            painInput.text = "";
            stageInput.text = "";
        }

    }

    /// <summary>
    /// 입력 버튼을 눌렀을 때
    /// </summary>
    public void InputValue()
    {
        if (stageInput.text != "")
            MoveStageCheack(int.Parse(stageInput.text));

        if (HPInput.text != "")
            HPCheack(int.Parse(HPInput.text));
        if (painInput.text != "")
            painCheack(int.Parse(painInput.text));
        cheatPanel.SetActive(false);
    }

    void MoveStageCheack(int stage)
    {
        if (stage == 1 || stage == 2)
            StageFlow.Instance.MoveStage(stage);
        else
            return;

    }

    void HPCheack(int HPAmount)
    {
        if (HPAmount > 100 || HPAmount < 0)
            return;
        GameManager.Instance.HP = HPAmount;
    }

    void painCheack(int painAmount)
    {
        if (painAmount > 100 || painAmount < 0)
            return;
        GameManager.Instance.Pain = painAmount;
    }


}
