using UnityEngine;


/// <summary>
/// esto le da la animacion de que le da la vuelta a la carta 
/// </summary><remarks>
/// hice esto por que me daba problemas para hacerlo en el mobimentPPT, ya que havia que tener un update al paralelo
/// </remarks>
public class AnimacionCartas : MonoBehaviour
{
    private RectTransform transform;
    private SpriteRenderer sprite;
    public SpriteRenderer Hijo;
    public bool play;

    void Start()
    {
        transform = GetComponent<RectTransform>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (!play) return; 
        if(transform.localEulerAngles.y <= 180)
        {
            transform.Rotate(GameControllerPPT.controllerPPT.VelozityRotation);
        }
        else
        {
            Volver_Al_EstadoInicial();
        }

        if (transform.localEulerAngles.y >= 90)
        {
            sprite.sortingLayerName = "Secundario";
            Hijo.sortingLayerName = "Principal";
        } 


    }

    public void Volver_Al_EstadoInicial()
    {

            transform.localEulerAngles = Vector2.zero;
            play = false;
            sprite.sortingLayerName = "Principal";
            Hijo.sortingLayerName = "Secundario";
    }
}
