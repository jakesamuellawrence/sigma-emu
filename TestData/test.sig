; Program Hello, world!
; A simple starter program for Sigma16

; Calculate result := 6 * x, where x = 7

start 
lea    R1,6[R0]
load   R2,x[R0]       ; R2 := x (variable initialized to 7)
add    R3,R1,R2
sub    R4,R3,R2
mul    R5,R3,R2   ; R3 := 6 * x = 42 (hex 002a)
div    R6,R5,R4
store  R3,result[R0]  ; result := 6 * x
trap   R0,R0,R0   ; halt

; When the program halts, we should see the following:
;   R1 contains  6 (0006)
;   R2 contains  7 (0007)
;   R3 contains 42 (002a)
;   result contains 42 (002a)
;   result is in memory, and the assembly listing shows its address

; Variables are defined  after the program
x         data   7         ; initial value of x = 7
result    data   10 
f12 sub R1,R2,R3

test test test 123