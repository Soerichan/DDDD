using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapRoomButton : MonoBehaviour
{
    private Button m_button;


   private MapGrid m_grid;

    public int x;
    public int y;

   // public GameObject m_shiny;

    public bool m_bEable;
    

    private void Start()
    {
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

    
}
