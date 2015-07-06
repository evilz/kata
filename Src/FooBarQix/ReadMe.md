# FooBarQix 

Write a program that displays numbers from 1 to 100. A number per line. Follow the following rules:

- If the number is divisible by 3 or contains 3, write "foo" instead of 3.
- If the number is divisible by 5 or contains 5, write "bar" instead of 5.
- If the number is divisible by 7 or contains 7, write "qix" instead of 7.

An example of rendering
```
1
2
FooFoo
4
BarBar
Foo
QixQix
8
Foo
Bar
...
```

#### Updated: clarification of the rules

- We watch the dividers before the content (eg 51 -> FooBar)
- We watch the content in the order that it appears (eg 53 -> BarFoo)
- We watch multiple in the order Foo, Bar and Qix (eg 21 -> FooQix)
- 13 contains, so 3 is written, "Foo"
- 15 is divisible by 3 and 5 contain either a 5 therefore written "FooBarBar"
- 33 contains twice 3 is divisible by 3 and thus is written "FooFooFoo"