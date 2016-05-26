using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * UpdateEODData
 * 
 * Updates End of Day page Data. Calculates income and expenses, then total 
 * balance. If the balance is less than 0, then when "Continue" is clicked,
 * the player is sent to the GameOver scene. Otherwise, the player sees
 * some story text about the next level. Once the player presses the
 * Next Level button, the level scene will be loaded.
 */ 
public class UpdateEODData : MonoBehaviour {

	//Private vars
	private GlobalVariablesScript globalVars;
	private int todaysIncome;
	private int todaysExpenses;

	//GUI vars
	public Text endOfDayText;
	public Text fishCaughtText;
	public Text dailyIncomeText;
	public Text expensesText;
	public Text previousMoneyText;
	public Text newBalanceText;
	public Text continueText;
	//public Text trashText;
	public Button continueButton;
	public Button nextLevelButton;
	private int fontSize;

	void Awake() {
		//Set globalVars script object
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();
	}

	void Start() {

		//Update overall data
		globalVars.fishCaughtTotal += globalVars.fishCaughtToday;

		//Calculate income & expenses
		todaysIncome = (globalVars.fishCaughtToday * 125);
		if (globalVars.currentLevel <= 2) {
			todaysExpenses = 0;
		} else {
			todaysExpenses = randomizeInt (400);
		}

		//Update text
		fishCaughtText.text = "Fish Caught: " + globalVars.fishCaughtToday;
		dailyIncomeText.text = "Today's Income: " + todaysIncome;
		expensesText.text = "Today's Expenses: " + todaysExpenses;
		previousMoneyText.text = "Previous Balance: " + globalVars.totalMoney;

		//Calculate new balance
		globalVars.totalMoney += todaysIncome - todaysExpenses;

		//Update text
		newBalanceText.text = "New Balance: " + globalVars.totalMoney;


		//Scale Text to Resolution
		fontSize = (int)(globalVars.screenRatio * endOfDayText.fontSize);	//Determine title font size
		endOfDayText.fontSize = fontSize;

		fontSize = (int)(globalVars.screenRatio * fishCaughtText.fontSize);	//Determine body font size
		fishCaughtText.fontSize = fontSize;
		dailyIncomeText.fontSize = fontSize;
		expensesText.fontSize = fontSize;
		previousMoneyText.fontSize = fontSize;
		newBalanceText.fontSize = fontSize;
		continueText.fontSize = fontSize;
//		trashText.fontSize = fontSize;
		continueButton.GetComponentInChildren<Text> ().fontSize = fontSize;
		nextLevelButton.GetComponentInChildren<Text> ().fontSize = fontSize;

		//reset daily variables
		globalVars.fishCaughtToday = 0;
	}

	public void continueClicked() {

		//If player has no money, load game over scene, otherwise display "Continue" screen
		if (globalVars.totalMoney < 0) {
			SceneManager.LoadScene ("GameOver");
		} else {

			//Update level text
			setContinueText ();

			//Deactivate/Activate Text
			fishCaughtText.gameObject.SetActive (!fishCaughtText.IsActive ());
			dailyIncomeText.gameObject.SetActive (!dailyIncomeText.IsActive ());
			expensesText.gameObject.SetActive (!expensesText.IsActive ());
			previousMoneyText.gameObject.SetActive (!previousMoneyText.IsActive ());
			newBalanceText.gameObject.SetActive (!newBalanceText.IsActive ());
			continueText.gameObject.SetActive (!continueText.IsActive ());
//			trashText.gameObject.SetActive (!trashText.IsActive ());

			//Deactivate/Activate buttons
			continueButton.gameObject.SetActive (!continueButton.IsActive ());
			nextLevelButton.gameObject.SetActive (!nextLevelButton.IsActive ());
		}
	}

	//Load game scene
	public void startNextLevel() {
		SceneManager.LoadScene ("LevelOne");
	}

	int randomizeInt(int number){
		return (int)(number * Random.Range (0.8f, 1.2f));
	}

	//Display story text
	void setContinueText() {
		int trashToAdd = 0;
		switch (globalVars.currentLevel) {
		case 1:	//Case 1 should not be reached, as it starts at level1 and increments to 2 before this is reached
			trashToAdd = randomizeInt(10);
			continueText.text = 
				"A music festival is held next to the lake. Although trash cans were available, " +
			"much of the trash ends up on the ground and eventually makes it into the lake. " +
			"As a result, " + trashToAdd + " units of trash are added to the lake.";
			break;
		case 2:
			trashToAdd = randomizeInt(12);
			continueText.text = 
				"A music festival is held next to the lake. Although trash cans were available, " +
				"much of the trash ends up on the ground and eventually makes it into the lake. " +
				"As a result, " + trashToAdd + " units of trash are added to the lake.";
			break;
		case 3:
			trashToAdd = randomizeInt(14);
			continueText.text = 
				"The nearby factory had an issue with trash lines, and trash accidentally leaked " +
				"into the lake. The issue was fixed, but " + trashToAdd + " units of trash are added to the lake.";
			break;
		case 4:
			trashToAdd = randomizeInt (16);
			continueText.text =
				"A storm passes through during the night. Trash littered in the streets is pushed " +
			"by the water into the ocean, adding " + trashToAdd + " units of trash.";
			break;
		case 5:
			trashToAdd = randomizeInt (8);
			globalVars.fishInWater -= trashToAdd;
			continueText.text = 
				"A nearby oil rig breaks and leaks many gallons of oil into the water. As a result," +
			"many of the fish in the water die. " + trashToAdd + " fish die.";
			trashToAdd = 0;
			break;
		case 6:
			trashToAdd = randomizeInt (18);
			continueText.text =
				"Strong winds blow trash from the nearby landfill into the water, adding " + trashToAdd
				+ " units of trash. ";
			break;
		case 7:
			trashToAdd = randomizeInt (20);
			continueText.text =
				"The local fishing shop had a clearance sale and hosted a fishing extravaganza event." +
			"Fishing lines, bait boxes, and packaging are lost in the water, adding " + trashToAdd +
			"units of trash.";
			break;
		case 8:
			trashToAdd = randomizeInt (20);
			continueText.text =
				"A nice, sunny day brings a plethora of tourists and locals to the beach. Children leave " +
			"behind beach toys, and groups hosting bonfires leave behind food and beverage packaging. " +
			"Cigarette butts also litter the beach and find their way into the water. " + trashToAdd +
			" units of trash are added.";
			break;
		case 9:
			trashToAdd = randomizeInt (20);
			continueText.text = 
				"The local fishing shop has recently been renovated and the construction workers have been dumping their bottles " +
			"of coke into the lake, adding " + trashToAdd + "units of trash.";
			break;
		case 10:
			trashToAdd = randomizeInt (20);
			continueText.text = 
				"Its family lake day. Families from across the town came and had a picnic by the lake, but left without " +
			"without picking up their trash, some of which got left behind in the waters, adding " + trashToAdd +
			"units of trash.";
			break;
		case 11:
			trashToAdd = randomizeInt (20);
			continueText.text = 
				"It is a windy day and a rare specie of fish has recently been discovered in the lake." +
			"Fisherman have been flocking over to " +
			"try to catch the beauty. Caught up in the excitement, they have been dumping their newly acquired " +
			"rods' packaging from the local fishing shop on the shore, where the wind blew it into the lake, adding " + trashToAdd +
			"units of trash.";
			break;
		case 12:
			trashToAdd = randomizeInt (30);
			continueText.text = 
				"Local garbage truck came and tipped over, dumping " + trashToAdd +
			"units of trash.";
			break;
		case 13:
			trashToAdd = randomizeInt (20);
			continueText.text = 
				"Tornado has struck the town blowing the town's trash everywhere, some of which landed in the ocean, adding" +
			trashToAdd + "units of trash.";
			break;
		case 14:
			trashToAdd = randomizeInt (20);
			continueText.text = 
				"Lights! Camera! Action! A movie set decided to film a scene on the lake, but some of the actors " +
				"left behind their trash." + trashToAdd + "units of trash.";
			break;
		case 15:
			trashToAdd = randomizeInt (20);
			continueText.text = 
				"Annual Fishing Competition is today! Fisherman come from towns nearby to compete on who can catch " +
			"the most amount of fish. Unfortunately, their trash wounded up into the lake, adding " + trashToAdd +
			"units of trash.";
			break;

		default:
			continueText.text = "Default Text";
			break;
		}
		globalVars.trashInWater += trashToAdd;

		globalVars.fishInWater += randomizeInt ((int)(globalVars.fishInWater * 0.05f));

//		trashText.text = "Total Units of Trash: " + globalVars.trashInWater;
	}


}
