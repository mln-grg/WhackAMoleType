using UnityEngine;

public class HoleStatus : MonoBehaviour
{
    private bool isCharacterVisible;
    public bool IscharacterVisible 
    { 
        get { return isCharacterVisible; }
        set { isCharacterVisible = value; }
    }

    public void onClick()
    {
        Debug.Log("hi");
        Debug.Log(isCharacterVisible);
    }
}
