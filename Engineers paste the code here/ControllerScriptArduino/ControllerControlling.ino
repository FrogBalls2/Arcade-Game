 #include<Keyboard.h>

//config buttons

int ATK_BTN = 7;
int W_BTN = 4;
int A_BTN = 3;
int S_BTN = 6;
int D_BTN = 5;

//config button states

int STATE_ATTACK = 0;
int STATE_W = 0;
int STATE_A = 0;
int STATE_S = 0;
int STATE_D = 0;

void setup() {
  //// connected to ground:
  pinMode(3, INPUT);
  pinMode(4, INPUT);
  pinMode(5, INPUT);
  pinMode(6, INPUT);
  pinMode(7, INPUT);
  Keyboard.begin();
}

void loop() {
  //if the button is pressed, act like a keyboard

  if (digitalRead(W_BTN) == HIGH && STATE_W == LOW ) {
    STATE_W = HIGH;
    Keyboard.press('W');
  }  else if (digitalRead(W_BTN) == LOW && STATE_W == HIGH) {
    STATE_W = LOW;
    Keyboard.release('W');
  }

   if (digitalRead(A_BTN) == HIGH && STATE_A == LOW ) {
    STATE_A = HIGH;
    Keyboard.press('A');
  }  else if (digitalRead(A_BTN) == LOW && STATE_A == HIGH) {
    STATE_A = LOW;
    Keyboard.release('A');
  }

   if (digitalRead(S_BTN) == HIGH && STATE_S == LOW ) {
    STATE_S = HIGH;
    Keyboard.press('S');
  }  else if (digitalRead(S_BTN) == LOW && STATE_S == HIGH) {
    STATE_S = LOW;
    Keyboard.release('S');
  }

 if (digitalRead(D_BTN) == HIGH && STATE_D == LOW ) {
    STATE_D = HIGH;
    Keyboard.press('D');
  }  else if (digitalRead(D_BTN) == LOW && STATE_D == HIGH) {
    STATE_D = LOW;
    Keyboard.release('D');
  }
  
  if (digitalRead(ATK_BTN) == HIGH && STATE_ATTACK == LOW ) {
    STATE_ATTACK = HIGH;
    Keyboard.press(' ');
  }  else if (digitalRead(ATK_BTN) == LOW && STATE_ATTACK == HIGH) {
    STATE_ATTACK = LOW;
    Keyboard.release(' ');
  }
}
