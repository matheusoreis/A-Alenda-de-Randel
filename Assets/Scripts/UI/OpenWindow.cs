using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWindow : MonoBehaviour {

    //Definição do painel/imagem para ser aberta
    public GameObject Panel;

    public void OpenPanel() {

        if (Panel != null) {

            bool isActive = Panel.activeSelf;

            Panel.SetActive(!isActive);
        }
    }
}

