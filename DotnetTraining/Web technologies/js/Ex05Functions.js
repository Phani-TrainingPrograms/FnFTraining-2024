//named functions in Js...
function addFunc(v1, v2){
    return (v1 + v2);
}

//functions can be represented as variables and used. Creating Anonymous methods in Javascript
const subFunc = function(v1, v2){
    return v1 - v2;
}

//Anonymous methods are simplified using lambda methods
const mulFunc = (v1, v2) => v1 * v2;

const divFunc = (v1, v2) => v1 / v2;

//Uncomment the below code if U want to test the functions directly in the UserInterface.html
// const v1 = parseFloat(prompt("Enter the first value"))
// const v2 = parseFloat(prompt("Enter the second value"))
// let result = addFunc(v1, v2);
// console.log(result);

// result = subFunc(13,12);
// console.log(result);

// result = mulFunc(12,2);
// console.log(result);