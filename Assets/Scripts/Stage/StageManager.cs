using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{

    [SerializeField]
    private GameObject[] prefabs;
    [SerializeField]
    private GameObject[] MonsterSpawner;
    [SerializeField]
    private GameObject GameProceedUI;
    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private PoolManager m_poolManager;
    [SerializeField]
    private HPUI m_hpUI;
    [SerializeField]
    private TimerUI m_timerUI;
    [SerializeField]
    private CookieUI m_cookieUI;
    [SerializeField]
    private int m_iTime;
    [SerializeField]
    private GameObject m_plane;
    private Renderer m_renderer;
    [SerializeField]
    private Material[] m_materials;

    public PlayerController m_player;
    public float m_playerNowHP;
    public Vector3 PlayerPosition;

    public bool m_bIsGameOver;



    private void Awake()
    {

        m_player = GameObject.Find("Player").GetComponent<PlayerController>();
        CookieManager.Instance.WakeUp();
    }

    private void Start()
    {
       
      

    }
  
    void Update()
    {
       if(m_player.m_fNowHP<=0)
        {
            StageEndToReplay();
        }

       
    }


    #region StageStart
   
    public void StageStart()
    {
        m_hpUI.gameObject.SetActive(true);
        m_timerUI.gameObject.SetActive(true);
        m_timerUI.StageStart();
        m_cookieUI.gameObject.SetActive(true);

        m_player.StartStage();

        int mat = Random.Range(0, 8);
        m_plane.gameObject.GetComponent<MeshRenderer>().material= m_materials[mat];

        switch (MapManager.NowRoom)
        {
            case RoomType.None:
                break;
            case RoomType.Room_RampageGuys:
                StartCoroutine(MonsterSpawn01());
                StartCoroutine(MonsterSpawn02());
                break;
            case RoomType.Room_SturdyHunks:
                StartCoroutine(MonsterSpawn03());
                StartCoroutine(MonsterSpawn04());
                break;
            case RoomType.Room_Anvil:
                break;
            case RoomType.Room_HumanWave:
                StartCoroutine(MonsterSpawn01());
                StartCoroutine(MonsterSpawn02());
                StartCoroutine(MonsterSpawn03());
                StartCoroutine(MonsterSpawn04());
                break;
            case RoomType.Room_Danger:
                StartCoroutine(MonsterSpawn05());
               // StartCoroutine(MonsterSpawn06());
                break;
            case RoomType.Room_Cookie:
                StartCoroutine(MonsterSpawn07());
                MonsterSpawn08();
          
                break;
            case RoomType.Room_BOSS:
                MonsterSpawn09();
                break;
            default:
                break;

        }

        StageTimeCheck();
        m_bIsGameOver = false;
    }

    private IEnumerator MonsterSpawn01()//RR
    {
       while(true)
       {
           for (int a = 0; a < MonsterSpawner.Length; a++)
           {
               
               GameObject instance = m_poolManager.Get(prefabs[0]);
               instance.transform.position = MonsterSpawner[a].transform.position;
               instance.transform.rotation = Quaternion.identity;
           }

           yield return new WaitForSeconds(2);
       }

    }
    private IEnumerator MonsterSpawn02()//GR
    {

        while (true)
        {
            int random = UnityEngine.Random.Range(0, 9);
                
            GameObject instance = m_poolManager.Get(prefabs[1]);
            instance.transform.position = MonsterSpawner[random].transform.position;
            instance.transform.rotation = Quaternion.identity;


            yield return new WaitForSeconds(3);
        }

    }
    private IEnumerator MonsterSpawn03()//Orc
    {

        while (true)
        {
            for (int a = 0; a < MonsterSpawner.Length; a++)
            {

                GameObject instance = m_poolManager.Get(prefabs[2]);
                instance.transform.position = MonsterSpawner[a].transform.position;
                instance.transform.rotation = Quaternion.identity;
            }

            yield return new WaitForSeconds(2);
        }

    }
    private IEnumerator MonsterSpawn04()//Golem
    {

        while (true)
        {

            int random = UnityEngine.Random.Range(0, 9);

            GameObject instance = m_poolManager.Get(prefabs[3]);
            instance.transform.position = MonsterSpawner[random].transform.position;
            instance.transform.rotation = Quaternion.identity;


            yield return new WaitForSeconds(3);
        }

    }
    private IEnumerator MonsterSpawn05()//EE
    {

        while (true)
        {
            for (int a = 0; a < MonsterSpawner.Length; a++)
            {

                GameObject instance = m_poolManager.Get(prefabs[4]);
                instance.transform.position = MonsterSpawner[a].transform.position;
                instance.transform.rotation = Quaternion.identity;
            }

            yield return new WaitForSeconds(2);
        }

    }
    private IEnumerator MonsterSpawn06()//Insect
    {

        while (true)
        {
            for (int a = 0; a < MonsterSpawner.Length; a++)
            {

                GameObject instance = m_poolManager.Get(prefabs[5]);
                instance.transform.position = MonsterSpawner[a].transform.position;
                instance.transform.rotation = Quaternion.identity;
            }

            yield return new WaitForSeconds(1);
        }

    }
    private IEnumerator MonsterSpawn07()//Partys
    {



        while (true)
        {
            GameObject instance01 = m_poolManager.Get(prefabs[6]);
            instance01.transform.position = MonsterSpawner[0].transform.position;
            instance01.transform.rotation = Quaternion.identity;
            GameObject instance02 = m_poolManager.Get(prefabs[7]);
            instance02.transform.position = MonsterSpawner[1].transform.position;
            instance02.transform.rotation = Quaternion.identity;
            GameObject instance03 = m_poolManager.Get(prefabs[6]);
            instance03.transform.position = MonsterSpawner[2].transform.position;
            instance03.transform.rotation = Quaternion.identity;
            GameObject instance04 = m_poolManager.Get(prefabs[7]);
            instance04.transform.position = MonsterSpawner[3].transform.position;
            instance04.transform.rotation = Quaternion.identity;
            GameObject instance05 = m_poolManager.Get(prefabs[6]);
            instance05.transform.position = MonsterSpawner[4].transform.position;
            instance05.transform.rotation = Quaternion.identity;
            GameObject instance06 = m_poolManager.Get(prefabs[7]);
            instance06.transform.position = MonsterSpawner[5].transform.position;
            instance06.transform.rotation = Quaternion.identity;
            GameObject instance07 = m_poolManager.Get(prefabs[6]);
            instance07.transform.position = MonsterSpawner[6].transform.position;
            instance07.transform.rotation = Quaternion.identity;
            GameObject instance08 = m_poolManager.Get(prefabs[7]);
            instance08.transform.position = MonsterSpawner[7].transform.position;
            instance08.transform.rotation = Quaternion.identity;




            yield return new WaitForSeconds(2);
        }

    }

    private void MonsterSpawn08()//MM
    {


      

            GameObject instance = m_poolManager.Get(prefabs[8]);
            instance.transform.position = MonsterSpawner[8].transform.position;
            instance.transform.rotation = Quaternion.identity;
       

        

    }

    private void MonsterSpawn09()//BOSS
    {




        GameObject instance = m_poolManager.Get(prefabs[9]);
        instance.transform.position = MonsterSpawner[8].transform.position;
        instance.transform.rotation = Quaternion.identity;




    }

    #endregion StageStart

    #region StageTimeCheck

    private void StageTimeCheck()
    {
        StartCoroutine(TimeChecker());
    }

    private IEnumerator TimeChecker()
    {
        yield return new WaitForSeconds(m_iTime);
        StageEndToNext();
        
    }



    #endregion StageTimeCheck

    private void StageEndToNext()
    {
        Debug.Log("다음으로");
        StopAllCoroutines();
        m_bIsGameOver = true;
        m_hpUI.gameObject.SetActive(false);
        m_timerUI.StageEnd();
        m_timerUI.gameObject.SetActive(false);
       // m_cookieUI.gameObject.SetActive(false);
        m_player.EndStage();
        GameProceedUI.SetActive(true);

    }

    private void StageEndToReplay()
    {
        Debug.Log("게임오버");
        StopAllCoroutines();
        m_bIsGameOver = true;
        m_hpUI.gameObject.SetActive(false);
        m_timerUI.StageEnd();
        m_timerUI.gameObject.SetActive(false);
        m_cookieUI.gameObject.SetActive(false);
        m_player.EndStage();
        GameOverUI.SetActive(true);
    }
}
