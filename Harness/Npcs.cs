using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npcs : MonoBehaviour
{
    public GameObject ui;
    protected NavMeshAgent agent;

    public int id;
    public int startDlgId = 0;
    public int endDlgId = 4;
    public bool noCounting;
    NpcDlg npcDlg;
    NpcNev npcNev;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        npcDlg = ui.GetComponent<NpcDlg>();
        npcNev = GetComponent<NpcNev>();
        setId();

    }

    void setId() // 랜덤으로 id값을 받아오게 수정했으면 좋겠음
    {
        id = Random.Range(startDlgId, endDlgId);
    }

    public void showDlg()
    {
        if(!noCounting)
            GameManager.instance.findNpc();
        agent.isStopped = true;
        npcDlg.npcDlg(id);
    }

    public void moveNpc()
    {
        agent.isStopped=false;
    }

}
