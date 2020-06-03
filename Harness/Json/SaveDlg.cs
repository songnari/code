using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;

public class Dialogue
{
    public int ID;
    public string Dlg;

    public Dialogue(int id, string dlg)
    {
        ID = id;
        Dlg = dlg;
    }
}

public class SaveDlg : MonoBehaviour
{
    public List<Dialogue> dlgList;
    public List<Dialogue> npcDlgList;
    public List<Dialogue> mapDlgList;
    public List<Dialogue> dayDlgList;
    public List<Dialogue> itemDlgList;
    public List<Dialogue> endDlgList;

    // Start is called before the first frame update
    void Start()
    {
        dlgList = new List<Dialogue>();
        npcDlgList = new List<Dialogue>();
        mapDlgList = new List<Dialogue>();
        dayDlgList = new List<Dialogue>();
        itemDlgList = new List<Dialogue>();
        endDlgList = new List<Dialogue>();

        SaveTutorialDlg();
        SaveMapDialogue();
        SaveDayDialogue();
        SaveItemDialogue();
        SaveNpcDialogue();
        SaveEndDialogue();
    }

    public void SaveDialogue(int dlgNum)
    {
        switch (dlgNum)
        {
            case 0:
                SaveTutorialDlg();
                break;
            case 1:
                SaveMapDialogue();
                break;
            case 2:
                SaveDayDialogue();
                break;
            case 3:
                SaveItemDialogue();
                break;
            case 4:
                SaveNpcDialogue();
                break;
            case 5:
                SaveEndDialogue();
                break;
        }
    }

    void SaveTutorialDlg()
    {
        //게임 시작
        dlgList.Add(new Dialogue(0, "방향키를 누르면 움직입니다.\n( Enter키를 누르면 다음으로 넘어갑니다. )"));
        dlgList.Add(new Dialogue(1, "?가 뜨는 곳으로 움직이세요.\n게임에 필요한 힌트를 얻을 수 있습니다."));
        dlgList.Add(new Dialogue(2, "?가 뜨는 곳에서 F키를 누르면\n아이템을 획득하거나 주변 사람과 대화를 할 수 있습니다."));
        dlgList.Add(new Dialogue(3, "이곳은 당신의 집 입니다."));
        dlgList.Add(new Dialogue(4, "외출 시 필요한 물건인\n지갑, 물, 강아지 간식, 썬글라스, 하네스를 찾아주세요."));

        //아이템 모두 찾은 후
        dlgList.Add(new Dialogue(5, "축하합니다!\n외출에 필요한 물건을 모두 찾았습니다."));
        dlgList.Add(new Dialogue(6, "이제 집 밖으로 나가볼까요?"));
        dlgList.Add(new Dialogue(7, "강아지에게 현관문 위치를 물어보세요."));
        dlgList.Add(new Dialogue(8, "Space 키를 누르면 강아지에게 도움을 요청할 수 있습니다."));

        //강아지에게 도움 요청 후
        dlgList.Add(new Dialogue(9, "강아지가 안내하는 곳으로 가세요."));

        //저장하는 부분
        JsonData dlgJson = JsonMapper.ToJson(dlgList);

        File.WriteAllText(Application.dataPath + "/Plugins/DlgData.json", dlgJson.ToString());
    }

    void SaveMapDialogue()
    {
        //day 1 집 >>> 동물병원
        mapDlgList.Add(new Dialogue(0, "집 밖으로 나왔습니다."));
        mapDlgList.Add(new Dialogue(1, "안내견의 정기검진이 있어 병원으로 가야합니다."));
        mapDlgList.Add(new Dialogue(2, "안내견의 도움을 받을 수도 있지만,"));
        mapDlgList.Add(new Dialogue(3, "길에서 만나는 여러 사람들과 아이템의 도움을 받을 수 있습니다."));
        mapDlgList.Add(new Dialogue(4, "사람들과의 대화는 T키를 누르면 대화를 나눌 수 있습니다."));
        mapDlgList.Add(new Dialogue(5, "다만 그들을 너무 믿는 것은 좋지 않을 수 있습니다."));
        mapDlgList.Add(new Dialogue(6, "길에는 시각장애인 유도블록도 있습니다."));
        mapDlgList.Add(new Dialogue(7, "직선으로 된 블록은 직진,\n점으로 된 블록은 시작지점 또는 종료지점, 위험지역을 뜻합니다."));
        mapDlgList.Add(new Dialogue(8, "유도블록도 유심히 살피며 병원을 향해 출발해봅시다!"));

        //day 3 집 >>> 카페
        mapDlgList.Add(new Dialogue(9, "오늘은 출판사 담당자와의 미팅이 있습니다."));
        mapDlgList.Add(new Dialogue(10, "당신이 그동안 열심히 썼던 책이 내일 출간한다고 하네요."));
        mapDlgList.Add(new Dialogue(11, "담당자와 만나기 위해 카페로 가볼까요?"));

        //day 6 집 >>> 서점
        mapDlgList.Add(new Dialogue(12, "드디어 당신의 책 [비욘드 아이즈]가 출간하는 날입니다."));
        mapDlgList.Add(new Dialogue(13, "그래서 서점으로 가 당신의 책을 확인하려고 합니다."));
        mapDlgList.Add(new Dialogue(14, "얼른 서점으로 가봅시다!"));

        //day 8 집 >>> 공원
        mapDlgList.Add(new Dialogue(15, "오늘은 쉬는 날이니까 놀러가는 것도 좋을 것 같아요."));
        mapDlgList.Add(new Dialogue(16, "여기 근처에 넓은 공원이 있다는 소식은 들었나요?"));
        mapDlgList.Add(new Dialogue(17, "간만에 햇빛 좀 쐴 겸 공원으로 가 산책을 해봅시다."));

        //저장하는 부분
        JsonData dlgJson = JsonMapper.ToJson(mapDlgList);

        File.WriteAllText(Application.dataPath + "/Plugins/MapDlgData.json", dlgJson.ToString());
    }
    public void SaveDayDialogue()
    {
        //병원 대화
        dayDlgList.Add(new Dialogue(0, "별 문제 없이 병원에 잘 도착했어."));
        dayDlgList.Add(new Dialogue(1, "검진 결과 몸무게도 정상이고 다 건강하대."));
        dayDlgList.Add(new Dialogue(2, "요즘 간식을 너무 많이 먹는 것 같아서\n걱정했는데 다행이야."));
        dayDlgList.Add(new Dialogue(3, "오늘 수고했어.\n이제 다시 집으로 돌아가자."));

        //카페 대화
        dayDlgList.Add(new Dialogue(4, "카페에 도착해서 담당자와 만났어."));
        dayDlgList.Add(new Dialogue(5, "출판사 내에서도 반응이 나쁘지는 않은가 봐."));
        dayDlgList.Add(new Dialogue(6, "너무 떨려.\n얼른 내일이 왔으면 좋겠어."));
        dayDlgList.Add(new Dialogue(7, "이제 다시 집으로 돌아가자."));

        //서점 대화
        dayDlgList.Add(new Dialogue(8, "직원\n손님 여기는 애완동물 출입금지입니다."));
        dayDlgList.Add(new Dialogue(9, "이 친구는 제 안내견인데요.\n안내견도 출입금지인가요?"));
        dayDlgList.Add(new Dialogue(10, "직원\n동물은 출입이 안 되는데..."));
        dayDlgList.Add(new Dialogue(11, "안내견을 출입이 가능하다고 알고 있는데요."));
        dayDlgList.Add(new Dialogue(12, "잠시후 우여곡절 끝에 서점에 들어갈 수 있었다.\n살짝 기분은 나쁘지만 그래도 오늘은 내 책이 나온 기쁜 날이니까."));
        dayDlgList.Add(new Dialogue(13, "직원\n무엇을 도와드릴까요?"));
        dayDlgList.Add(new Dialogue(14, "[비욘드 아이즈]을 찾고 있는데 어디 있는지 알려주시겠어요?"));
        dayDlgList.Add(new Dialogue(15, "직원\n[비욘드 아이즈]는 소설/에세이 서가에 있습니다."));
        dayDlgList.Add(new Dialogue(16, "직원\n소설/에세이 서가 A구역 세번째 책장 두번째 칸에 있네요."));
        dayDlgList.Add(new Dialogue(17, "...(그래서 A구역이 어디지... 그냥 직접 찾아보자.)"));
        dayDlgList.Add(new Dialogue(18, "직원\n감사합니다. 좋은 하루 되세요."));

        //저장하는 부분
        JsonData dlgJson = JsonMapper.ToJson(dayDlgList);

        File.WriteAllText(Application.dataPath + "/Plugins/DayDlgData.json", dlgJson.ToString());
    }
    public void SaveItemDialogue()
    {
        //길가, 공원에서 아이템 주웠을 때.
        itemDlgList.Add(new Dialogue(0, "이건 그냥 쓰레기인 것 같아. \n누가 길에 쓰레기를 버렸을까."));
        itemDlgList.Add(new Dialogue(1, "이 익숙한 느낌은...\n만원짜리 지폐야! 오늘은 운이 좋네."));
        itemDlgList.Add(new Dialogue(2, "이건 전단지인 거 같은데...\n헬스장이 오픈한다더니 거기 전단지인가?"));
        itemDlgList.Add(new Dialogue(3, "누가 지갑을 떨어뜨렸나봐. \n경찰서 가는 길은 알고 있으니 가져다줘야겠어."));
        itemDlgList.Add(new Dialogue(4, "강아지가 누가 떨어뜨린 음식을 먹고 있나 봐. \n그건 먹는 거 아니야. 얼른 뱉어."));

        //서점
        itemDlgList.Add(new Dialogue(5, "내 책이 아니야.\n 다른 곳을 찾아보자."));
        itemDlgList.Add(new Dialogue(6, "찾았다. 내 책이야!\n내 책도 찾았고 다른 사람들 반응도 충분히 본 것 같아.\n슬슬 집으로 돌아가자."));

        //저장하는 부분
        JsonData dlgJson = JsonMapper.ToJson(itemDlgList);

        File.WriteAllText(Application.dataPath + "/Plugins/ItemDlgData.json", dlgJson.ToString());
    }
    public void SaveNpcDialogue()
    {
        //도로 npc 대사
        npcDlgList.Add(new Dialogue(0, "여기 근처 공원이 정말 예쁘대요."));
        npcDlgList.Add(new Dialogue(1, "귀여운 강아지네. 강아지 간식이 좀 있는데 먹여도 돼요?"));
        npcDlgList.Add(new Dialogue(2, "바쁘세요? 얼굴에 근심이 보여 좋은 말씀 좀 전하려고 하는데..."));
        npcDlgList.Add(new Dialogue(3, "흠!"));
        npcDlgList.Add(new Dialogue(4, "죄송하지만 저는 바빠서 길을 알려드릴 시간이 없어요."));

        //서점 npc 대사
        npcDlgList.Add(new Dialogue(5, "깜짝이야. 서점에 왠 강아지람? \n여기 동물 출입이 되는 곳이었나?"));
        npcDlgList.Add(new Dialogue(6, "[죽고 싶지만 떡볶이는 먹고싶어] \n...이거 완전 내 얘긴데?"));
        npcDlgList.Add(new Dialogue(7, "오늘의 신작은 시각장애인과 안내견의 이야기래."));
        npcDlgList.Add(new Dialogue(8, "...\n...불러도 반응이 없다."));
        npcDlgList.Add(new Dialogue(9, "이 책 읽어보셨어요? \n궁금하시면 줄거리 얘기해드릴까요?"));

        //공원 npc 대사
        npcDlgList.Add(new Dialogue(10, "오늘은 날씨가 참 좋네요."));
        npcDlgList.Add(new Dialogue(11, "여기 공원 자판기는 코카콜라더라고요. \n역시 콜라는 코카콜라지!"));
        npcDlgList.Add(new Dialogue(12, "어제만 해도 바람이 좀 불더니 오늘은 너무 더워."));
        npcDlgList.Add(new Dialogue(13, "이 공원에는 큰 나무가 무려 12그루나 있대요."));
        npcDlgList.Add(new Dialogue(14, "분수대 앞에 있으면 물이 너무 튀니까 조심하세요."));

        //저장하는 부분
        JsonData dlgJson = JsonMapper.ToJson(npcDlgList);

        File.WriteAllText(Application.dataPath + "/Plugins/NpcDlgData.json", dlgJson.ToString());
    }
    public void SaveEndDialogue()
    {
        //진엔딩. 공원
        endDlgList.Add(new Dialogue(0, "오늘 날씨가 굉장히 좋아.\n햇볕이 이렇게 좋으니까 말이야."));
        endDlgList.Add(new Dialogue(1, "이런 날 헤어지려니 좀 아쉽긴 하네."));
        endDlgList.Add(new Dialogue(2, "그동안 나를 도와주고 안전한 길을 찾아줘서 고마워."));
        endDlgList.Add(new Dialogue(3, "...안녕."));

        //버스엔딩
        endDlgList.Add(new Dialogue(4, "아까 지나가던 사람의 말로는 여기서 버스를 타면 된대."));
        endDlgList.Add(new Dialogue(5, "[지금 들어오는 버스는 7번, 331번, 9600번 버스입니다.]"));
        endDlgList.Add(new Dialogue(6, "버스가 온다는 안내음이 들리네. \n곧 버스를 탈 수 있을 거야."));
        endDlgList.Add(new Dialogue(7, "그런데 지금 들어오는 버스 중에서 어느 버스를 타야 하지?"));
        endDlgList.Add(new Dialogue(8, "..."));

        //강아지 간식 엔딩
        endDlgList.Add(new Dialogue(9, "강아지가 자꾸 멈춰서네. \n길에서 또 뭘 발견한 거지?"));
        endDlgList.Add(new Dialogue(10, "지나가는 사람들이 주는 간식을 거부하지 못했더니 \n자꾸 길에서 뭘 먹으려고 해."));
        endDlgList.Add(new Dialogue(11, "이런. 배탈이 났나 봐."));
        endDlgList.Add(new Dialogue(12, "큰일이야. 여기서 가까운 동물병원이 어디 있지?"));
        endDlgList.Add(new Dialogue(13, "..."));

        //자판기 엔딩
        endDlgList.Add(new Dialogue(14, "간만에 산책을 했더니 목이 마르네."));
        endDlgList.Add(new Dialogue(15, "오늘은 시원한 탄산음료가 먹고 싶어."));
        endDlgList.Add(new Dialogue(16, "다행히 자판기에 점자 표기가 되어있네."));
        endDlgList.Add(new Dialogue(17, "그런데 모두 다 [음료]라고 표기가 되어있어. \n그러면 탄산음료는 어디 있지...?"));
        endDlgList.Add(new Dialogue(18, "..."));

        //저장하는 부분
        JsonData dlgJson = JsonMapper.ToJson(endDlgList);

        File.WriteAllText(Application.dataPath + "/Plugins/EndDlgData.json", dlgJson.ToString());
    }
}
