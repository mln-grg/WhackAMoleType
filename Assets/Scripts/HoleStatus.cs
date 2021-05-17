using UnityEngine;

public class HoleStatus : MonoBehaviour
{
    private bool isCharacterVisible = false;
    private GameObject characterOnHole;
    public GameObject CharacterOnHole
    {
        get {return characterOnHole; }
        set { characterOnHole = value; }
    }
    public bool IscharacterVisible 
    { 
        get { return isCharacterVisible; }
        set { isCharacterVisible = value; }
    }

    public void onClick()
    {
        if (isCharacterVisible)
        {   
            characterOnHole.SetActive(false);
        }
    }
}
