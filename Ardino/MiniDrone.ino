
// Define the motors
int PWMMotorFLPin = 3; // Front Left
int PWMMotorFRPin = 5; // Front Right
int PWMMotorBLPin = 6; // Back Left
int PWMMotorBRPin = 9; // Back Right

// Max Values
int PWMMotorFLMax = 255; // Front Left
int PWMMotorFRMax = 255; // Front Right
int PWMMotorBLMax = 255; // Back Left
int PWMMotorBRMax = 255; // Back Right

int SensitivityPercent = 1;

// Intital Position
int intialPWMMotorFLValue = 100; // Front Left
int intialPWMMotorFRValue = 100; // Front Right
int intialPWMMotorBLValue = 100; // Back Left
int intialPWMMotorBRValue = 100; // Back Right

// Actual Position
int PWMMotorFLValue = 0; // Front Left
int PWMMotorFRValue = 0; // Front Right
int PWMMotorBLValue = 0; // Back Left
int PWMMotorBRValue = 0; // Back Right

void setup() {
  // initialize the serial communication:
  Serial.begin(9600);
  setMotorValues(); // Initial write
  delay(1000);
}

void loop() {
  // Check if any commands available
  processCommand(true);
  //printCurrentValues();
}

void setMotorValues() {
  analogWrite(PWMMotorFLPin, PWMMotorFLValue);
  analogWrite(PWMMotorFRPin, PWMMotorFRValue);
  analogWrite(PWMMotorBLPin, PWMMotorBLValue);
  analogWrite(PWMMotorBRPin, PWMMotorBRValue);
  delay(30);
}

void printCurrentValues() {
  Serial.print("FL: ");
  Serial.print(PWMMotorFLValue);
  Serial.print(" | ");
  Serial.print("FR: ");
  Serial.println(PWMMotorFRValue);
  Serial.print("BL: ");
  Serial.print(PWMMotorBLValue);
  Serial.print(" | ");
  Serial.print("BR: ");
  Serial.println(PWMMotorBRValue);
  Serial.println("----------------");
}

void processCommand(bool revertToInitialPosition) {
  if (Serial.available()) {
    String command = Serial.readStringUntil('\n');
    command.trim();
    command.toUpperCase();
    Serial.println(command);
    
    if(command == "UP") {
      increaseMotorValues("INC", "INC", "INC", "INC");
    }
    else if(command == "DOWN"){
      increaseMotorValues("DEC", "DEC", "DEC", "DEC");
    }
    else if(command == "FORWARD") {
      increaseMotorValues("NO", "NO", "INC", "INC");
    }
    else if(command == "BACKWARD") {
      increaseMotorValues("INC", "INC", "NO", "NO");
    }
    else if(command == "LEFT") {
      increaseMotorValues("NO", "INC", "NO", "INC");
    }
    else if(command == "RIGHT") {
      increaseMotorValues("INC", "NO", "INC", "NO");
    }
    else if(command == "TURNLEFT") {
      increaseMotorValues("INC", "NO", "NO", "INC");
    }
    else if(command == "TURNRIGHT") {
      increaseMotorValues("NO", "INC", "INC", "NO");
    }
    else {
      increaseMotorValues("NO", "NO", "NO", "NO");
    }
    
    // Recursively process the next command in case of a valid case
    if(command.length() > 0) {
      printCurrentValues();
      processCommand(false);
    }
  }
  else if(revertToInitialPosition) {
    // Keep Reverting
    revertMotorValues();
  }
}

void revertMotorValues() {
  // Slowly revert to initial values
  PWMMotorFLValue = calculateRevertValues(intialPWMMotorFLValue, PWMMotorFLValue, PWMMotorFLMax);
  PWMMotorFRValue = calculateRevertValues(intialPWMMotorFRValue, PWMMotorFRValue, PWMMotorFRMax);
  PWMMotorBLValue = calculateRevertValues(intialPWMMotorBLValue, PWMMotorBLValue, PWMMotorBLMax);
  PWMMotorBRValue = calculateRevertValues(intialPWMMotorBRValue, PWMMotorBRValue, PWMMotorBRMax);
  
  setMotorValues();
  delay(200);
}

int calculateRevertValues(int initialValue, int currentValue, int maxValue) {
  int difference = initialValue - currentValue;
  int sensitivity = (float)((float)SensitivityPercent/100) * maxValue;
  int newvalue = 0;
  
  // Debug
  /*Serial.print("difference: ");
  Serial.println(difference);
  Serial.print("sensitivity: ");
  Serial.println(sensitivity);
  Serial.print("sensitivity1.5: ");
  Serial.println(sensitivity * 1.5);*/
  
  // If difference is not so much return the original value
  if(abs(difference) < sensitivity * 1.5)  { 
    newvalue = initialValue; 
  }
  else {
    if(difference > 0) {
      // Increase the current value by sensitivity
      newvalue = currentValue + sensitivity;
    }
    else {
      // Decrease the current value by sensitivity
      newvalue = currentValue - sensitivity;
    }
  }
  
  // Do some validation before returning the calculated value
  if(newvalue > maxValue) {
    return maxValue;
  }
  else if(newvalue <= 0) {
    return 0;
  }
  else {
    return newvalue;
  }
}

void increaseMotorValues(String PWMMotorFLChange, String PWMMotorFRChange, String PWMMotorBLChange, String PWMMotorBRChange) {
  // Slowly increase based on commands
  PWMMotorFLValue = calculateIncreaseValue(PWMMotorFLChange, PWMMotorFLValue, PWMMotorFLMax);
  PWMMotorFRValue = calculateIncreaseValue(PWMMotorFRChange, PWMMotorFRValue, PWMMotorFRMax);
  PWMMotorBLValue = calculateIncreaseValue(PWMMotorBLChange, PWMMotorBLValue, PWMMotorBLMax);
  PWMMotorBRValue = calculateIncreaseValue(PWMMotorBRChange, PWMMotorBRValue, PWMMotorBRMax);
  
  setMotorValues();
  delay(200);
}

int calculateIncreaseValue(String changeCommand, int currentValue, int maxValue) {
  int sensitivity = (float)((float)SensitivityPercent/100) * maxValue;
  int newvalue = 0;
  
  // Debug
  /*Serial.print("sensitivity: ");
  Serial.println(sensitivity);
  Serial.print("changeCommand: ");
  Serial.println(changeCommand);*/
  
  if(changeCommand == "INC") {
    newvalue = currentValue + sensitivity;
  } 
  else if(changeCommand == "DEC") {
    newvalue = currentValue - sensitivity;
  }
  else {
    newvalue = currentValue;
  }
  
   // Do some validation before returning the calculated value
  if(newvalue > maxValue) {
    return maxValue;
  }
  else if(newvalue <= 0) {
    return 0;
  }
  else {
    return newvalue;
  }
}
