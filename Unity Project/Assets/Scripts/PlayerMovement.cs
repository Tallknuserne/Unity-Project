using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	
	/*
	 * Grid 			: kartet
	 * Square[,] 		: brettet
	 * teller 			: sørger for at objektene hentes ut kun en gang
	 * PlayerMovement 	: henter ut spiller objektet av Unity
	 */
	
	private Grid grid;
	private Square[,] square;
	private int teller = 0;
	private Dice dice = new Dice();
	
	private PlayerMovement player;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(teller == 0)
		{
			teller++;
			getObject();	
		}
		if (Input.GetMouseButtonDown(0))
		{	
			//FindMatrixPos();
			//KastTerning(dice.ThrowDice);
		}
	}
	
	private void getObject()
	{
		grid = (Grid)FindObjectOfType(typeof(Grid));
		square = grid.getSquare();
		player = gameObject.GetComponent<PlayerMovement>();
	}
	
	public int[] FindMatrixPos()
	{
		Vector3 playerPos = player.transform.position;
		int x_length = (int)(square[0,0].getMLength() * grid.getMXCells()); 	//lengden på brettet gitt i koordinat
		int z_length = (int)(square[0,0].getMLength() * grid.getMYCells());		//dybden på brettet gitt i koordinat
		
		int x = (int)playerPos.x;												//plassen til spilleren gitt i x koordinat
		int z = (int)playerPos.z;												//plassen til spilleren gitt i z koordinat
		
		//fare for å dele på null, men spilleren skal "aldri" være posisjon null
		/* Henter ut matriseplassen til spilleren gitt av ett koordinatsystem */
		/* Henter spiller x koordinat / (antall koordinater i en rekke / antall celler i rekken) */
		int pos_x_matrix = (int)((playerPos.x)/(x_length/grid.getMXCells()));
		int pos_z_matrix = (int)((playerPos.z)/(z_length/grid.getMYCells()));
		
		int[] intern = {pos_x_matrix , pos_z_matrix};
		
		return intern;
	}
	
	/* MovePlayer( int øynePåEnTerning)
	 * @return en matrise med to koordinater, x og z for hvor spilleren skal flyttes etter ett terningkast
	 * 
	 * max_x , max_z 				:	henter ut antall celler i en rekke og kolonne
	 * max_x--, max_z--				: 	for å ta høyde for at en programmeringsmatrise går fra [0-n] må man subrahere med 1 for å få riktig verdi.
	 * 
	 * matrix = FindMatrixPos()		:	Henter ut plassen til spilleren gitt i matrise verdi.
	 * x							:	Henter ut X-verdien fra matrisen i metoden over
	 * z							:	Henter ut Z-verdien fra matrisen i metoden over
	 * 
	 * if(matrix[1]%2==0)			:	Sjekker om spilleren befinner seg i en partalls rekke
	 * if((x+eyes)>max_x)			:	Sjekker om spillerens plass + antall_øyne_på_terning er større enn rekkens størrelse, 
	 * 									for å sikre at spilleren ikke hopper ut av brettet horisontalt
	 * z++							:	Om dette er sant, må spilleren "hoppe" oppover i brettet, altså øker Z-verdien med ett hopp opp
	 * eyes -= max_x - x			:	Spilleren blir nå flyttet til ytterste celle i en rad over, men trekker derfor fra de hoppene spilleren
	 * 									måtte ta for å komme til denne cellen.
	 * eyes--						:	For å ta høyde for en programmeringsmatrise som går fra [0-n] må man subrahere med 1 for å få riktig verdi
	 * x = max_x - eyes				:	Siden spilleren skal gå i ett slangemønster opp brettet, vil spilleren nå gå fra høyre mot venstre, men må
	 * 									derfor trekke fra for å komme til riktig celle.
	 * 
	 * else{}						:	Siden spilleren ikke vil hoppe ut av brettet med gitt terning, er det bare å øke nåværende X-posisjon med gitt terning verdi.
	 * 
	 * else if(matrix[1]%2 == 1)	:	Sjekker om spilleren befinner seg i en oddetalls rekke.
	 * if((x-eyes)<0)				:	Hvis nåværende posisjon - antall_øyne_på_terning er mindre enn 0, (vil spilleren hoppe ut av brettet på venstre side)
	 * z++							:	Spilleren hopper opp en rekke i spillet
	 * eyes -= x					:	Antall øyne er lik spillerens posisjon - mottatt antall øyne på terning, dette fordi man må trekke fra X-verdien for å få spilleren
	 * 									til å hoppe til den første cellen i en rekke for så å kunne hoppe opp ett nivå.
	 * eyes--						:	Tar høyde for en programmeringstabell som går fra [0-n]
	 * x = eyes						:	Spillerens nye posisjon i X-aksen er lik det som er igjen på terningen.
	 * 
	 * else{}						:	Hvis spilleren ikke vil hoppe ut av brettet på venstre side, substraher plassen til spilleren med antall øyne på terning 
	 * 									(spilleren flyttes mot venstre).
	 * 
	 * matrix[0], matrix[1] = x, z	:	matrisen oppdateres med den nye plassen som spilleren skal hoppe til
	 * 
	 * if(z > max_z)				:	Sjekker om spilleren hopper ut av brettet, hvis dette skjer flytt spilleren til siste celle på brettet
	 * 
	 */
	public int[] MovePlayer(int eyes)
	{
		int max_x = grid.getMXCells();
		int max_z = grid.getMYCells();
		max_x--;
		max_z--;
		
		int[] matrix = FindMatrixPos();
		int x = matrix[0];
		int z = matrix[1];
		
	 	if (matrix[1] % 2 == 0)
            {
                if ((x + eyes) > max_x)
                {
                    z++;
                    eyes -= max_x - x;
                    eyes--;
                    x = max_x - eyes;
                }
                else
                {
                    x += eyes;
                }

            }
            else if (matrix[1] % 2 == 1)
            {
                if ((x - eyes) < 0)
                {
                    z++;
                    eyes -= x;
                    eyes--;
                    x = eyes;
                }
                else
                {
                    x -= eyes;
                }
            }
		
		if(z > max_z)
		{
			z = max_z;
			x = max_x;
		}
		
		matrix[0] = x;
		matrix[1] = z;
		
		Debug.Log("X : " + x);
		Debug.Log("Z : " + z);
		
		return matrix;
	}
	
	/*PlasserBrikke( int antall_øyne_på_terning)
	 * 
	 * matrix									:	Henter ut den posisjonen der spilleren skal flyttes basert på antall øyne
	 * x_pos									:	Finner koordinatet til X-posisjonen
	 * z_pos									:	Finner koordinatet til Z-posisjonen
	 * 
	 * z_pos +=(int)square[0,0].getWidth()/2;	:	Adderer en halv celles størrelse for å plassere brikken i midten av cellen
	 * 
	 * playerPos								:	Henter ut posisjonen til spilleren (nåværende)
	 * endPos									:	En Vector posisjon dit spilleren skal flyttes
	 * 
	 * Vector3.Lerp()							:	Metode for å flytte brikken til nye plassen, har mulighet for animasjon
	 */ 
	public void KastTerning(int terning)
	{
		_KastTerning(terning);
	}

	public int KastTerning(int terning)
	{
		_KastTerning(terning);
		return terning;
	}
	
	
	private void _KastTerning(int terning)
	{
		int[] matrix = MovePlayer(terning);
		int x_pos = (int)(matrix[0] * square[0,0].getMWidth());
		int z_pos = (int)(matrix[1] * square[0,0].getMLength());
		
		x_pos +=(int)square[0,0].getMWidth()/2;
		z_pos +=(int)square[0,0].getMLength()/2;
		
		Vector3 playerPos = player.transform.position; 
		Vector3 endPos = new Vector3(x_pos,10,z_pos);
		
		player.transform.position = Vector3.Lerp(playerPos,endPos, Mathf.SmoothStep(0.0f, 1.0f, 1.0f));
		Debug.Log("Terning ble: " + terning);
	}	
}

public struct Dice
{
	public int ThrowDice
	{
		get
		{
			return UnityEngine.Random.Range(1,6);
		}
	}
}
