using UnityEngine;

/// <summary>
/// el gameController del nivel ; piedra papel o tijeras
/// </summary>

public class GameControllerPPT : gameControllerPadre
{
    public static GameControllerPPT controllerPPT;

    private float CurrentTime = 0;
    [SerializeField]
    [Tooltip ("time that we have to wait to create a naiper")]
    [Range(0,10)]
    private float timeWait;
    private bool InGame;
    /// <summary>
    /// the which the object return back 
    /// </summary>
    public RectTransform startPosicion;
    /// <summary>
    /// distancia a la que tiene que estar aliniada con el player para funcionar 
    /// </summary>
    
    public float Distacia;

    /// <summary>
    /// velozidad a la que rotara la carta 
    /// </summary>
    public Vector2 VelozityRotation;
    public GameObject Player;
    /// <summary>
    /// the objects that i will actives, in the class "SelectYourMove"
    /// </summary>
    [Tooltip("los objetos que voy a activar cuando pulse")]
    public GameObject[] Actives_Object;
    /// <summary>
    /// the objects than i will desactive, in the class "SelectYourMove"
    /// </summary>
    [Tooltip("the objects than i will desactive")]
    public GameObject[] Desactive_Object;
    

    private void Start()
    {
        GameControllerPPT.controllerPPT = this;
            
        Player = controllerPPT.Actives_Object[0];
    }
    protected override void Update()
    {
        base.Update();
        //if the game no start , do not nothing
        if (!InGame) return;

        CurrentTime += Time.deltaTime;
        if(CurrentTime >= timeWait)
        {
            CurrentTime = 0;
            ActiveCard();
        }
    }

    /// <summary>
    /// active the card to save some of recurse
    /// </summary>
    private void ActiveCard()
    {
        int Ramdom = Random.Range(0, objetos.Length - 1);

        //ramdom can be a active gameObject so i will to check is the gameObject is active
        //is it is active change the ramdom
        if (objetos[Ramdom].activeSelf == false)
        {
            objetos[Ramdom].SetActive(true);
        }
        else
        {
            while(objetos[Ramdom].activeSelf == true)
            {
                Ramdom = Random.Range(0, objetos.Length - 1);
            }
            objetos[Ramdom].SetActive(true);
        }

        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>devuelve si estas jugando </returns>
    public bool GetInGame()
    {
        return InGame;
    }
    /// <summary>
    /// set the game has started
    /// </summary>
    public void SetInGame()
    {
        InGame = true;
    }
    public override void GameOver()
    {
        base.GameOver();
        InGame = false;
    }
    
}
