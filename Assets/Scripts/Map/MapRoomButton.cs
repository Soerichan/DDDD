using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapRoomButton : MonoBehaviour
{
    private Button m_button;
   // private MapManager m_mapManager;

   private MapGrid m_grid;

    public int x;
    public int y;

   // public GameObject m_shiny;

    public bool m_bEable;

   
    private GameObject m_mapUI;
  
    private StageManager m_stageManager;

    private void Start()
    {
        m_mapUI = GameObject.Find("MapUI");
        m_stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        //m_mapUI= GameObject.FindGameObjectWithTag("Map").gameObject.GetComponent<GameObject>();
        //m_mapUI = transform.parent.parent.parent.parent.GetComponent<GameObject>();
        //m_mapUI = GetComponentInParent<test>();
       // if (m_mapUI != null)
       // {
       //     Debug.Log("©юдиюл");
       // }
       // else
       // {
       //     Debug.Log("nono");
       // }
       
        m_button = GetComponent<Button>();
        m_grid = GameObject.Find("Grid").GetComponent<MapGrid>();
        m_bEable = true;
       // Instantiate(m_shiny, m_button.transform);
       // m_shiny.SetActive(true);
        this.transform.SetAsLastSibling();
       
    }

    public void ClickRoomButton()
    {
        //RoomButtonDisable();
        CallGrid();
        m_grid.m_iCleardStage++;
        
    }

    private void CallGrid()
    {
        m_grid.IsCliked = this;
        m_grid.NarrowDown();
        //m_grid.ShinyRoad();
    }

    public void RoomButtonDisable()
    {
        m_button.interactable = false;
        m_bEable = false;
        
    }
    public void StageStart()
    {
        // SceneManager.LoadScene("Scenes/GameScene");
        m_mapUI.SetActive(false);
        m_stageManager.StageStart();
        
    }

    public void ClickMapRoomButton01()
    {
        MapManager.NowRoom = RoomType.Room_RampageGuys;
    }
    public void ClickMapRoomButton02()
    {
        MapManager.NowRoom = RoomType.Room_Anvil;
    }
    public void ClickMapRoomButton03()
    {
        MapManager.NowRoom = RoomType.Room_HumanWave;
    }
    public void ClickMapRoomButton04()
    {
        MapManager.NowRoom = RoomType.Room_SturdyHunks;
    }
    public void ClickMapRoomButton05()
    {
        MapManager.NowRoom = RoomType.Room_Danger;
    }
    public void ClickMapRoomButton06()
    {
        MapManager.NowRoom = RoomType.Room_Cookie;
    }
    public void ClickMapRoomButton07()
    {
        MapManager.NowRoom = RoomType.Room_BOSS;
    }
}
