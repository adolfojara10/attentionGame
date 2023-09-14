using UnityEngine;
using UnityEngine.UI;
using System;
public class Volante : MonoBehaviour
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
			
			int velAux=(int)(inputVertical*10);
			if (velAux>0){
				velAux=1;
			}else if(velAux<0){
				velAux=2;
			}
			else if(velAux==0){
				velAux=0;
			}

			int graAux=(int)(inputHorizontal*100);
			if(graAux==0){
				graAux=90;
			} else if(graAux>0){
				//graAux=(int)((graAux+90*90))/110;
				graAux = (((graAux - 0) * (110 - 90)) / (90 - 0)) + 90;
				//NewValue = (((OldValue - OldMin) * (NewMax - NewMin)) / (OldMax - OldMin)) + NewMin


			}else if(graAux<0){
				//graAux=Math.Abs(graAux);
				graAux = (((graAux - 0) * (70 - 90)) / (-90 - 0)) + 90;
				//graAux=(int)((graAux+90)*90)/70;
			}
            //valVolante.text= inputHorizontal*100+"";
            //valAcelerador.text=inputVertical*10+"";
            string envi="G:"+graAux+"-V:"+velAux;
			print(envi);
	}

}