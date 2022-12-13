grammar Sigma16;



program : instruction*;

instruction : rrr_instruction | rx_instruction | x_instruction | data_instruction ;

rrr_instruction : label_def? RRR_COMMAND destinationReg=REG COMMA firstOperand=REG COMMA secondOperand=REG ;
rx_instruction : label_def? RX_COMMAND destinationReg=REG COMMA displacement LBRACK offsetReg=REG RBRACK ;
x_instruction : label_def? X_COMMAND displacement LBRACK offsetReg=REG RBRACK ;
data_instruction : label_def? 'data' NUM ;

label_def : LABEL;

//reg : REG_PREFIX NUM;
REG : 'R0'|'R1'|'R2'|'R3'|'R4'|'R5'|'R6'|'R7'|'R8'|'R9'|'R10'|'R11'|'R12'|'R13'|'R14'|'R15';

displacement : num=NUM | label=LABEL ;

RRR_COMMAND : ADD | SUB | MUL | DIV | CMPLT | CMPEQ | CMPGT | INV | AND | OR | XOR | SHIFTL | SHIFTR | TRAP ;
RX_COMMAND : LEA | LOAD | STORE | JUMPF | JUMPT | JAL ;
X_COMMAND : JUMP;

// RRR commands
ADD : 'add';
SUB : 'sub';
MUL : 'mul';
DIV : 'div';
CMPLT : 'cmplt';
CMPEQ : 'cmpeq'; 
CMPGT : 'cmpgt';
INV : 'inv';
AND : 'and';
OR : 'or';
XOR : 'xor';
SHIFTL : 'shiftl';
SHIFTR : 'shiftr';
TRAP : 'trap';

// RX commands
LEA : 'lea';
LOAD : 'load';
STORE : 'store';
JUMPF : 'jumpf';
JUMPT : 'jumpt';
JAL : 'jal';

// X commands
JUMP : 'jump' ;

//LABEL : ('a'.. 'z' | 'A'.. 'Q' | 'S'..'Z') (LETTER | [_-] | DIGIT)*;
//LEGAL_LABEL_START : ~('R'|','|'['|']'|'\r'|'\n') ;

COMMA : ',';
LBRACK : '[';
RBRACK : ']';

NUM : DIGIT+;
LABEL : LETTER (LETTER | [_] | DIGIT)*;

SPACE	:	(' ' | '\t')+  -> skip ;
EOL     :	'\r'? '\n'          -> skip ;
COMMENT :	';' ~('\r' | '\n')* '\r'? '\n' -> skip;


fragment LETTER : 'a'..'z' | 'A'..'Z' ;
fragment DIGIT  : '0'..'9' ;