using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemySetter : MonoBehaviour
{
    [SerializeField] private GameObject[] Characters;
    [SerializeField] private float EnemyAlertDuration;
    private int currentEnemyIndex;

    [SerializeField] private Text EnemyAlert;
    private void Start()
    {
        resetEnemyStatus();
    }
    public void SetEnemy()
    {
        int index;
        index = Random.Range(0, Characters.Length);
        //Characters[index].tag = "Enemy";
        Characters[index].GetComponent<EnemyStatus>().isEnemy = true;
        currentEnemyIndex = index;
        EnemyAlert.text = Characters[index].name;
        EnemyAlert.color = getColor(Characters[index].name);
        StartCoroutine(HideEnemyAlert());
        GameManager.instance.IncreaseEnemyPool(Characters[index]);
    }

    IEnumerator HideEnemyAlert()
    {
        yield return new WaitForSeconds(EnemyAlertDuration);
        EnemyAlert.text = " ";
    }
    private Color getColor(string name)
    {
        if (name == "Red")
            return Color.red;
        else if (name == "Green")
            return Color.green;
        else if (name == "Yellow")
            return Color.yellow;
        else
            return Color.black;
    }
    public void SetNewEnemy()
    {
        //Characters[currentEnemyIndex].tag = "Player";
        Characters[currentEnemyIndex].GetComponent<EnemyStatus>().isEnemy = false;
        SetEnemy();
    }

    private void resetEnemyStatus()
    {
        foreach (var element in Characters)
            element.GetComponent<EnemyStatus>().isEnemy = false; 
    }
    private void OnApplicationQuit()
    {
        resetEnemyStatus();
    }

}
