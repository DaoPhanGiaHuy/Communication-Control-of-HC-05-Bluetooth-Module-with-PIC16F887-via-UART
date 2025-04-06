#include "Firm.h"

void InitSoftUART(void)		// Cai dat cac chan Rx Tx
{
	UART_TX = 1;			// TX cao khi khong lam gi
	
	UART_RX_DIR = 1;		// Input
	UART_TX_DIR = 0;		// Output
    
    //INTCON = 0x90;
    //OPTION_REG &=0xbf;
}



unsigned char UART_Receive(void)
{
	unsigned char DataValue = 0;

	while(UART_RX==1);

	__delay_us(OneBitDelay);
	//__delay_us(OneBitDelay/2);   

	for ( unsigned char i = 0; i < DataBitCount; i++ )
	{
		if ( UART_RX == 1 )   
		{
			DataValue += (1<<i);
		}

		__delay_us(OneBitDelay);
	}

	// Check for stop bit
	if ( UART_RX == 1 )       
	{
		__delay_us(OneBitDelay/2);
		return DataValue;
	}
	else                        
	{
		__delay_us(OneBitDelay/2);
		return 0x000;
	}
}

void UART_Transmit(const char DataValue)
{

	UART_TX = 0;
	__delay_us(OneBitDelay);

	for ( unsigned char i = 0; i < DataBitCount; i++ )
	{
		if( ((DataValue>>i)&0x1) == 0x1 )   
		{
			UART_TX = 1;
		}
		else      
		{
			UART_TX = 0;
		}

	    __delay_us(OneBitDelay);
	}

	UART_TX = 1;
	__delay_us(OneBitDelay);
}

