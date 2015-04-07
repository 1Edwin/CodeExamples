#include <iostream>
#include <cmath>
#include <cstdlib>
#include <ctime>

int Random(int low, int high);
float playerChips = 1000;
float playerBet = 0;
int input = 0;

int main()
{
	srand(time(0));
	
	while (playerChips > 0)
	{
		//Menu
		std::cout << "Player's chips: $" << playerChips << std::endl;
		std::cout << "1) Play slot  ";
		std::cout << "2) Exit  ";
		std::cin >> input;

		//Check for Quit
		if (input == 2)
		{
			std::cout << "Exiting..." << std::endl;
			break;
		}
		else if (input != 1 && input != 2)
		{
			std::cout << std::endl;
			std::cout << "Invalid" << std::endl;
			std::cout << std::endl;
			continue;
		}
		
		//Bet Enter
		do
		{
			std::cout << std::endl;
			std::cout << "Enter your bet: ";
			std::cin >> playerBet;
			if (playerBet <= 0 || playerBet > playerChips)
			{
				std::cout << "You did not enter a valid bet.";
			}

		} while (playerBet <= 0 || playerBet > playerChips);

		//Slots
		int slot1 = Random(2, 7);
		int slot2 = Random(2, 7);
		int slot3 = Random(2, 7);
		
		
		std::cout << std::endl;
		std::cout << slot1 << "  ";
		std::cout << slot2 << "  ";
		std::cout << slot3 << std::endl;
		std::cout << std::endl;

		//Win/Lose Check
		if (slot1 == 7 && slot2 == 7 && slot3 == 7)
		{
			std::cout << "You win!" << std::endl;
			playerChips += playerBet * 10;
		}
		else if ((slot1 == slot2 && slot2 == slot3) && (slot1 != 7 && slot2 != 7 && slot3 != 7))
		{
			std::cout << "You win!" << std::endl;
			playerChips += playerBet * 5;
		}
		else if ((slot1 == slot2 || slot2 == slot3 || slot1 == slot3))
		{
			std::cout << "You win!" << std::endl;
			playerChips += playerBet * 3;
		}
		else
		{
			std::cout << "You lost." << std::endl;
			playerChips -= playerBet;
		}
		
	}
	
}

int Random(int low, int high)
{
	int num = low + rand() % ((high + 1) - low);
	return num;
}
