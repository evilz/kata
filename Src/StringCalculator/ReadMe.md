# StringCalculator

Kata Steps:

1. Create a String calculator with a method int Add(string numbers) 

    - The method can take 0, 1, or 2 numbers and will return their sum. 
    - An empty string will return 0. 
    - Example inputs: "", "1", or "1,2" 
    - Start with the simplest test case of an empty string. Then 1 number. Then 2 numbers. 
    - Remember to solve things as simply as possible, forcing yourself to write tests for things you didn't think about. 
    - Remember to refactor after each passing test. 

2. Allow the Add method to handle an unknown number of arguments/numbers.

3. Allow the Add method to handle new lines between numbers (instead of commas). 

    - Example: "1\n2,3" should return 6. 
    - Example: "1,\n" is invalid, but you don't need a test for this case. 
    - Only test correct inputs - there is no need to deal with invalid inputs for this kata. 

4. Allow the Add method to handle a different delimiter: 

    - To change the delimiter, the beginning of the string will contain a separate line that looks like this: "//[delimiter]\n[numbers]" 
    - Example: "//;\n1;2" should return 3 (the delimiter is ;) 
    - This first line is optional; all existing scenarios (using , or \n) should work as before. 

5. Calling Add with a negative number will throw an exception "Negatives not allowed: " listing all negative numbers that were in the list of numbers. 

    - Example "-1,2" throws "Negatives not allowed: -1"
    - Example "2,-4,3,-5" throws "Negatives not allowed: -4,-5" 
6. Numbers bigger than 1000 should be ignored. 
    - Example: "1001,2" returns 2