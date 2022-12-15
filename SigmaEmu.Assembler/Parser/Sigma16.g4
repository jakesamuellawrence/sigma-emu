grammar Sigma16;

program : line+ EOF;

line : instruction? (COMMENT | EOL);

instruction : label_def? (rrr_instruction | rx_instruction | x_instruction | data_instruction);

rrr_instruction : mnemonic=rrr_command destinationReg=REG COMMA firstOperand=REG COMMA secondOperand=REG ;
rx_instruction : mnemonic=rx_command destinationReg=REG COMMA displacement LBRACK offsetReg=REG RBRACK ;
x_instruction : mnemonic=x_command displacement LBRACK offsetReg=REG RBRACK ;
data_instruction :  DATA NUM ;

label_def : label EOL? ;

label : ID ;

displacement : num=NUM | label ;

//reg : REG_PREFIX NUM;
//REG : 'R' NUM; 

command : rrr_command | rx_command | x_command ;

rrr_command : ADD | SUB | MUL | DIV | CMPLT | CMPEQ | CMPGT | INV | AND | OR | XOR | SHIFTL | SHIFTR | TRAP ;
rx_command : LEA | LOAD | STORE | JUMPF | JUMPT | JAL ;
x_command : JUMP;

REG : 'R0'|'R1'|'R2'|'R3'|'R4'|'R5'|'R6'|'R7'|'R8'|'R9'|'R10'|'R11'|'R12'|'R13'|'R14'|'R15';

DATA : 'data' ;

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

COMMA : ',';
LBRACK : '[';
RBRACK : ']';

NUM : DIGIT+;
ID : LETTER (LETTER | [_] | DIGIT)*;

SPACE	:	(' ' | '\t')+  -> skip ;
EOL     :	'\r'? '\n' ;
COMMENT :	';' ~('\r' | '\n')* (EOL | EOF) ;

ANY : . ;

fragment LETTER : 'a'..'z' | 'A'..'Z' ;
fragment DIGIT  : '0'..'9' ;

fragment A : [aA];
fragment B : [bB];
fragment C : [cC];
fragment D : [dD];
fragment E : [eE];
fragment F : [fF];
fragment G : [gG];
fragment H : [hH];
fragment I : [iI];
fragment J : [jJ];
fragment K : [kK];
fragment L : [lL];
fragment M : [mM];
fragment N : [nN];
fragment O : [oO];
fragment P : [pP];
fragment Q : [qQ];
fragment R : [rR];
fragment S : [sS];
fragment T : [tT];
fragment U : [uU];
fragment V : [vV];
fragment W : [wW];
fragment X : [xX];
fragment Y : [yY];
fragment Z : [zZ];