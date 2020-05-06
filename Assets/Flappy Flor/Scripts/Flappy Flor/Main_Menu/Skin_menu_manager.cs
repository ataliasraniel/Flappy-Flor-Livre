using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin_menu_manager : MonoBehaviour
{
    private void Start() {
        Game_manager _gameManager = GameObject.Find("Game_manager").GetComponent<Game_manager>();
        _gameManager.SpawnaSkinsMenu();
    }
}
