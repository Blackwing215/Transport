%include "io.inc"

section .text

global CMAIN
extern _printf

CMAIN:
    
    push ebp
    mov ebp, esp;
    ;write your code here
    xor eax, eax
    
    mov eax,X
    mov ebx,[a]
    mov edx,[b]
    
    call ArrayProcess
    
    push dword [ans]
    push fmt
    call _printf
    add esp,8
    
    mov eax,0    
    pop ebp
    ret
    ;eax-addr
    ;ebx-a
    ;edx-b
ArrayProcess:
    
    mov ecx,10
    mov dword [ans],0
    
    lp:
    
    cmp [eax],ebx
    jge next
    
    jmp fail
    
    next:
    cmp edx,[eax]
    jl fail
    
    add dword [ans],1
    
    fail:
    
    add eax,4
    dec ecx
    
    jnz lp
       
    ret
    
section .data
fmt db "%d",0
X dd 1,4,5,2,5,3,5,6,3,10
a dd 1
b dd 2
ans dd 0