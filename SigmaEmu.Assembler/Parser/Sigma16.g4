grammar Sigma16;

program : instruction+ EOF;

instruction : label_def+ | (label_def* (rrr_instruction | rx_instruction | x_instruction | data_instruction));

rrr_instruction : mnemonic=rrr_command destinationReg=REG COMMA firstOperand=REG COMMA secondOperand=REG ;
rx_instruction : mnemonic=rx_command destinationReg=REG COMMA displacement LBRACK offsetReg=REG RBRACK ;
x_instruction : mnemonic=x_command displacement LBRACK offsetReg=REG RBRACK ;
data_instruction :  DATA number_literal ;

label_def : label ;

label : ID ;

displacement : num=number_literal | label ;

number_literal : NUM | HEXNUM ;

//command : rrr_command | rx_command | x_command ;

rrr_command : ADD | SUB | MUL | DIV | CMPLT | CMPEQ | CMPGT | INV | AND | OR | XOR | SHIFTL | SHIFTR | TRAP ;
rx_command : LEA | LOAD | STORE | JUMPF | JUMPT | JAL ;
x_command : JUMP;

//REG : R NUM; 
REG : R'0'|R'1'|R'2'|R'3'|R'4'|R'5'|R'6'|R'7'|R'8'|R'9'|R'10'|R'11'|R'12'|R'13'|R'14'|R'15';

DATA : D A T A ;

// RRR commands
ADD : A D D ;
SUB : S U B;
MUL : M U L;
DIV : D I V;
CMPLT : C M P L T;
CMPEQ : C M P E Q; 
CMPGT : C M P G T;
INV : I N V;
AND : A N D;
OR : O R;
XOR : X O R;
SHIFTL : S H I F T L;
SHIFTR : S H I F T R;
TRAP : T R A P;

// RX commands
LEA : L E A;
LOAD : L O A D;
STORE : S T O R E;
JUMPF : J U M P F;
JUMPT : J U M P T;
JAL : J A L;

// X commands
JUMP : J U M P ;

COMMA : ',';
LBRACK : '[';
RBRACK : ']';
DOLLAR: '$';

HEXNUM : DOLLAR HEXDIGIT HEXDIGIT HEXDIGIT HEXDIGIT; 
INVALID_HEXNUM: DOLLAR (HEXDIGIT | LETTER)* ; 
NUM : DIGIT+;
INVALID_NUM : DIGIT+ LETTER* ;
ID : LETTER (LETTER | [_] | DIGIT)*;

SPACE	:	(' ' | '\t')+  -> skip ;
EOL     :	'\r'? '\n' -> skip;
COMMENT :	';' ~('\r' | '\n')* (EOL | EOF) -> skip ;

ANY : . ;

fragment LETTER : 'a'..'z' | 'A'..'Z' ;
fragment DIGIT  : '0'..'9' ;
fragment HEXDIGIT : 'a'..'f' | 'A' .. 'F' | '0' .. '9';

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