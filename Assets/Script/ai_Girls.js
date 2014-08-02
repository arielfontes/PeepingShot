#pragma strict

var wPoints:Transform[];
var agent:NavMeshAgent;

var assustada:boolean;

var position:int;
var nextPosition:int;

function Start () 
{
	assustada=false;
	nextPosition=0;
	agent = GetComponent(NavMeshAgent);
}
function Update () 
{
	Movimenta();
}
function Movimenta()
{
	if(wPoints!=null)
	{
		agent.destination = wPoints[nextPosition].position;
	}
}
function OnTriggerEnter(col:Collider)
{
	if(assustada==false&&col.transform.position==wPoints[nextPosition].position)
	{
		position = nextPosition;
		var r:int =Random.Range(0,5);
		yield WaitForSeconds (r);
		nextPosition +=1;
		if(nextPosition==wPoints.Length)
		{
			nextPosition=0;
		}
	}
}

