#include <iostream>
#include <cmath>

int BinSearch(int data[], int numElements, int searchKey);
int numArray[23] = { 1, 4, 5, 6, 9, 14, 21, 23, 28, 31, 35, 42, 46, 50, 53, 57, 62, 63, 65, 74, 79, 89, 95 };
int searchKey_input = 0;
int position = 0;

int main()
{
	std::cout << "{1, 4, 5, 6, 9, 14, 21, 23, 28, 31, 35, 42, 46, 50, 53, 57, 62, 63, 65, 74, 79, 89, 95}" << std::endl; //This is lacking, it would be much better to loop through the array and print each number neatly
	
	for (size_t i = 0; i < 100; i++) //This loop is only to keep the program going
	{
		std::cout << "Enter search key: ";
		std::cin >> searchKey_input;
		std::cout << searchKey_input << " is in position " << BinSearch(numArray, 23, searchKey_input) << "." << std::endl;
	}
	
	
}

int BinSearch(int data[], int numElements, int searchKey)
{	
	int middleIndex = 0;
	int startIndex = 0; //Start index of subarray
	int endIndex = 0; //End index of subarray
	float indexTotal = numElements - 1; 

	//Half the number of elements then get the floor (because arrays are zero-indexed) and that will be the middle index
	middleIndex = (floorf((indexTotal) / 2));
	//startIndex = 0 (Already initialized to zero)
	endIndex = indexTotal;
	
	while (data[middleIndex] != searchKey)
	{

		//If the middle index contains the number we're searching for
		if (data[middleIndex] == searchKey)
		{
			position = middleIndex;
			return position;
			break;
		}
		//If the middle index contains a value higher than the index
		else if (searchKey > data[middleIndex])
		{
			startIndex = middleIndex + 1;
			//endIndex doesn't change
			middleIndex = ((endIndex - startIndex) / 2) + startIndex;
			
		}
		//If the middle index contains a value lower than the index
		else if (searchKey < data[middleIndex])
		{
			//startIndex doesn't change
			endIndex = middleIndex - 1;
			middleIndex = ((endIndex - startIndex) / 2) + startIndex;

		}
		//If number entered is not in the array
		else
		{
			std::cout << searchKey << " not found." << std::endl;
			break;
		}
	}
}
