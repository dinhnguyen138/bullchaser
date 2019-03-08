using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerModifier : MonoBehaviour
{
    public Text zPos;
    public Image background;
    public Sprite []listBackground;
    private PlayerInfo playerInfo;
    [SerializeField] private float speed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInfo.movingUp)
        {
            if (playerInfo.zPosition < 100)
            {
                playerInfo.zPosition += speed * Time.deltaTime;
            }
            else
            {
                playerInfo.zPosition = 100;
                playerInfo.movingUp = false;
            }

        }

        if (playerInfo.movingDown)
        {
            if (playerInfo.zPosition > 0)
            {
                playerInfo.zPosition -= speed * Time.deltaTime;
            }
            else
            {
                playerInfo.zPosition = 0;
                playerInfo.movingDown = false;
            }

        }

        if (playerInfo.zPosition >= 50)
        {
            background.sprite = listBackground[0];
        }
        else
        {
            background.sprite = listBackground[1];
        }

        zPos.text = playerInfo.zPosition.ToString();
    }
}
