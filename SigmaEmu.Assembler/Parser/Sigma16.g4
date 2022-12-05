grammar Sigma16;

program : instruction*;

instruction : rrr_instruction | rx_instruction | data_instruction;

rrr_instruction : (LABEL EOL?)? RRR_COMMAND destinationReg=reg COMMA firstOperand=reg COMMA secondOperand=reg ;
rx_instruction : (LABEL EOL?)? RX_COMMAND reg COMMA label=x LBRACK offsetReg=reg RBRACK ;
data_instruction : LABEL 'data' NUM ;

reg : REG_PREFIX NUM;

x : NUM | LABEL ;

RRR_COMMAND : ADD | SUB | MUL | DIV | TRAP ;
RX_COMMAND : LEA | LOAD | STORE | TRAP;

// RRR commands
ADD : 'add';
SUB : 'sub';
MUL : 'mul';
DIV : 'div';
TRAP : 'trap';

// RX commands
LEA : 'lea';
LOAD : 'load';
STORE : 'store';

NUM : DIGIT+;
LABEL : ('a'.. 'z' | 'A'.. 'Q' | 'S'..'Z') (LETTER | DIGIT)*;
//LEGAL_LABEL_START : ~('R'|','|'['|']'|'\r'|'\n') ;

COMMA : ',';
LBRACK : '[';
RBRACK : ']';
REG_PREFIX : 'R';

SPACE	:	(' ' | '\t')+   -> skip ;
EOL     :	'\r'? '\n'          -> skip ;
COMMENT :	';' ~('\r' | '\n')* '\r'? '\n' -> skip ;

fragment LETTER : 'a'..'z' | 'A'..'Z' ;
fragment DIGIT  : '0'..'9' ;