using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapRoomButton : MonoBehaviour
{
    private Button m_button;


   private MapGrid m_grid;

    public int x;
    public int y;

    private void Start()
    {
        m_button = GetComponent<Button>();
        m_grid = GameObject.Find("Grid").GetComponent<MapGrid>();
    }

    public void ClickRoomButton()
    {
        //RoomButtonDisable();
        CallGrid();
        
    }

    private void CallGrid()
    {
        m_grid.IsCliked = this;
        m_grid.NarrowDown();
    }

    public void RoomButtonDisable()
    {
        m_button.interactable = false;
    }
}
