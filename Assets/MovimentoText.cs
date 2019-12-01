using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoText : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text_comp;
    private GameController gameController;
    private string text;
    // Start is called before the first fr1ame update
    void Start()
    {
        text_comp = GetComponent<TMPro.TextMeshProUGUI>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        text = string.Format("Movimentos {0}/6", gameController.number_of_plays);
        text_comp.SetText(text);
    }
}
