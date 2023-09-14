using UnityEngine;
using UnityEngine.UI;

public class ExamplePlayerController : MonoBehaviour
{
	public Text valVolante;
	public Text valAcelerador;

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";


	private float inputHorizontal;
	private float inputVertical;


	void Update()
	{
		inputHorizontal = SimpleInput.GetAxis( horizontalAxis );
		inputVertical = SimpleInput.GetAxis( verticalAxis );
		valVolante.text= inputHorizontal*100+"";
		valAcelerador.text=inputVertical*10+"";
	}

}