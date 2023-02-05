using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBeetAnimation : MonoBehaviour
{
    public Sprite peelDown;
    public Sprite peelUp;
    public Sprite knifeUp;
    public Sprite knifeDown;

    public GameObject player;
    public SpriteRenderer playerSprite;


    // Start is called before the first frame update
    void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerSprite.sprite = peelUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerSprite.sprite = knifeDown;
        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            playerSprite.sprite = knifeUp;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerSprite.sprite = peelDown;
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            playerSprite.sprite = peelUp;
        }
    }
}
