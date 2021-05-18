using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel(GameObject levelType)
    {
        GameObject ch =  Instantiate(levelType);
        GameManager.instance.SetLevelType(ch);
        ch.transform.position = Vector3.zero;
        GameManager.instance.isPlaying = true;
        GameManager.instance.StartPlaying();
        gameObject.SetActive(false);

    }
}
