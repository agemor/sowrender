#include <stdio.h>
#pragma warning(disable:4996)

typedef enum { false, true } bool;

void main() {
	int input;
	bool result;
	while (1) {
		printf("Please input the number\n");
		scanf("%d", &input);

		if (input < 0) {
			input = input * -1;
			result = IsThatPrimeNum(input);
		}
		else
			result = IsThatPrimeNum(input);

		if (result == false)
			printf("This is not a Prime Number\n");
		else
			printf("This is a Prime Number\n");
	}
}

bool IsThatPrimeNum(int input) {
	int CheckNum = 2;
	if (input == 0 || input == 1)
		return false;
	else {
		for (CheckNum = 2; CheckNum < input; CheckNum++) {
			if (input % CheckNum == 0) return false;
		}
		return true;
	}
}