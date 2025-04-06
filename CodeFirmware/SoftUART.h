
#ifndef __SOFT_UART_H
#define __SOFT_UART_H

#ifndef _XTAL_FREQ
 // This definition is required to calibrate __delay_us() and __delay_ms()
 #define _XTAL_FREQ 20000000
#endif
#define Baudrate              4800                      // bps
#define OneBitDelay           (1000000/Baudrate)		// microseconds
#define DataBitCount          8                         // no parity, no flow control
#define UART_RX               RA0						// UART RX pin
#define UART_TX               RA2						// UART TX pin
#define UART_RX_DIR			  TRISA0					// UART RX pin direction register
#define UART_TX_DIR			  TRISA2					// UART TX pin direction register

//Function Declarations
void InitSoftUART(void);
unsigned char UART_Receive(void);
void UART_Transmit(const char);


#endif