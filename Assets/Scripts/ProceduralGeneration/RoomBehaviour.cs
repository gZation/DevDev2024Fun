using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    // 0 - front 1 - back 2 - right 3 - left
    public GameObject[] walls;
    public GameObject[] doors;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="status">Status of each door</param>
    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }
    }
}

public enum orientation
{
    Front = 0,
    Back = 1,
    Right = 2,
    Left = 3
}
