using UnityEngine;
using System.Collections;

/*
 * Conversation with data stored as a graph of Nodes and Responses.
 */
public class GraphConversation : Conversation {
	//The node to start with when the player walks up the the NPC for the first time
	private Node initialNode = null;
	//The current node that the player is using to communicate to the NPC
	private Node currentNode = null;
	
	public GraphConversation()
	{
		//To be taken out when a better way of initializing conversations happens
		initializeLargeConversation();

		//Initializing the current node to the first one
		currentNode = initialNode;
	}
	
	//Returns the text that the NPC will say to the player
	public override string GetText(){
		return currentNode.getStatement();
	}
	
	//Returns the list of responses that the player can say to the NPC
	public override ArrayList GetResponses(){
		if(currentNode == null)
			return null;
		
		return currentNode.getResponses();
	}
	
	//Continues the conversation based on what the player responded
	public override void Respond(Response response){
		currentNode = response.getNextNode();
	}
	
	//To be taken out when a better way of initializing conversations is used
	public void initializeLargeConversation()
	{
		//The initial statement
		initialNode = new Node("Hello. How are you doing today?");
		
		//The Task
		Node doTask = new Node("Awesome! Try running around around me 3 times.");
		
		//Eventually should be something that checks
		Node completedTask = new Node("Good Job! That's all I have for you.");
		completedTask.getExitResponse().setNextNode(initialNode);
		doTask.getExitResponse().setNextNode(completedTask);
		Node nothingElse = new Node("You've already completed my task.");
		nothingElse.getExitResponse().setNextNode(nothingElse);
		
		//If they said they don't want to do the task, then they should be told to come back when they do want to do it.
		Node dontDoTask = new Node("Ok. Come back when you want to play.");
		
		//If they previously didn't do the task and they come back then they should be asked if they want to do it.
		Node doTaskNow = new Node("Do you want to do the task now?");
		dontDoTask.getExitResponse().setNextNode(doTaskNow);
		doTaskNow.getExitResponse().setNextNode(doTaskNow);
		
		//If they do want to do the task, then continue on to give them instructions
		Response yesTask = new Response("Yes!",doTask);
		doTaskNow.addResponse(yesTask);
		Response noTask = new Response("No thanks.", dontDoTask);
		doTaskNow.addResponse(noTask);
		
		//If "Im good" response is chosen, the NPC will then say:
		Node goodNextNode = new Node("That's Great! Do you want to try a task then?");
		goodNextNode.getExitResponse().setNextNode(doTaskNow);
		
		goodNextNode.addResponse(yesTask);
		goodNextNode.addResponse(noTask);
			
		// NOTE: What I am realizing right now is that you will have to build 
		// conversations from the bottom up...this is kind of annoying because you can't
		// easily add a layer in between, maybe not necessary, but it also makes more sense
		// to think about a conversation from the beginning to the end, not from the
		// end to the beginning...I don't really see another way of doing it right now though...
		Response good = new Response("I'm good!", goodNextNode);
		
		Node badNextNode = new Node("Oh No! Maybe a task will help you feel better?");
		badNextNode.getExitResponse().setNextNode(doTaskNow);
		Response bad = new Response("I'm having a bad day", badNextNode);
		
		badNextNode.addResponse(yesTask);
		badNextNode.addResponse(noTask);
		
		Node confusedNextNode = new Node("Confused? Here, I'll help you by giving you a task to do.");
		confusedNextNode.getExitResponse().setNextNode(doTaskNow);
		Response confused = new Response("Confused", confusedNextNode);
		
		confusedNextNode.addResponse(yesTask);
		confusedNextNode.addResponse(noTask);
		
		initialNode.addResponse(good);
		initialNode.addResponse(bad);
		initialNode.addResponse(confused);	
	}
}
