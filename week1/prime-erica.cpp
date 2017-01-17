#include < stdio.h >

bool isPrimaryNum(int data) {

	if (data == 2 || data == 3) {
		return true;
	}
	else if (data <= 1 || data % 2 == 0) {
		return false;
	}

	for (int i = 3; i < data / (i - 1); i += 2) {
		if (data % i == 0) {
			printf("%d", i);
			return false;
		}
	}
	return true;
}

int main() {
	int input = 0;
	scanf("%d", &input);

	if (isPrimaryNum(input)) {
		//	printf("true\n");
		printf("0");
	}
	else {
		//   printf("false\n");
	}

}