// EratostenesCpp.cpp : Defines the entry point for the console application.

#include "stdafx.h"
#include <iostream>

#define NUM_OF_INVALID_CHARS_TO_SKIP 1000

using std::cin;
using std::cout;
using std::endl;

int GetLimit();
void MarkMultiplesOfPrimeNumer(bool* numbers, int length, int primeNumber);

int _tmain(int argc, _TCHAR* argv[])
{
	auto limit = GetLimit();
	auto length = limit + 1;
	auto numbers = new bool[length];
	bool* numbersAddress = numbers;

	for (auto i = 0; i < length; i++)
	{
		*numbersAddress++ = true;
	}

	cout << "Result: ";

	for (auto i = 2; i < length; i++)
	{
		if (numbers[i])
		{
			cout << i << ' ';
			MarkMultiplesOfPrimeNumer(numbers, length, i);
		}
	}

	cout << endl;

	cout << "Press Enter key to exit";
	cin.ignore();
	cin.ignore();
	
	delete numbers;

	return 0;
}

int GetLimit(){
	cout << "Welcome to the Sieve of Eratosthenes." << endl 
		<< "The program will find all prime numbers up to a given limit" << endl;

	int limit = 0;
	bool success = false;

	while (!success)
	{
		cin >> limit;
		if (!cin || (limit < 2))
		{
			cin.clear();
			cin.ignore(NUM_OF_INVALID_CHARS_TO_SKIP, '\n');
		}
		else{
			success = true;
		}
	}
	
	return limit;
}

void MarkMultiplesOfPrimeNumer(bool* numbers, int length, int primeNumber){
	for (int n = primeNumber*2; n < length; n = n + primeNumber)
	{
		numbers[n] = false;
	}
}
