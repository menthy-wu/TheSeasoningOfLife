using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PushPuzzle : MonoBehaviour
{
    // 0 = empty
    // 1 = upperright open
    // 2 = bottomright open
    // 3 = bottomleft open
    // 4 = upperleft open
    // 5 = upperright open with vines
    // 6 = bottomright open with vines
    // 7 = bottomleft open with vines
    // 8 = upperleft open with vines
    public GameObject Puzzle1SummerObjectActivated;
    public GameObject Puzzle1WinterObjectActivated;
    public GameObject Puzzle1SummerObjectDeactivated;
    public GameObject Puzzle1WinterObjectDeactivated;

    public GameObject Puzzle2Board;
    public GameObject Puzzle2Object;

    [SerializeField]
    private BackPack Backpack;
    
    public int[,] Puzzle1Map = new int[,] {
        {8, 1},
        {0, 7},
        {5, 3},
    };

    public int[,] Puzzle2Map = new int[,] {
        {0, 2, 4},
        {5, 0, 8},
    };

    public Dictionary<string, Vector2> Puzzle1Settings = new Dictionary<string, Vector2>()
    {
        {"RayGridPosition", new Vector2(-1, 1)},
        {"RayGridWinPosition", new Vector2(2, 0)},
        {"RayDirection", Vector2.right},
        {"RayWinDirection", Vector2.right},
        {"EndGameConstant", new Vector2(-3.75f, 0)},
        {"EndOffset", new Vector2(-12, 1)},
        {"Overflow", new Vector2(-999, 0)},
    };

    public Dictionary<string, Vector2> Puzzle2Settings = new Dictionary<string, Vector2>()
    {
        {"RayGridPosition", new Vector2(3, 1)},
        {"RayGridWinPosition", new Vector2(-1, 0)},
        {"RayDirection", Vector2.left},
        {"RayWinDirection", Vector2.left},
        {"EndGameConstant", new Vector2(3f, 0)},
        {"EndOffset", new Vector2(-12, 1)},
        {"Overflow", new Vector2(-999, 0)},
    };

    public Dictionary<string, int[,]> MapLookUp = new Dictionary<string, int[,]>();
    public Dictionary<string, Dictionary<string, Vector2>> RayLookUp = new Dictionary<string, Dictionary<string, Vector2>>();

    public List<LineRenderer> _RayObjects = new List<LineRenderer>();
    private Dictionary<string, LineRenderer> RayObjects = new Dictionary<string, LineRenderer>();

    // private DirectionTable

    // Start is called before the first frame update
    void Start()
    {
        MapLookUp.Add("Puzzle1", Puzzle1Map);
        RayLookUp.Add("Puzzle1", Puzzle1Settings);
        RayObjects.Add("Puzzle1", _RayObjects[0]);

        MapLookUp.Add("Puzzle2", Puzzle2Map);
        RayLookUp.Add("Puzzle2", Puzzle2Settings);
        RayObjects.Add("Puzzle2", _RayObjects[1]);
    }

    public void RecalculateRayPosition(string PuzzleName, int season) {
        bool RayTravel = true;
        int Rays = 1;

        Vector2 direction = RayLookUp[PuzzleName]["RayDirection"];
        Vector2 CurrentPosition = RayLookUp[PuzzleName]["RayGridPosition"] + direction;
        Vector3 OldPosition = RayObjects[PuzzleName].GetPosition(Rays);

        RayObjects[PuzzleName].SetVertexCount(2);

        
        while(RayTravel) {
            // draw lines
            Rays++;
            RayObjects[PuzzleName].SetVertexCount(Rays+1);
            if (PuzzleName == "Puzzle1") {
                RayObjects[PuzzleName].SetPosition(Rays, OldPosition + new Vector3(direction.y * 1.25f, direction.x * -1.25f, 0)); //set the position of the point (or vertex) that is at the n index
            } else {
                RayObjects[PuzzleName].SetPosition(Rays, OldPosition + new Vector3(direction.x * 1.25f, direction.y * 1.25f, 0)); //set the position of the point (or vertex) that is at the n index
            }
            OldPosition = RayObjects[PuzzleName].GetPosition(Rays);
            // Debug.Log(CurrentPosition);

            int TriangleType = MapLookUp[PuzzleName][ConvertToInt32(CurrentPosition.y), ConvertToInt32(CurrentPosition.x)];
            // check for grass
            if (TriangleType > 4) break;

            if(direction == Vector2.up) 
                switch(TriangleType) {
                    case 1:
                        RayTravel = false;
                        break;
                    case 2:
                        direction = Vector2.right;
                        break;
                    case 3:
                        direction = Vector2.left;
                        break;
                    case 4:
                        RayTravel = false;
                        break;
                    
                }
            else if(direction == Vector2.right) {
                switch(TriangleType) {
                    case 1:
                        RayTravel = false;
                        break;
                    case 2:
                        RayTravel = false;
                        break;
                    case 3:
                        direction = Vector2.down;
                        break;
                    case 4:
                        direction = Vector2.up;
                        break;
                    
                }
            }
                
            else if(direction == Vector2.down) 
                switch(TriangleType) {
                    case 1:
                        direction = Vector2.right;
                        break;
                    case 2:
                        RayTravel = false;
                        break;
                    case 3:
                        RayTravel = false;
                        break;
                    case 4:
                        direction = Vector2.left;
                        break;
                    
                }
            else if (direction == Vector2.left) {
                switch(TriangleType) {
                    case 1:
                        direction = Vector2.up;
                        break;
                    case 2:
                        direction = Vector2.down;
                        break;
                    case 3:
                        RayTravel = false;
                        break;
                    case 4:
                        RayTravel = false;
                        break;
                }
            }

            CurrentPosition += direction;
            RayTravel = RayTravel &&
              CurrentPosition.x < MapLookUp[PuzzleName].GetLength(1) && 
              CurrentPosition.x >= 0 && 
              CurrentPosition.y < MapLookUp[PuzzleName].GetLength(0) && 
              CurrentPosition.y >= 0;
            
        }

        if (CurrentPosition == RayLookUp[PuzzleName]["RayGridWinPosition"] && direction == RayLookUp[PuzzleName]["RayWinDirection"] && season == 0) {
            // win
            Rays++;
            RayObjects[PuzzleName].SetVertexCount(Rays+1);
            RayObjects[PuzzleName].SetPosition(Rays, OldPosition + new Vector3(direction.y * RayLookUp[PuzzleName]["EndGameConstant"].y, direction.x * RayLookUp[PuzzleName]["EndGameConstant"].x, 0)); //set the position of the point (or vertex) that is at the n index
            if (PuzzleName == "Puzzle1" && Puzzle1SummerObjectActivated.activeSelf) {
                Puzzle1SummerObjectActivated.SetActive(false);
                Puzzle1WinterObjectActivated.SetActive(false);
                Puzzle1SummerObjectDeactivated.SetActive(true);
                Puzzle1WinterObjectDeactivated.SetActive(true);
                Backpack.StoreItem("Axe");

            }
            else if (PuzzleName == "Puzzle2" && Puzzle2Board.activeSelf) {
                RayObjects[PuzzleName].SetPosition(Rays, OldPosition + new Vector3(direction.x * RayLookUp[PuzzleName]["EndGameConstant"].x, direction.y * RayLookUp[PuzzleName]["EndGameConstant"].y, 0)); //set the position of the point (or vertex) that is at the n index
                Puzzle2Board.SetActive(false);
                // Puzzle2WinterObjectActivated.SetActive(false);
                Backpack.StoreItem("Wood");
            }
        }
    }

    private int ConvertToInt32(float f) {
        return (int)Mathf.Round(f);
    }
}
