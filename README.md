Marketinvoice Test

=== Overview ===

Create a simple run-once state machine that reads in text files, processes the state inside,
saves the updated object to text file, creates a receipt text file and deletes the 
original text file.

Create a very simple ASP.NET MVC site (can be one page) that displays a list of all fruits on the system 
and their properties.
	
You can use any additional tools and libraries that you want.


=== Task Details ===

1) We would like you to build a State Pattern based C# Console Application that:

	1. Reads in a set of json based text files into Fruit objects
	
	2. Loops through each Fruit object and does the following actions:
			
			* Set this Fruit.DeliveryState to the next logical DeliveryState enum
			
			* Write this message to the console: "{0} {1}"  where {0} is Fruit.Name and {1} 
			  is a long description of the new state such as  "arrived at the classification centre." for DeliveryStates.ArrivedAtClassificationCentre
			
			* Serialize and save the updated Fruit object to the appropriate directory 
			  that represents the new delivery state of the fruit
			  eg: Fruit.DeliveryState.EnrouteToMarket should be save to:
			  ".\StateTest\EnrouteToMarket\{0}.txt" where {0} is Fruit.Name
	
			* Save a copy of the original Fruit object to the "Processed" directory of
			  the original DeliveryState enum with filename: {0}.txt where {0} is Fruit.Name
			  eg: Fruit.DeliveryState.JustPicked should be saved to:
			  ".\StateTest\JustPicked\Processed\{0}.txt" where {0} is Fruit.Name

			* Delete the original Fruit txt file once all these steps have been processed
		
	3. Keep looping until all Fruits have been transitioned to a Delivered state.
		

2) Then we would like you to build a very simplistic ASP.NET MVC site that:

	1. Displays a list of all fruits with their name, price, expire and delivery state. 

	2. The delivery state should be displayed as a friendly string - for example: "EnrouteToMarket" should 
	   be displayed as "Enroute to market".

        3. Don't worry about concurrency issues - the site and console application will not run at the same time.


=== Resources ===
	
This repository contains the directory struture and test text files you need to read. 

	.\StateTest\JustPicked\
	.\StateTest\JustPicked\Processed\

	.\StateTest\EnrouteToMarket\
	.\StateTest\EnrouteToMarket\Processed\
	
	.\StateTest\Delivered\
	.\StateTest\Delivered\Processed\

	.\StateTest\ArrivedAtClassificationCentre\
	.\StateTest\ArrivedAtClassificationCentre\Processed\

	The text files contain JSON that need to be read into objects. You are free to use whatever you want to 
	handle JSON serialization and deserialization.

	
public class Fruit
{
	public string Name { get; set; }
	public DateTime Expiry { get; set; }
	public decimal Price { get; set; }    
	public DeliveryStates DeliveryState { get; set; }
}

public enum DeliveryStates
{
	JustPicked = 1,
	ArrivedAtClassificationCentre = 2,        
	EnrouteToMarket = 3,
	Delivered = 4
}	
