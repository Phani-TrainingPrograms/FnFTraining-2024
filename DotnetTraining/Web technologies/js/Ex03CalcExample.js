let v1 = prompt("Enter the First value");
//isNaN is availabe as global function as well as member of Number class.
if(isNaN(v1)){
    alert("This is not a valid number, so taking 0")
    v1 = 0;
}else
v1 = parseFloat(v1);
let v2 = parseFloat(prompt("Enter the second value"));
if(isNaN(v2)){
    alert("This is not a valid number, so taking 0")
    v2 = 0;
}
let op = prompt("Enter the choice as +, -, * or /");
switch (op) {
    case "+": alert("The result of add is " + (v1 + v2));
        break;
    case "-": alert("The result of subtract is " + (v1 - v2));
        break;
    case "*": alert("The result of multiply is " + (v1 * v2));
        break;
    case "/": alert("The result of Divide is " + (v1 / v2));
        break;
    default:
        alert("Unrecogized choice");
        break;
}