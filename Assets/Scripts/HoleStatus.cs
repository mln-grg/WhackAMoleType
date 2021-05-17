using UnityEngine;

public class HoleStatus : MonoBehaviour
{
    public bool isHoleEmpty = true;
    private GameObject characterOnHole;
    public GameObject CharacterOnHole
    {
        get {return characterOnHole; }
        set { characterOnHole = value; }
    }

    private void Update()
    {
        if (!GameManager.instance.isPlaying)
            return;
        if (characterOnHole == null)
            isHoleEmpty = true;
    }
    public void onClick()
    {
        if (!isHoleEmpty)
        {
            int value;
            value = characterOnHole.tag == "Enemy" ? 1 : -1;
            GameManager.instance.UpdateScore(value);
            characterOnHole.SetActive(false);
            isHoleEmpty = true;
        }
    }
}
