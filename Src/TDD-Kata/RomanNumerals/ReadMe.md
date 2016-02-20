# Roman Numerals

The Romans were a clever bunch. They conquered most of Europe and ruled it for hundreds of years. 
They invented concrete and straight roads and even bikinis. 
One thing they never discovered though was the number zero. 
This made writing and dating extensive histories of their exploits slightly more 
challenging, but the system of numbers they came up with is still in use today.
For example the BBC uses Roman numerals to date their programs.

For this Kata, write a function to convert from normal (Arabic) numbers to Roman Numerals:

```
1 -> I
10 -> X
7 -> VII
etc.
```

There is no need to be able to convert numbers larger than about 3000. 
(The Romans themselves didn’t tend to go any higher).

#### Background information

##### Symbol Value

```
I 1
V 5
X 10
L 50
C 100
D 500
M 1000
```

Generally, symbols are placed in order of value, starting with the largest values. 
When smaller values precede larger values, the smaller values are subtracted from 
the larger values, and the result is added to the total. 
However, you can’t write numerals like __"IM"__ for __999__, 
there are some additional rules:

- A number written in Arabic numerals can be broken into digits. For example, 1903 is 
composed of 1 (one thousand), 9 (nine hundreds), 0 (zero tens), and 3 (three units). To write 
the Roman numeral, each of the nonzero digits should be treated separately. 
In the above example, __1,000 = M, 900 = CM, and 3 = III__. Therefore, 1903 = MCMIII.

- The symbols __"I", "X", "C", and "M"__ can be repeated three times in succession, 
but no more. 
(They may appear more than three times if they appear non-sequentially, such as XXXIX.) 
"D", "L", and "V" can never be repeated.

- "I" can be subtracted from "V" and "X" only. "X" can be subtracted from "L" and "C" only. 
"C" can be subtracted from "D" and "M" only. "V", "L", and "D" can never be subtracted.

- Only one small-value symbol may be subtracted from any large-value symbol.

#### Part II

Write a function to convert in the other direction, i.e. numeral to digit