using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text HPText;
    public GameObject PlayerPrefab;
    private PlayerController PlayerCtrl;
    void Awake()
    {
        StartGame();
    }

    void Update()
    {
        HPText.text = "HP " + PlayerCtrl.HP + "/10";
    }
    private void StartGame()
    {
        PlayerCtrl = Instantiate(PlayerPrefab).GetComponent<PlayerController>();
    }
}
