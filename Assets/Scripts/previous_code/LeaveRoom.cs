using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoom : MonoBehaviour
{
    public void OnClick_Leave() 
    {
        PManager.Instance.OnLeftRoom();
            
    }
}
