using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] listPlayers;
    public GameObject bull;
    public Sprite[] backgrounds;
    public Vector3 startPosition;
    public Vector3 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < listPlayers.Length; i++)
        {
            PlayerInfo info = listPlayers[i].GetComponent<PlayerInfo>();
            if (i == 0 || i == 2)
            {
                info.zPosition = 100;
            }
            else
            {
                info.zPosition = 0;
            }
        }
        startPosition = listPlayers[0].transform.position;
        endPosition = listPlayers[1].transform.position;
        ChaseEnemy();
    }

    private void OnApplicationQuit()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // bull.transform.position = Vector3.Lerp(startPosition, endPosition, Time.time);
    }

    public void ButtonClick(int index)
    {
        GameObject obj = listPlayers[index];
        PlayerInfo info = obj.GetComponent<PlayerInfo>();
        info.movingUp = true;
        info.movingDown = false;

        GameObject nextObj = listPlayers[3 - index];
        PlayerInfo nextInfo = nextObj.GetComponent<PlayerInfo>();
        nextInfo.movingDown = true;
        nextInfo.movingUp = false;
    }

    public int FindNearest()
    {
        int nearest = 0;
        float minDistance = float.MaxValue;
        for (int i = 0; i < listPlayers.Length; i++)
        {
            float distance = Vector3.Distance(bull.transform.position, listPlayers[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = i;
            }
        }
        return nearest;
    }

    public void ChaseEnemy() {
        int nearest = FindNearest();
        Vector3 bullPos = bull.transform.position;
        Vector3 target = listPlayers[nearest].transform.position;
        Vector3 diff = new Vector3(target.x - bullPos.x, target.y - bullPos.y, target.z - bullPos.z);
        float random = Random.Range(2.0f, 3.0f);
        Vector3 realTarget = new Vector3(bullPos.x + random * diff.x, bullPos.y + random * diff.y, bullPos.z + random * diff.z);

        BullController controller = bull.GetComponent<BullController>();
        controller.RunTo(nearest, target, realTarget);
    }

    public bool CheckTarget(int index)
    {
        GameObject player = listPlayers[index];
        PlayerInfo info = player.GetComponent<PlayerInfo>();
        Debug.Log(index.ToString() + info.zPosition.ToString());
        if (info.zPosition > 50)
        {
            return false;
        }
        return false;
    }
}
