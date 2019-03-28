using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNamePlate : MonoBehaviour
{
    [SerializeField]
    private Text usernameText;

    [SerializeField]
    private Player player;

    // Update is called once per frame
    void Update()
    {
        usernameText.text = player.username;
    }
}
