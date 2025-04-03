using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    public bool canGoUp;
    public bool canGoDown;
    public bool canGoLeft;
    public bool canGoRight;

    public List<Vector2> GetAllowedDirections()
    {
        List<Vector2> directions = new List<Vector2>();
        if (canGoUp) directions.Add(Vector2.up);
        if (canGoDown) directions.Add(Vector2.down);
        if (canGoLeft) directions.Add(Vector2.left);
        if (canGoRight) directions.Add(Vector2.right);
        return directions;
    }
}
