using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TriangleMover : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 0.07f;
    [SerializeField]
    private TriangleMover LinkedTriangle;
    [SerializeField]
    private Vector2 TriangleMapPosition;
    private float BlockSize = 1.25f;
    private bool IsMoving = false;
    public string Map;
    public  Vector2 Target;
    private Vector3 OldPosition;
    

    public void Start() {
        Target = transform.position;
    }
    
    public bool MoveTo(Vector2 direction, int[,] Map) {
        if (!IsMoving && CanMove(direction, Map)) {
            Target -= direction * BlockSize;
            LinkedTriangle.Target = Target;
            Map[ConvertToInt32(TriangleMapPosition.y - direction.y), ConvertToInt32(TriangleMapPosition.x - direction.x)] = Map[ConvertToInt32(TriangleMapPosition.y), ConvertToInt32(TriangleMapPosition.x)];
            Map[ConvertToInt32(TriangleMapPosition.y), ConvertToInt32(TriangleMapPosition.x)] = 0;

            // Debug.Log(Map[0,0] + ", " + Map[0,1] + ", " + Map[0,2] + "    " + Map[1,0] + " " + Map[1,1] + ", " + Map[1,2] + " ");

            TriangleMapPosition = new Vector2(Mathf.Round(TriangleMapPosition.x - direction.x), Mathf.Round(TriangleMapPosition.y - direction.y));
            return true;
        }
        return false;
    }   

    public bool CanMove(Vector2 direction, int[,] Map) {
        int x = ConvertToInt32(TriangleMapPosition.x - direction.x);
        int y = ConvertToInt32(TriangleMapPosition.y - direction.y);

        return (x < Map.GetLength(1) && x >= 0 && y < Map.GetLength(0) && y >= 0 && Map[y, x] == 0);
    }

    private int ConvertToInt32(float f) {
        return (int)Mathf.Round(f);
    }

    void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, Target, MoveSpeed);
        IsMoving = OldPosition != transform.position;
        LinkedTriangle.transform.position = OldPosition = transform.position;
    }
}
