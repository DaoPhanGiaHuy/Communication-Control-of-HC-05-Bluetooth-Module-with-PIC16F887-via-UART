
// CONFIG
/***/
#pragma config FOSC = HS        // Oscillator Selection bits (HS oscillator: High-speed crystal/resonator on RA6/OSC2/CLKOUT and RA7/OSC1/CLKIN)
#pragma config WDTE = OFF       // Watchdog Timer Enable bit (WDT disabled and can be enabled by SWDTEN bit of the WDTCON register)
#pragma config PWRTE = OFF      // Power-up Timer Enable bit (PWRT disabled)
#pragma config MCLRE = OFF      // RE3/MCLR pin function select bit (RE3/MCLR pin function is digital input, MCLR internally tied to VDD)
#pragma config CP = OFF         // Code Protection bit (Program memory code protection is disabled)
#pragma config CPD = OFF        // Data Code Protection bit (Data memory code protection is disabled)
#pragma config BOREN = OFF      // Brown Out Reset Selection bits (BOR disabled)
#pragma config IESO = OFF       // Internal External Switchover bit (Internal/External Switchover mode is disabled)
#pragma config FCMEN = OFF      // Fail-Safe Clock Monitor Enabled bit (Fail-Safe Clock Monitor is disabled)
#pragma config LVP = OFF        // Low Voltage Programming Enable bit (RB3 pin has digital I/O, HV on MCLR must be used for programming)

// CONFIG2
#pragma config BOR4V = BOR40V   // Brown-out Reset Selection bit (Brown-out Reset set to 4.0V)
#pragma config WRT = OFF        // Flash Program Memory Self Write Enable bits (Write protection off)
#include "Firm.h"
// Config word
char buffer[96];
unsigned char i;
unsigned char buffer_index = 0;
void UART_Init(long baud_rate) {
    unsigned int x;
    x = (_XTAL_FREQ - baud_rate * 64) / (baud_rate * 64);  
    if (x > 255) {
        x = (_XTAL_FREQ - baud_rate * 16) / (baud_rate * 16);
        BRGH = 1;  
    } else {
        BRGH = 0; 
    }
    SPBRG = x;  
    SYNC = 0;   
    SPEN = 1;   
    TXEN = 1;  
    CREN = 1;   
    TX9 = 0;    
    RX9 = 0;   
    
    RCIE = 1;   
    PEIE = 1;   
    GIE = 1;   
}
void UART_Write(char data) {
    while (!TXIF)  
        ;
    TXREG = data;  
}

unsigned char UART_Read() {
    while (!RCIF)  
        ;
    return RCREG;  
}
 
unsigned char UART_Data_Ready() {
    return RCIF;
}

void __interrupt() ISR() {
    if (RCIF) { 
        char receivedData = RCREG;  
        UART_Transmit(receivedData);  
    }
}
void HandleSpecialSequence() {
    for (i = 0; i < 96; i++) {
        UART_Transmit('&');  
    }
    buffer_index = 0;
}

void CheckAndRespond() {
    if (buffer_index == 96) {
        for (i = 0; i < 96; i++) {
            if (buffer[i] != '&') {
                buffer_index = 0; 
                return; 
            }
        }
        HandleSpecialSequence(); 
    }
}

// Main function
void main()
{	
    unsigned char ch =0;
    unsigned char data = 0;
    UART_Init(4800);
	InitSoftUART();			   
    ANSEL = ANSELH = 0x00;
	while(1)
	{  
            ch = UART_Receive();
            if (ch != 0x00) {  
            UART_Write(ch);  
            
            buffer[buffer_index++] = ch;  
            CheckAndRespond();  
            }
    }
        
}
