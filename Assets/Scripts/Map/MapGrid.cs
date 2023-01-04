using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [SerializeField]
    private MapRoomButton MapButton01;
    [SerializeField]
    private MapRoomButton MapButton02;
    [SerializeField]
    private MapRoomButton MapButton03;
    [SerializeField]
    private MapRoomButton MapButton04;
    [SerializeField]
    private MapRoomButton MapButton05;
    [SerializeField]
    private MapRoomButton MapButton06;
    [SerializeField]
    private MapRoomButton MapButton07;

    [SerializeField]
    private MapRoad Road01;
    [SerializeField]
    private MapRoad Road02;
    [SerializeField]
    private MapRoad Road03;
    [SerializeField]
    private MapRoad Road04;
    [SerializeField]
    private MapRoad Road05;

    [SerializeField]
    private GameObject ShinyEffect;

    public MapMaker mapMaker;

    [SerializeField]
    private Vector2Int gridSize;
    [SerializeField]
    private float placeSize;

    public MapRoomButton[,] MapRoomButtonArray = new MapRoomButton[5, 10];
    public GameObject[,] ShinyEffecrtArray= new GameObject[5, 10];
    public MapRoomButton IsCliked;

    public int m_iCleardStage;

    private void Start()
    {
        m_iCleardStage = 0;

        for (int y = 0; y < gridSize.y; y++)
        {
            if (y == gridSize.y - 1)
            {

                if (mapMaker.MapArray[0, y - 1] == 1)
                {
                    MapRoad maproad = Instantiate(Road04, transform);
                    maproad.transform.localPosition = new Vector2((0 + 1.4f) * placeSize, (y + 0.05f) * placeSize);
                }

                if (mapMaker.MapArray[gridSize.x-1, y - 1] == 1)
                {
                    MapRoad maproad = Instantiate(Road05, transform);
                    maproad.transform.localPosition = new Vector2((4 -0.4f) * placeSize, (y + 0.05f) * placeSize);
                }

            }

            for (int x = 0; x < gridSize.x; x++)
            {
                

                if (y > 0)
                {
                    if (mapMaker.MapArray[x, y - 1] == 1 && mapMaker.MapArray[x, y] == 1)
                    {
                        MapRoad maproad = Instantiate(Road01, transform);
                        maproad.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y+0.05f) * placeSize);
                    }

                    if (x > 1)
                    {

                        if (mapMaker.MapArray[x - 1, y - 1] == 1 && mapMaker.MapArray[x, y] == 1)
                        {
                            MapRoad maproad = Instantiate(Road02, transform);
                            maproad.transform.localPosition = new Vector2((x) * placeSize, (y + 0.05f) * placeSize);
                        }
                    }
                    else if(x==0)
                    {
                        if (mapMaker.MapArray[0, y - 1] == 1 && mapMaker.MapArray[1, y] == 1)
                        {
                            MapRoad maproad = Instantiate(Road02, transform);
                            maproad.transform.localPosition = new Vector2((x+1f) * placeSize, (y + 0.05f) * placeSize);
                        }
                    }

                    if (x < gridSize.x - 1)
                    {
                        if (mapMaker.MapArray[x + 1, y - 1] == 1 && mapMaker.MapArray[x, y] == 1)
                        {
                            MapRoad maproad = Instantiate(Road03, transform);
                            maproad.transform.localPosition = new Vector2((x+1f) * placeSize, (y + 0.05f) * placeSize);
                        }
                    }
                    else if(x== gridSize.x - 1)
                    {

                        if (mapMaker.MapArray[gridSize.x - 1, y - 1] == 1 && mapMaker.MapArray[gridSize.x - 1, y] == 1)
                        {
                            MapRoad maproad = Instantiate(Road03, transform);
                            maproad.transform.localPosition = new Vector2((x) * placeSize, (y + 0.05f) * placeSize);
                        }
                    }

                }
            }
        }


        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                if(0==mapMaker.MapArray[x,y])
                {
                    continue;
                }

              

                if (x==2&&y==9)
                {
                    MapRoomButton buttonPlace = Instantiate(MapButton07, transform);
                    buttonPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                    buttonPlace.x = x;
                    buttonPlace.y = y;
                    MapRoomButtonArray[2, 9] = buttonPlace;

                    GameObject shinyPlace = Instantiate(ShinyEffect, transform);
                    shinyPlace.transform.localPosition= new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                    ShinyEffecrtArray[2, 9] = shinyPlace;
                    shinyPlace.SetActive(false);

                    continue;
                }


                int randomRoom = UnityEngine.Random.Range(1, 7);

                switch (randomRoom)
                {
                    case 1:
                        {
                            MapRoomButton buttonPlace = Instantiate(MapButton01, transform);
                            buttonPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            buttonPlace.x = x;
                            buttonPlace.y = y;
                            MapRoomButtonArray[x, y] = buttonPlace;

                            GameObject shinyPlace = Instantiate(ShinyEffect, transform);
                            shinyPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            ShinyEffecrtArray[x, y] = shinyPlace;
                            shinyPlace.SetActive(false);

                            break;
                        }
                    case 2:
                        {
                            MapRoomButton buttonPlace = Instantiate(MapButton02, transform);
                            buttonPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            buttonPlace.x = x;
                            buttonPlace.y = y;
                            MapRoomButtonArray[x, y] = buttonPlace;

                            GameObject shinyPlace = Instantiate(ShinyEffect, transform);
                            shinyPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            ShinyEffecrtArray[x, y] = shinyPlace;
                            shinyPlace.SetActive(false);

                            break;
                        }
                    case 3:
                        {
                            MapRoomButton buttonPlace = Instantiate(MapButton03, transform);
                            buttonPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            buttonPlace.x = x;
                            buttonPlace.y = y;
                            MapRoomButtonArray[x, y] = buttonPlace;

                            GameObject shinyPlace = Instantiate(ShinyEffect, transform);
                            shinyPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            ShinyEffecrtArray[x, y] = shinyPlace;
                            shinyPlace.SetActive(false);

                            break;
                        }
                
                    case 4:
                        {
                            MapRoomButton buttonPlace = Instantiate(MapButton04, transform);
                            buttonPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            buttonPlace.x = x;
                            buttonPlace.y = y;
                            MapRoomButtonArray[x, y] = buttonPlace;

                            GameObject shinyPlace = Instantiate(ShinyEffect, transform);
                            shinyPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            ShinyEffecrtArray[x, y] = shinyPlace;
                            shinyPlace.SetActive(false);

                            break;
                        }
                    case 5:
                        {
                            MapRoomButton buttonPlace = Instantiate(MapButton05, transform);
                            buttonPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            buttonPlace.x = x;
                            buttonPlace.y = y;
                            MapRoomButtonArray[x, y] = buttonPlace;

                            GameObject shinyPlace = Instantiate(ShinyEffect, transform);
                            shinyPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            ShinyEffecrtArray[x, y] = shinyPlace;
                            shinyPlace.SetActive(false);

                            break;
                        }
                    case 6:
                        {
                            MapRoomButton buttonPlace = Instantiate(MapButton06, transform);
                            buttonPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            buttonPlace.x = x;
                            buttonPlace.y = y;
                            MapRoomButtonArray[x, y] = buttonPlace;

                            GameObject shinyPlace = Instantiate(ShinyEffect, transform);
                            shinyPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                            ShinyEffecrtArray[x, y] = shinyPlace;
                            shinyPlace.SetActive(false);

                            break;
                        }
                    default:
                        continue;
                }



                
                //  mapMaker.
                //  MapRoomButton buttonPlace = Instantiate(MapButton, transform);
                //buttonPlace.transform.localPosition = new Vector2((x + 0.5f) * placeSize,(y + 0.5f) * placeSize);
            }
        }
        ShinyEffecrtArray[1, 0].SetActive(true);
        ShinyEffecrtArray[2, 0].SetActive(true);
        ShinyEffecrtArray[3, 0].SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                var position = new Vector2((x + 0.5f) * placeSize, (y + 0.5f) * placeSize);
                Gizmos.DrawWireCube(position, new Vector2(placeSize, placeSize));
            }
        }
    }

    public void NarrowDown()
    {
        int Killx = IsCliked.x;
        int Killy = IsCliked.y;

        if(Killy==gridSize.y)
        {

        }

        for(int y = 0; y < gridSize.y; y++)
        {
            for(int x = 0; x < gridSize.x; x++)
            {
                if (y == Killy)
                {
                    if (MapRoomButtonArray[x, y] != null)
                    {
                        MapRoomButtonArray[x, y].RoomButtonDisable();
                        ShinyEffecrtArray[x,y].SetActive(false);
                    }
                }

           
                if (y == Killy+1)
                {
                   if(!(x>=Killx-1&&x<=Killx+1))
                    {
                        if (MapRoomButtonArray[x, y] != null)
                        {
                            MapRoomButtonArray[x, y].RoomButtonDisable();
                            ShinyEffecrtArray[x, y].SetActive(false);
                        }
                    }
                   else
                    {
                        if (MapRoomButtonArray[x, y] != null)
                        {
                            
                            ShinyEffecrtArray[x, y].SetActive(true);
                        }
                    }
                }

                
                
            }
        }
    }





}
