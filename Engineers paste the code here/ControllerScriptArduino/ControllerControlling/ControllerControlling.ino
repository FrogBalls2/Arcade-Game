#include<Keyboard.h>

int ATK_BTN = 7;
int W_BTN = 6;
int A_BTN = 5;
int S_BTN = 4;
int D_BTN = 3;

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
  //if the button is pressed
  if (digitalRead(D_BTN) == HIGH) {
    Keyboard.write('D');
  }
  if (digitalRead(S_BTN) == HIGH) {
    Keyboard.write('S');
  }
  if (digitalRead(A_BTN) == HIGH) {
    Keyboard.write('A');
  }
  if (digitalRead(W_BTN) == HIGH) {
    Keyboard.write('W');
  }
  if (digitalRead(ATK_BTN) == HIGH) {
    Keyboard.write('E');
  }
}
