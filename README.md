# Communication-Control-of-HC-05-Bluetooth-Module-with-PIC16F887-via-UART
This project establishes communication between the HC-05 Bluetooth module and the PIC16F887 microcontroller using UART. It enables wireless data exchange, allowing the microcontroller to communicate with external devices like smartphones or PCs for remote control and monitoring applications.
### 1. Overview of LM7805

The LM7805 is commonly known as a voltage regulator IC used to provide a stable +5V output. It is widely trusted for use in electronic circuits for commercial purposes, offering a reliable solution for powering devices that require a consistent 5V supply.

![LM7805 Voltage Regulator](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSiiNR3YoEhm055fUhNHdN4cLdQgYt0TnxPeg&s)
### Pinout of LM7805 Voltage Regulator

| Pin Number | Pin Name      | Function                                          |
|------------|---------------|---------------------------------------------------|
| 1          | Input Voltage (Vin) | Receives input voltage from 7V to 20V          |
| 2          | Ground (GND)      | Connected to ground (mass)                      |
| 3          | Output Voltage (Vout) | Provides output voltage from 4.85V to 5.15V  |
### Operating Principle

The voltage regulator operates based on a bandgap reference, providing a stable and accurate output voltage even when the temperature or input voltage varies. The bandgap takes a signal from the reduced output voltage through a voltage divider (shown in blue) to compare and generate an error signal if the voltage is too high or too low. This error signal is then amplified by the error amplifier (shown in orange), which controls the output transistor via the Q15 control circuit to maintain a stable output voltage, completing the feedback loop.
The voltage divider can be adjusted to produce different output voltages, such as 5V, 12V, or 24V, by changing the resistance values.
### Protection Mechanisms

The circuit is equipped with protection mechanisms such as overcurrent, overtemperature, and overvoltage input protection through protective diodes. Additionally, the startup circuit (shown in green) ensures that the bandgap receives sufficient startup current to operate, preventing it from being stuck in the off state. All these components work together to ensure that the voltage regulator operates stably and consistently provides the desired output voltage.
### 2. Overview of Protection Circuit in UART Communication Using Opto-isolator 4N35

The Opto-isolator 4N35, also known as the 4N35 optical isolator, is commonly used to control signal transmission between two circuits based on voltage differences through light. It provides electrical isolation by transferring signals via optical means, ensuring that the circuits are protected from voltage spikes or other electrical interferences, which is essential in UART communication systems.

![Opto-isolator 4N35 Pinout Diagram](https://dientutuonglai.com/uploads/media/opto/4n35-so-do-chan.gif)
### Pinout of Opto-isolator 4N35

| Pin Number | Pin Type    | Description |
|------------|-------------|-------------|
| 1          | A           | Anode       |
| 2          | C           | Cathode     |
| 3          | NC          | No connect  |
| 4          | E           | Emitter     |
| 5          | C           | Collector   |
| 6          | B           | Base        |
### Operating Principle

When the LED emits light, the base region of the phototransistor receives the light and reduces the equivalent resistance of the transistor, causing the current through the transistor to increase. If the light intensity is strong enough, the phototransistor reaches a saturation state. The photocoupler then transmits the Tx signal from the PIC16F887 or the CP2102 mini to the Rx of the other opto-isolator.
### 3. Overview of PIC16F887-I/P

The PIC16F887 is an 8-bit microcontroller from Microchip Technology, widely used in embedded systems due to its versatility and ease of programming. It features a 14-bit instruction set, 368 bytes of RAM, and 256 bytes of EEPROM. The microcontroller supports various communication protocols, including SPI, I2C, and UART, making it suitable for a wide range of applications. :contentReference[oaicite:0]{index=0}&#8203;:contentReference[oaicite:1]{index=1}

![PIC16F887 Pinout Diagram](https://components101.com/sites/default/files/component_pin/PIC16F887-Pinout.png)




