using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Deck : Card {

	#region Fields
	public GameObject card_prefab;
	 
	private static Deck singleton_instance;
	private List<Card> deck_list; //Needed for shuffling, since stacks cannot be shuffled
	private Stack<Card> deck_stack; //Used for actual in-game deck
	private bool isShuffled;
	#endregion

	#region Properties
	public static Deck Singleton
	{ 
		get { return singleton_instance; } 
	}
	public bool IsShuffled 
	{ 
		get { return isShuffled; }
		
		set { isShuffled = value; }
	}
	public bool IsEmpty
	{
		get
		{
			return deck_stack.Count == 0;
		}
	}
	#endregion

	// Use this for initialization
	void Awake () {

		singleton_instance = this; //Because this script is already attached to Deck object

		deck_list = new List<Card>(52);
		deck_stack = new Stack<Card>(52);

		isShuffled = false;  

	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#region Methods

	/// <summary>
	/// Initializes the deck.
	/// </summary>
	public void InitializeDeck()
	{
		//Initiliaze a card for each rank of each suit
		foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
		{
			foreach (Card.Ranks rank in Enum.GetValues(typeof(Card.Ranks)))
			{
				//A constructor used to be here, but Unity doesn't play well with them --> deck_list.Add(new Card(rank, suit));
				//deck_list.Add(card_inst.Init(card_prefab, deck_position, rank, suit));
				deck_list.Add(Card.Init(card_prefab, this.gameObject.transform.position, rank, suit));
				
			}
		}

		Shuffle();
		PlaceInStack();
	}

  //From "Beginning C# Programming"
	/// <summary>
	/// Shuffles the LIST deck.
	/// </summary>
	private void Shuffle()
	{
		System.Random randomNum = new System.Random(); //Must add System. prefix to not get a compiler error
		for (int i = deck_list.Count - 1; i > 0; i--)
		{
			int randomIndex = randomNum.Next(i + 1);
			Card tempCard = deck_list[i];
			deck_list[i] = deck_list[randomIndex];
			deck_list[randomIndex] = tempCard;
		}
		isShuffled = true;
	}

	/// <summary>
	/// Places the LIST deck in the STACK deck and then clears the list.
	/// </summary>
	private void PlaceInStack()
	{
		deck_list.ForEach(deck_stack.Push);
		deck_list.Clear();
	}
	

	/// <summary>
	/// Deals the cards to each hand.
	/// </summary>
	public void Deal()
	{
		//Eventually, this will need to be edited to accomodate all players
		if(isShuffled && (GameManager.Singleton.Player1.IsHandEmpty && GameManager.Singleton.Player2.IsHandEmpty))
		{
			//For some reason a foreach loop will not work here. Most likely because we have to subtract by the number of players, or becuase we are modifying the stack as we access it.
			for (int i = deck_stack.Count - 1; i > 0; i-=2)
			{

				//Push the top card into the hand
				GameManager.Singleton.Player1.hand.Push(deck_stack.Pop());

				//Take player 1's hand's transform and make that the parent of the card just popped/pushed
				GameManager.Singleton.Player1.hand.Peek().transform.parent = GameManager.Singleton.Player1.transform;

				//Make that same card's position the same as player 1's hand's position
				GameManager.Singleton.Player1.hand.Peek().transform.position = GameManager.Singleton.Player1.transform.position;

				//Same for player 2
				GameManager.Singleton.Player2.hand.Push(deck_stack.Pop());
				GameManager.Singleton.Player2.hand.Peek().transform.parent = GameManager.Singleton.Player2.transform;
				GameManager.Singleton.Player2.hand.Peek().transform.position = GameManager.Singleton.Player2.transform.position;
			}
		}
	}

	#endregion
}
