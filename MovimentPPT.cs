using UnityEngine;
/// <summary>
/// clase utilizada para mover las cartas enemigas
/// </summary>
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AnimacionCartas))]



public class MovimentPPT : Moviment
{

    private AnimacionCartas animacion;

    protected override void Setvelocity()
    {
        rigidbody2D.velocity = GameControllerPPT.controllerPPT.SetVelocity();
    }


    protected override void Start()
    {
        base.Start();
        animacion = gameObject.GetComponent<AnimacionCartas>();
    }

    protected override void ReStar()
    {
        rectTransform.position = GameControllerPPT.controllerPPT.startPosicion.position;
        gameObject.SetActive(false);

        animacion.Volver_Al_EstadoInicial();
    }

    protected override void Update()
    {


        base.Update();
        if (GameControllerPPT.controllerPPT.GetBoolFail()) { gameObject.SetActive(false); return; }
        if (rectTransform.localPosition.x >= -GameControllerPPT.controllerPPT.Distacia && rectTransform.position.x <= GameControllerPPT.controllerPPT.Distacia)
        {

            if (Input.anyKeyDown)
            {

                switch (GameControllerPPT.controllerPPT.Player.tag)
                {
                    case "Papel":

                        if (CompareTag("Tijeras"))
                        {

                            GameControllerPPT.controllerPPT.GameOver();
                        }
                        else if (CompareTag("Piedra"))
                        {
                            animacion.play = true;
                            GameControllerPPT.controllerPPT.UpdateScore();
                        }

                        break;
                    case "Tijeras":

                        if (CompareTag("Piedra"))
                        {

                            GameControllerPPT.controllerPPT.GameOver();
                        }
                        else if (CompareTag("Papel"))
                        {
                            animacion.play = true;
                            GameControllerPPT.controllerPPT.UpdateScore();

                        }
                        break;
                    case "Piedra":

                        if (CompareTag("Papel"))
                        {

                            GameControllerPPT.controllerPPT.GameOver();
                        }
                        else if (CompareTag("Tijeras"))
                        {
                            animacion.play = true;
                            GameControllerPPT.controllerPPT.UpdateScore();
                        }
                        break;
                }

            }


        }
    }


}



