# Exam Calculator

## How to get started

### Console App Client
1. Clone the [console app client] (https://github.com/karenferaer/exam-calculator-client) for the calculator.
2. Check the appSettings.json file if the **BaseAddress** is pointed to the deployed calculator service: http://examc-recip-18b26exw7tprb-2042293946.us-east-1.elb.amazonaws.com/api/Calculator
3. Run the console app
4. Input the first number, second number and the operation ( + or - or * or / )

### Access Deployed API Endpoint
**Method**: POST
```
**Endpoint**: http://examc-recip-18b26exw7tprb-2042293946.us-east-1.elb.amazonaws.com/api/Calculator
{
    "firstNumber": 111,
    "secondNumber": 10,
    "operation": 0
}
```
**Operation Types**:
0 - Add
1 - Subtract
2 - Multiply
3 - Divide

### Refinement
1. Addition of logging


