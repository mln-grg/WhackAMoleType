using UnityEngine;

public class HoleStatus : MonoBehaviour
{
    private bool isHoleEmpty = true;
    private GameObject characterOnHole;
    public bool IsHoleEmpty 
    { 
        get { return isHoleEmpty; }
        set { isHoleEmpty = value; }
    }
    public GameObject CharacterOnHole
    {
        get {return characterOnHole; }
        set { characterOnHole = value; }
    }

    public void onClick()
    {
        if (!isHoleEmpty)
        {
            int value;
            value = characterOnHole.tag == "Enemy" ? 1 : -1;
            GameManager.instance.UpdateScore(value);
            characterOnHole.SetActive(false);
        }
    }
}
