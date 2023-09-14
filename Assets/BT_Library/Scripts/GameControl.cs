using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update

    public BtAra btAraS;
    public Button [] buttons;
    public Sprite [] Images;
    public GameObject fondo;
    public Sprite [] fondos;  
    public Dropdown fondos_Dropdown;
    public GameObject [] Select;
    
    public GameObject padreSelect;
    GameObject [] Selected=new GameObject[80];

    bool [] selectBtn=new bool[80];
    public GameObject BtnAcep;
    public GameObject BtnClear;

    public GameObject BtnAcepEst;
    public GameObject BtnClearEst;
    public GameObject BtnIni;
    public GameObject BtnFin;
    public GameObject BtnObs;
    bool auxEst=false;

    string iniM="";
    int iniId=0;
    bool iniB=false;
    string finM="";
    int finID=16;
    bool finB=false;
    string ObsM="";
    bool ObsB=false;
    bool ObsBAux=true;
    int ObsIdAnt=16;
    bool [] auxObs = new bool[80];
    string [] auxNom=new string[80];
    public string ms1 = "";
    public string ms2 = "";

    public Sprite img;
    bool gameI=false;
    void Start()
    {
        string [] aNom={"A","B","C","D","E","F","G","H","I","J"};
        for (int i = 0; i < 80; i++){
            auxObs[i]=false;
        }
        int auxContV=0;
        foreach (string i in aNom) {
            for(int j=1; j<9; j++){
            auxNom[auxContV]=i+j.ToString();
            auxContV=auxContV+1;
     
            }
        }
        
        for(int s=0; s<padreSelect.transform.childCount;s++){
            //Debug.Log(padreSelect.transform.GetChild(s).gameObject.name);
            GameObject child = padreSelect.transform.GetChild(s).GetChild(0).gameObject;
            Selected[s]=child;  
            //Debug.Log(Selected[s].name);        

        }
       

        img = Images[1];
        btAraS = FindObjectOfType<BtAra>();
    }

    public void BtnTab(int id){      
        if (iniB){
            buttons[id].GetComponent<Image>().sprite = img;
            iniB=false;
            iniId=id;
            iniM=auxNom[id];
        }else{

        }
        if(finB){
            buttons[id].GetComponent<Image>().sprite = img;
            finB=false;
            finID=id;
            finM=auxNom[id];
        }else{

        }
        if(ObsB){   	    
            if(ObsIdAnt!=id || ObsBAux){
                buttons[id].GetComponent<Image>().sprite = img;
                ObsBAux=false;
                auxObs[id]=true;
            }else{
                buttons[id].GetComponent<Image>().sprite = Images[0];
                ObsBAux=true;
                auxObs[id]=false;
            }
            ObsIdAnt=id;
            //ObsB=false;
        }
        
        //Debug.Log(selectBtn[id]);
        //Debug.Log(auxEst);

        if(gameI){
        if(!selectBtn[id] && auxEst){ 
            Selected[id].SetActive(true); 
            selectBtn[id]=true; 
            ms2= ms2 + auxNom[id]+" ";
            }
        else{
            Selected[id].SetActive(false);
            selectBtn[id]=false;
            }

        }
    }

   public void FondoChanged()
    {
       Sprite fondoSelect = fondos[fondos_Dropdown.value];
        fondo.GetComponent<Image>().sprite = fondoSelect;

    }
   
    public void Ini(){
        img=Images[1];
        iniB=true;
        finB=false;
        ObsB=false;
        buttons[iniId].GetComponent<Image>().sprite =  Images[0];
    }

    public void Fin(){
        img=Images[2];
        iniB=false;
        finB=true;
        ObsB=false;
        buttons[finID].GetComponent<Image>().sprite =  Images[0];
    }

    public void Obs(){
        img=Images[3];
        iniB=false;
        finB=false;
        ObsB=true;

    }
    public void clear(){
        for(int i=0;i<buttons.Length;i++){
            buttons[i].GetComponent<Image>().sprite = Images[0];
        }
        ms1="";
    }

    public void clearG(){
        for(int i=0;i<Selected.Length;i++){
           Selected[i].SetActive(false);
        }
        ms2="";
    }


    public void enviar(){
        //print(iniM);
        //print(finM);
        for (int i=0;i<auxObs.Length;i++){
                if(auxObs[i]){
                    ObsM=ObsM+auxNom[i]+"O ";
            }
        }
        ms1=iniM+"I "+finM+"F "+ObsM;
       // print(ms1);
        btAraS.enviarSim(ms1);

    auxEst=true;
    iniB=false;
    finB=false;
    ObsB=false;
    BtnAcepEst.SetActive(true);
    BtnClearEst.SetActive(true);
    BtnAcep.SetActive(false);
    BtnClear.SetActive(false);
    BtnIni.SetActive(false);
    BtnFin.SetActive(false);
    BtnObs.SetActive(false);
    gameI=true;
        //print(ObsM);
    }

    public void enviarEst(){
        print(ms2);
        btAraS.enviarSim(ms1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
