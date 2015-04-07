using UnityEngine;
using System.Collections;
public class Card : MonoBehaviour {

	#region Fields
	public string cardName;
	public enum Ranks { ACE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING }
	public enum Suits { CLUBS, DIAMONDS, HEARTS, SPADES }

	private static Texture2D[] cardTextures;
	[SerializeField]private Ranks rank; //Serialized for testing and being able to check to make sure cards are coded correctly through the Editor
	[SerializeField]private Suits suit;
	[SerializeField]private bool faceCard;
	#endregion

	#region Properties
	public Ranks Rank
	{
		get { return rank; }
	}

	public Suits Suit 
	{ 
		get { return suit; }
	}

	public bool FaceCard
	{
		get { return faceCard; }
	}
	#endregion

	// Use this for initialization
	void Awake () {

		//Textures
		cardTextures = new Texture2D[52];

		cardTextures[0] = Resources.Load<Texture2D>("Card Textures/ACE of CLUBS");
		cardTextures[1] = Resources.Load<Texture2D>("Card Textures/TWO of CLUBS");
		cardTextures[2] = Resources.Load<Texture2D>("Card Textures/THREE of CLUBS");
		cardTextures[3] = Resources.Load<Texture2D>("Card Textures/FOUR of CLUBS");
		cardTextures[4] = Resources.Load<Texture2D>("Card Textures/FIVE of CLUBS");
		cardTextures[5] = Resources.Load<Texture2D>("Card Textures/SIX of CLUBS");
		cardTextures[6] = Resources.Load<Texture2D>("Card Textures/SEVEN of CLUBS");
		cardTextures[7] = Resources.Load<Texture2D>("Card Textures/EIGHT of CLUBS");
		cardTextures[8] = Resources.Load<Texture2D>("Card Textures/NINE of CLUBS");
		cardTextures[9] = Resources.Load<Texture2D>("Card Textures/TEN of CLUBS");
		cardTextures[10] = Resources.Load<Texture2D>("Card Textures/JACK of CLUBS");
		cardTextures[11] = Resources.Load<Texture2D>("Card Textures/QUEEN of CLUBS");
		cardTextures[12] = Resources.Load<Texture2D>("Card Textures/KING of CLUBS");
		cardTextures[13] = Resources.Load<Texture2D>("Card Textures/ACE of DIAMONDS");
		cardTextures[14] = Resources.Load<Texture2D>("Card Textures/TWO of DIAMONDS");
		cardTextures[15] = Resources.Load<Texture2D>("Card Textures/THREE of DIAMONDS");
		cardTextures[16] = Resources.Load<Texture2D>("Card Textures/FOUR of DIAMONDS");
		cardTextures[17] = Resources.Load<Texture2D>("Card Textures/FIVE of DIAMONDS");
		cardTextures[18] = Resources.Load<Texture2D>("Card Textures/SIX of DIAMONDS");
		cardTextures[19] = Resources.Load<Texture2D>("Card Textures/SEVEN of DIAMONDS");
		cardTextures[20] = Resources.Load<Texture2D>("Card Textures/EIGHT of DIAMONDS");
		cardTextures[21] = Resources.Load<Texture2D>("Card Textures/NINE of DIAMONDS");
		cardTextures[22] = Resources.Load<Texture2D>("Card Textures/TEN of DIAMONDS");
		cardTextures[23] = Resources.Load<Texture2D>("Card Textures/JACK of DIAMONDS");
		cardTextures[24] = Resources.Load<Texture2D>("Card Textures/QUEEN of DIAMONDS");
		cardTextures[25] = Resources.Load<Texture2D>("Card Textures/KING of DIAMONDS");
		cardTextures[26] = Resources.Load<Texture2D>("Card Textures/ACE of HEARTS");
		cardTextures[27] = Resources.Load<Texture2D>("Card Textures/TWO of HEARTS");
		cardTextures[28] = Resources.Load<Texture2D>("Card Textures/THREE of HEARTS");
		cardTextures[29] = Resources.Load<Texture2D>("Card Textures/FOUR of HEARTS");
		cardTextures[30] = Resources.Load<Texture2D>("Card Textures/FIVE of HEARTS");
		cardTextures[31] = Resources.Load<Texture2D>("Card Textures/SIX of HEARTS");
		cardTextures[32] = Resources.Load<Texture2D>("Card Textures/SEVEN of HEARTS");
		cardTextures[33] = Resources.Load<Texture2D>("Card Textures/EIGHT of HEARTS");
		cardTextures[34] = Resources.Load<Texture2D>("Card Textures/NINE of HEARTS");
		cardTextures[35] = Resources.Load<Texture2D>("Card Textures/TEN of HEARTS");
		cardTextures[36] = Resources.Load<Texture2D>("Card Textures/JACK of HEARTS");
		cardTextures[37] = Resources.Load<Texture2D>("Card Textures/QUEEN of HEARTS");
		cardTextures[38] = Resources.Load<Texture2D>("Card Textures/KING of HEARTS");
		cardTextures[39] = Resources.Load<Texture2D>("Card Textures/ACE of SPADES");
		cardTextures[40] = Resources.Load<Texture2D>("Card Textures/TWO of SPADES");
		cardTextures[41] = Resources.Load<Texture2D>("Card Textures/THREE of SPADES");
		cardTextures[42] = Resources.Load<Texture2D>("Card Textures/FOUR of SPADES");
		cardTextures[43] = Resources.Load<Texture2D>("Card Textures/FIVE of SPADES");
		cardTextures[44] = Resources.Load<Texture2D>("Card Textures/SIX of SPADES");
		cardTextures[45] = Resources.Load<Texture2D>("Card Textures/SEVEN of SPADES");
		cardTextures[46] = Resources.Load<Texture2D>("Card Textures/EIGHT of SPADES");
		cardTextures[47] = Resources.Load<Texture2D>("Card Textures/NINE of SPADES");
		cardTextures[48] = Resources.Load<Texture2D>("Card Textures/TEN of SPADES");
		cardTextures[49] = Resources.Load<Texture2D>("Card Textures/JACK of SPADES");
		cardTextures[50] = Resources.Load<Texture2D>("Card Textures/QUEEN of SPADES");
		cardTextures[51] = Resources.Load<Texture2D>("Card Textures/KING of SPADES");
	
	}
	
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
	}

	#region Methods

	//This is the replacement for the constructor, in a way. This is a contructor to construct a GAMEOBJECT IN UNITY, which is different than creating an OBJECT in code.
	//At no time should an object of this class be needed, except for in this method. All we need is the GameObject in Unity that the player will be interacting with.
	/// <summary>
	/// Initiates an object of type Card, with the supplied prefab, position, rank and suit.
	/// </summary>
	/// <param name="prefab">The prefab that represents the object in Unity.</param>
	/// <param name="position">Position to instantiate at.</param>
	/// <param name="_rank">The card's rank.</param>
	/// <param name="_suit">The card's suit.</param>
	public static Card Init(GameObject prefab, Vector3 position, Ranks _rank, Suits _suit)
	{
		//Instantiate the prefab into the scene with the provided arguments, then store in a variable
		GameObject card_obj = Instantiate(prefab, position, Quaternion.identity) as GameObject;

		//Get that variable's Card component, which it inherited from the prefab, and store THAT inside a variable
		Card _card = card_obj.GetComponent<Card>();

		//Set the rank and suit to the ones provided
		_card.rank = _rank;
		_card.suit = _suit;

		//Set the card name, and set the name of the object in the scene to the same name
		_card.cardName = string.Format("{0} of {1}", _rank.ToString(), _suit.ToString());
		card_obj.name = _card.cardName;

		//If the card is a jack, queen, or king, set FaceCard equal to true
		if (_card.rank == Ranks.JACK || _card.rank == Ranks.QUEEN || _card.rank == Ranks.KING)
		{
			_card.faceCard = true;
		}

		#region SWITCH STATEMENT FOR TEXTURING

		//Texture each card according to name
		switch (_card.cardName)
		{
			case "ACE of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[0];
				break;
				
			case "TWO of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[1];
				break;
				
			case "THREE of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[2];
				break;
				
			case "FOUR of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[3];
				break;
				
			case "FIVE of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[4];
				break;
				
			case "SIX of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[5];
				break;
				
			case "SEVEN of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[6];
				break;
				
			case "EIGHT of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[7];
				break;
				
			case "NINE of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[8];
				break;
				
			case "TEN of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[9];
				break;
				
			case "JACK of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[10];
				break;
				
			case "QUEEN of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[11];
				break;
				
			case "KING of CLUBS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[12];
				break;
				
			case "ACE of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[13];
				break;
				
			case "TWO of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[14];
				break;
				
			case "THREE of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[15];
				break;
				
			case "FOUR of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[16];
				break;
				
			case "FIVE of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[17];
				break;
				
			case "SIX of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[18];
				break;
				
			case "SEVEN of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[19];
				break;
				
			case "EIGHT of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[20];
				break;
				
			case "NINE of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[21];
				break;
				
			case "TEN of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[22];
				break;
				
			case "JACK of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[23];
				break;
				
			case "QUEEN of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[24];
				break;
				
			case "KING of DIAMONDS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[25];
				break;
				
			case "ACE of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[26];
				break;
				
			case "TWO of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[27];
				break;
				
			case "THREE of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[28];
				break;
				
			case "FOUR of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[29];
				break;
				
			case "FIVE of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[30];
				break;
				
			case "SIX of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[31];
				break;
				
			case "SEVEN of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[32];
				break;
				
			case "EIGHT of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[33];
				break;
				
			case "NINE of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[34];
				break;
				
			case "TEN of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[35];
				break;
				
			case "JACK of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[36];
				break;
				
			case "QUEEN of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[37];
				break;
				
			case "KING of HEARTS":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[38];
				break;
				
			case "ACE of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[39];
				break;
				
			case "TWO of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[40];
				break;
				
			case "THREE of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[41];
				break;
				
			case "FOUR of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[42];
				break;
				
			case "FIVE of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[43];
				break;
				
			case "SIX of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[44];
				break;
				
			case "SEVEN of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[45];
				break;
				
			case "EIGHT of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[46];
				break;
				
			case "NINE of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[47];
				break;
				
			case "TEN of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[48];
				break;
				
			case "JACK of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[49];
				break;
				
			case "QUEEN of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[50];
				break;
				
			case "KING of SPADES":
				_card.GetComponent<Renderer>().material.mainTexture = cardTextures[51];
				break;
		}
		#endregion

		return _card;
	}

	#endregion
	
}
