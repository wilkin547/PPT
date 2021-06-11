using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// this class is to select your move or your play
/// </summary>
public class SelectYourMove : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Objects);
    }

    //lets to desactive the objects
    private void Objects()
    {
        //the firs object is the player
        GameControllerPPT.controllerPPT.Actives_Object[0].tag = gameObject.tag;
        GameControllerPPT.controllerPPT.SetInGame();

        foreach (var item in GameControllerPPT.controllerPPT.Actives_Object)
        {
            item.SetActive(true);
        }
        foreach (var item in GameControllerPPT.controllerPPT.Desactive_Object)
        {
            item.SetActive(false);
            
        }
    }
}
