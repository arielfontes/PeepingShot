#pragma strict
/*private var mov:animacoes;
var temperaturaLocal:float;
var condicaoClimatica:String;
var cam:Camera;
private var temperaturaCorporal:float;
private var tempo:float;
private var tempoClima:float;
private var temperaturaAmbiente:float;
private var comecoClima:boolean;

function Start () {
	temperaturaCorporal = 36.8;
	//o inicio da temperaturaLocal ira variar com a condicaoClimatica inicial
}

function Update () {
	if(condicaoClimatica == "Nevando"){
		Clima(4,9,60,50,55,0.1,0.2);
		//andar,correr,tempo1,tempo2,visaoCam,tempCorp,tempLocal
		//tempo1 --- qtd de tempo que leva para a tempCorporal cair em segundos
		//tempo2 --- qtd de tempo que leva para a tempAmbiente cair em segundos
		//dificuldade em andar,temperatura cai
	}else
	if(condicaoClimatica == "Chovendo"){
		Clima(7,12,50,40,55,0.1,0.2);
		//dificuldade em enxergar,acender fogo,derrapar ao correr?
	}else
	if(condicaoClimatica == "Ventando"){
		//sem ideia
	}else
	if(condicaoClimatica == "Ensolarado"){
		Clima(7,12,50,40,100,0.2,0.3);
		//perde stamina mais rapidamente,aumenta temperatura
	}else
	if(condicaoClimatica == "Nublado"){
		//Tempo Ideal?
	}else
	if(condicaoClimatica == "Tempestade"){
		//dificuldade em enxergar,acender fogo,diminui temperatura
		//chance de ser atingido por raio?
	}else
	if(condicaoClimatica == "Nevasca"){
		Clima(2,7,50,40,40,0.3,0.4);
		//dificuldade em andar,temperatura cai mais rapido,dificuldade em enxergar
	}
	if(temperaturaCorporal >= 38){
		//Hipertermia,fadiga aumenta,stamina diminui
	}else
	if(temperaturaCorporal >= 33 && temperaturaCorporal <= 35){
		//Hipotermia - Leve
	}else
	if(temperaturaCorporal >= 30 && temperaturaCorporal < 33){
		//Hipotermia - moderada
	}else
	if(temperaturaCorporal < 30){
		//Hipotermia - Grave
	}
}
function Clima(andar:float,correr:float,tempo1:float,tempo2:float,
			   visaoCam:uint,tCorp:float,tLocal:uint){
		tempo = Time.time;
		mov.walkSpeed = andar;
		mov.runSpeed = correr;
		if(comecoClima == false){
			tempoClima = tempo + tempo1;
			temperaturaAmbiente = tempo + tempo2;
			cam.farClipPlane = visaoCam;
			comecoClima = true;
		}
		if(tempoClima <= tempo){
			temperaturaCorporal -= tCorp;
			comecoClima = false;
		}
		if(temperaturaAmbiente >= tempo){
			temperaturaLocal -= tLocal;
		}
}
*/