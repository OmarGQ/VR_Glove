#include <MPU6050_tockn.h>
#include <Wire.h>

MPU6050 mpu(Wire); //determinar los coeficientes predeterminados default acelerómetro es 0.02, el giroscopio es 0.98. filter_angle = (0.02 * accel) + (0.98 * gyro)

long timer=0;

void setup() {
  Serial.begin(9600);
  Wire.begin();
  mpu.begin();
  mpu.calcGyroOffsets(true); //Calibracion automatica
  //mpu.setGyroOffsets(0, 0, 0); //calibracion por valores
}

void loop() {
  mpu.update(); //obtiene todos los datos del mpu

  if(millis()-timer>300){
    //Serial.print("temp : ");Serial.println(mpu6050.getTemp());
    Serial.print("accX : ");Serial.print(mpu.getAccX());
    Serial.print("\taccY : ");Serial.print(mpu.getAccY());
    Serial.print("\taccZ : ");Serial.println(mpu.getAccZ());
  
    Serial.print("gyroX : ");Serial.print(mpu.getGyroX());
    Serial.print("\tgyroY : ");Serial.print(mpu.getGyroY());
    Serial.print("\tgyroZ : ");Serial.println(mpu.getGyroZ());
  
    Serial.print("accAngleX : ");Serial.print(mpu.getAccAngleX());
    Serial.print("\taccAngleY : ");Serial.println(mpu.getAccAngleY());
  
    Serial.print("gyroAngleX : ");Serial.print(mpu.getGyroAngleX());
    Serial.print("\tgyroAngleY : ");Serial.print(mpu.getGyroAngleY());
    Serial.print("\tgyroAngleZ : ");Serial.println(mpu.getGyroAngleZ());
    
    Serial.print("angleX : ");Serial.print(mpu.getAngleX());
    Serial.print("\tangleY : ");Serial.print(mpu.getAngleY());
    Serial.print("\tangleZ : ");Serial.println(mpu.getAngleZ());
    Serial.println("____________________________________________________");
    timer = millis();
  }
}
