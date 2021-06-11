using UnityEngine;
using UnityEngine.UI;

public class SelecionDeJugada : MonoBehaviour
{
    private Button button;
    private SpriteRenderer sprite;
    void Start()
    {
        button = GetComponent<Button>();
        sprite = GetComponent<SpriteRenderer>();

        button.onClick.AddListener(seleccionar_Jugada);
    }

    private void seleccionar_Jugada()
    {
        foreach (var item in GameControllerPPT.controllerPPT.Actives_Object)
        {
            item.SetActive(true);
        }

        foreach (var item in GameControllerPPT.controllerPPT.Desactive_Object)
        {
            item.SetActive(false);
        }

        //transfiere los datos al player

        GameControllerPPT.controllerPPT.Player.tag = gameObject.tag;
        GameControllerPPT.controllerPPT.Player.GetComponent<SpriteRenderer>().sprite = sprite.sprite;

        //inicia el juego :D

        GameControllerPPT.controllerPPT.SetInGame();

    }
}
