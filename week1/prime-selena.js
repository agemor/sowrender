var inputNumber = 23; // 사용자에게 입력받는 값
var isPrimeNumber = false;

if(inputNumber == 2){
  isPrimeNumber = true;
} else {
  for(var tempNum = 2; tempNum < inputNumber; tempNum++){
    if(inputNumber % tempNum === 0){
      isPrimeNumber = true;
      break;
    }
  }
}

console.log(isPrimeNumber);
