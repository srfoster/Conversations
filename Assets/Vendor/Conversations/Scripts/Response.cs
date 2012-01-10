using UnityEngine;
using System.Collections;

public class Response {
	
	private string response = null;
	private Node nextNode = null;
	private bool is_exit = false;
	
	// If there is no next node then it exits the conversation
	public Response(string p_response)
	{
		response = p_response;
	}
	
	public Response(string p_response, Node p_nextNode)
	{
		response = p_response;
		nextNode = p_nextNode;
	}
	
	public string getResponseText()
	{
		return response;	
	}
	
	public Node getNextNode()
	{
		return nextNode;	
	}
	
	public void setIsExit(bool is_exit)
	{
		this.is_exit = is_exit;	
	}
	
	public bool isExit()
	{
		return this.is_exit;
	}
	
	public void setNextNode(Node nextNode)
	{
		this.nextNode = nextNode;
	}
}
