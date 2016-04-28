using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateEODData : MonoBehaviour {

	public Text endOfDayText;
	public Text fishCaughtText;
	public Text dailyIncomeText;
	public Text expensesText;
	public Text previousMoneyText;
	public Text newBalanceText;
	public Text continueText;
	public Button continueButton;
	public Button nextLevelButton;

	private GlobalVariablesScript globalVars;
	private int todaysIncome;
	private int todaysExpenses;

	void Awake() {
		//Set globalVars script object
		globalVars = GameObject.FindGameObjectWithTag ("GlobalVariables").GetComponent<GlobalVariablesScript> ();
	}

	void Start() {
		

		//Calculate income & expenses
		todaysIncome = (globalVars.fishCaughtToday * 100);
		todaysExpenses = ((globalVars.currentLevel * 175) + 100);

		//Update text
		fishCaughtText.text = "Fish Caught: " + globalVars.fishCaughtToday;
		dailyIncomeText.text = "Today's Income: " + todaysIncome;
		expensesText.text = "Today's Expenses: " + todaysExpenses;
		previousMoneyText.text = "Previous Balance: " + globalVars.totalMoney;

		//Calculate new balance
		globalVars.totalMoney += todaysIncome - todaysExpenses;

		//Update text
		newBalanceText.text = "New Balance: " + globalVars.totalMoney;
	}

	public void continueClicked() {

		if (globalVars.totalMoney < 0) {
			SceneManager.LoadScene ("GameOver");
		} else {

			//Update level text
			setContinueText ();

			//Deactivate Text
			fishCaughtText.gameObject.SetActive (!fishCaughtText.IsActive ());
			dailyIncomeText.gameObject.SetActive (!dailyIncomeText.IsActive ());
			expensesText.gameObject.SetActive (!expensesText.IsActive ());
			previousMoneyText.gameObject.SetActive (!previousMoneyText.IsActive ());
			newBalanceText.gameObject.SetActive (!newBalanceText.IsActive ());
			continueText.gameObject.SetActive (!continueText.IsActive ());

			//Deactivate button/Activate button
			continueButton.gameObject.SetActive (!continueButton.IsActive ());
			nextLevelButton.gameObject.SetActive (!nextLevelButton.IsActive ());
		}
	}

	//Load game scene
	public void startNextLevel() {
		SceneManager.LoadScene ("LevelOne");
	}

	void setContinueText() {
		switch (globalVars.currentLevel) {
		case 1:
			continueText.text = 
				"A music festival is held next to the lake. Although trash cans were available, " +
			"much of the trash ends up on the ground and eventually makes it into the lake. " +
			"As a result, 10 units of trash are added to the lake.";
			break;
		case 2:
			continueText.text = 
				"A music festival is held next to the lake. Although trash cans were available, " +
				"much of the trash ends up on the ground and eventually makes it into the lake. " +
				"As a result, 10 units of trash are added to the lake.";
			break;
		case 3:
			continueText.text = 
				"The nearby factory had an issue with trash lines, and trash accidentally leaked " +
			"into the lake. The issue was fixed, but 20 units of trash are added to the lake.";
			break;
		default:
			continueText.text = "Default Text";
			break;
		}
	}


}
