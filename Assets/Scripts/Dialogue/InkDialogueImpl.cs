using DUFE.UI.Effects;
using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InkDialogueImpl : MonoBehaviour
{
	[SerializeField]
	private TextAsset inkJSONAsset = null;
	public Story story;

	[SerializeField]
	private GameObject dialogueParent = null;
	// UI Prefabs
	[SerializeField]
	private TextMeshProUGUI text = null;
	[SerializeField]
	private Button buttonPrefab = null;
	[SerializeField]
	private GameObject buttonParent = null;
	[SerializeField]
	public UnityEvent onEndOfDialogue;
	public static event Action<Story> OnCreateStory;

	void Awake()
	{
		// Remove the default message
		RemoveChildrenChoices();
		ResetText();
	}

	void ResetText()
	{
		dialogueParent.SetActive(false);
	}
	// Creates a new Story object with the compiled story which we can then play!
	public void StartStory()
	{
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		dialogueParent.SetActive(true);
		RefreshView();
	}

	public void StartStoryWithFade()
	{
		StartCoroutine(FadeStart());
	}

	IEnumerator FadeStart()
	{
		TransitionManager tm = FindObjectOfType<TransitionManager>();
		tm.fadeOut();
		yield return new WaitForSeconds(tm.anim.GetCurrentAnimatorStateInfo(0).length - 0.01f);
		tm.fadeIn();
		story = new Story(inkJSONAsset.text);
		if (OnCreateStory != null) OnCreateStory(story);
		dialogueParent.SetActive(true);
		RefreshView();

	}
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView()
	{
		// Remove all the UI on screen
		RemoveChildrenChoices();

		// Read all the content until we can't continue any more
		if (story.canContinue)
		{
			// Continue gets the next line of the story
			string text = story.Continue();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
		}

		// Display all the choices, if there are any!
		if (story.currentChoices.Count > 0)
		{
			for (int i = 0; i < story.currentChoices.Count; i++)
			{
				Choice choice = story.currentChoices[i];
				Button button = CreateChoiceView(choice.text.Trim());
				// Tell the button what to do when we press it
				button.onClick.AddListener(delegate {
					OnClickChoiceButton(choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else
		{
			onEndOfDialogue?.Invoke();
		}
	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton(Choice choice)
	{
		story.ChooseChoiceIndex(choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView(string dialogueLine)
	{
		text.text = dialogueLine;
	}

	// Creates a button showing the choice text
	Button CreateChoiceView(string text)
	{
		// Creates the button from a prefab
		Button choice = Instantiate(buttonPrefab) as Button;
		choice.transform.SetParent(buttonParent.transform, false);

		// Gets the text from the button prefab
		TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
		choiceText.text = text;


		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildrenChoices()
	{
		int childCount = buttonParent.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i)
		{
			GameObject.Destroy(buttonParent.transform.GetChild(i).gameObject);
		}
	}

}
