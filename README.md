# Communication-Control-of-HC-05-Bluetooth-Module-with-PIC16F887-via-UART
This project establishes communication between the HC-05 Bluetooth module and the PIC16F887 microcontroller using UART. 
It enables wireless data exchange, allowing the microcontroller to communicate with external devices like smartphones or PCs for remote control and monitoring applications.
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
### UART Communication Between CP2102 Mini and HC-05 Bluetooth Module via PIC16F887 I/P

In the project "UART Communication Between CP2102 Mini and HC-05 Bluetooth Module via PIC16F887 I/P," the two pins RC6 and RC7 of the PIC16F887 I/P microcontroller are used for hard UART communication between the PIC16F887 and the HC-05 Bluetooth module. Pins RA0 and RA2 are utilized for soft UART communication between the PIC16F887 and the CP2102 Mini.

Key features of the PIC16F887 I/P microcontroller include:
- **Watchdog Timer (WDT):** Protects the system in case of software errors.
- **Power-Saving Mode:** Reduces power consumption when idle.
- **Brown-out Reset:** Resets the system when the voltage drops below a certain threshold.

Additionally, the operating voltage of the PIC16F887 I/P is from 2.0V to 5.5V, making it suitable for low-voltage applications.
### 4. Overview of HC-05 Bluetooth Module

![HC-05 Bluetooth Module](https://nshopvn.com/wp-content/uploads/2019/03/module-thu-phat-bluetooth-hc-05-lpsr-5.jpg)

The HC-05 Bluetooth module is a compact device that enables wireless communication between electronic devices such as smartphones, tablets, or other modules. It operates using Bluetooth technology, allowing short-range data transmission (typically around 10 meters). The HC-05 is easy to use and comes with built-in communication protocols, making the process of connecting and transmitting data simple and efficient.

**Operating Modes of HC-05:**
- **Data Mode:** Module operates as a wireless serial port, transmitting and receiving data between devices.
- **Command Mode:** Allows configuring module parameters such as device name, baud rate, and operational mode (Master/Slave). ([geeksforgeeks.org](https://www.geeksforgeeks.org/all-about-hc-05-bluetooth-module-connection-with-android/?utm_source=chatgpt.com))

**Key Features:**
- **Master and Slave Modes:** HC-05 can operate as both a Master and a Slave, providing flexibility in setting up Bluetooth networks. ([howtomechatronics.com](https://howtomechatronics.com/tutorials/arduino/arduino-and-hc-05-bluetooth-module-tutorial/?utm_source=chatgpt.com))
- **Compatible with Various Devices:** Can connect with Bluetooth-enabled devices such as smartphones, tablets, and computers.
- **Easy Integration:** Communicates through UART serial interface, making it easy to connect with microcontrollers like Arduino and PIC.

**Technical Specifications:**
- **Operating Voltage:** 3.6V to 6.0V.
- **Current Consumption:** 30mA.
- **Transmission Range:** Up to 100m under ideal conditions.
- **Data Transmission Speed:** 9600 bps (default), configurable.

**Applications:**
- **Wireless Communication:** Connects microcontrollers or enables communication between a microcontroller and mobile devices.
- **Remote Control:** Used for controlling electronic devices via smartphone or computer.
- **IoT Projects:** Integrates into Internet of Things (IoT) projects for data transmission.

HC-05 is a popular choice for wireless connection projects due to its flexibility, ease of use, and wide compatibility.
### Pinout of HC-05 Bluetooth Module

| Pin Number | Pin Label | Description                                  |
|------------|-----------|----------------------------------------------|
| 1          | STATE     | Indicates the connection status of HC-05    |
| 2          | RXD       | Data receive pin (Receive)                   |
| 3          | TXD       | Data transmit pin (Transmit)                 |
| 4          | GND       | Ground (mass) pin                           |
| 5          | VCC       | Power supply pin (3.3V)                      |
| 6          | EN        | Enable pin                                  |
### Operating Principle

Connect the VCC pin to a 3.3V power source and the GND pin to ground. Then, connect the Rx pin of the HC-05 to the Tx (RC6) pin of the PIC16F887-I/P, and the Tx pin of the HC-05 to the Rx (RC7) pin of the PIC16F887-I/P. After that, pair the HC-05 Bluetooth module with the mobile phone's Bluetooth address to enable data transmission and reception with the CP2102 Mini.
### 5. Overview of CP2102 Mini

The CP2102 mini module is a USB to UART TTL converter and vice versa. It uses the CP2102 chip from Silicon Labs, a dedicated chip for this communication conversion. With the CP2102 mini module, you can easily connect a device using UART communication (such as Arduino or other microcontroller boards) to a computer via the USB port. This makes programming, debugging, and data transmission much more convenient.

![CP2102 Mini Module](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2WK74habOYCf27JvMv-EDUqykg0tBCV6l3Q&s)
### Pinout of CP2102 Mini Module

| Pin Number | Pin Label | Description                       |
|------------|-----------|-----------------------------------|
| 1          | 3V3       | 3.3V power output pin             |
| 2          | TXD       | Data transmit pin                 |
| 3          | RXD       | Data receive pin                  |
| 4          | GND       | Ground pin                        |
| 5          | +5V       | 5V power input pin                |
### Operating Principle

Connect the Tx pin of the CP2102 mini to the soft Rx (RA0) pin of the PIC16F887-I/P through the UART protection circuit using an optocoupler. Then, connect the Rx pin of the CP2102 mini to the soft Tx (RA2) pin of the PIC16F887-I/P through the UART protection circuit. Finally, connect the USB port of the CP2102 mini to the computer for data transmission and reception with the HC-05 Bluetooth module.
### 6. Principle of UART Communication Protocol

UART (Universal Asynchronous Receive/Transmit) is an integrated circuit that plays a crucial role in serial communication. Serial communication reduces signal noise, making data transmission and reception more reliable. UART consists of a parallel-to-serial converter for transmitting data from the computer and a serial-to-parallel converter for receiving data through the serial connection.
### UART Serial Communication Module

The UART serial communication module is divided into three submodules:
- **Baud Rate Generator**: Generates a high-frequency clock signal above the baud rate to control the receive and transmit processes of UART.
- **Receiver Module**: Used to receive serial signals at the RXD pin and convert them into parallel data.
- **Transmitter Module**: Converts bytes into serial bits according to the basic format and transmits these bits through the TXD pin.

In the UART protocol, data is organized into transmission frames, which include:
- **Start Bit**: Indicates the beginning of the transmission and synchronizes the clock in the receiver with the transmitter.
- **Data Bit**: The actual data being transmitted.
- **Parity Bit**: A bit used for basic error checking.
- **Stop Bit**: Marks the end of the transmission.
- **Idle State**: The default state when the UART is not transmitting data.

When a word (or symbol) is ready to be transmitted, a start bit is added before the data bits. The start bit signals to the receiver that data is about to be sent, and the clock is synchronized. After the start bit, the data bits are sent one by one, with the least significant bit (LSB) transmitted first.

Once all the data is sent, the transmitter may add a parity bit, used for basic error checking. Then, one or more stop bits are sent by the transmitter to indicate the end of the data frame. If the received data is not formatted correctly, UART may report an error. If a new byte arrives before the previous byte is read, UART may report a buffer overflow error.

---

### Overview of Voltage Regulator Circuit

A voltage regulator circuit adjusts the input voltage to a fixed output value, ensuring that the output voltage remains stable regardless of variations in the input voltage. The primary function of a voltage regulator is to provide a consistent output voltage to ensure the stable operation of devices and components in a circuit.

For the project "UART Communication between CP2102 Mini and Bluetooth HC-05 module through PIC16F887 I/P," we will use a voltage regulator circuit with an IC LM7805 to generate a stable 5V output from an input voltage of 9V-1A.




