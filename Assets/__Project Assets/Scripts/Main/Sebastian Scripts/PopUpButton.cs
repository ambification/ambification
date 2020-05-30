using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour
{
    public GameObject popUpPanel;
    
    public void ClosePopUP()
    {
        //popUpPanel.SetActive(false);
        //or an animation
        Debug.Log("Poup Closed");
    }
}
