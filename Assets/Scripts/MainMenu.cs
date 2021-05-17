using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel(GameObject levelType)
    {
       GameObject ch =  Instantiate(levelType);
        ch.transform.position = Vector3.zero;
        GameManager.instance.isPlaying = true;
        gameObject.SetActive(false);

    }
}
