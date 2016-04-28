using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateEODData : MonoBehaviour {


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

	void continueClicked() {
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

	//Load game scene
	void startNextLevel() {
		SceneManager.LoadScene ("LevelOne");
	}


}
