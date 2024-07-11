/****************************************************
Js supports 3 ways to creating variables in the code. 
const that is used to create constant values. const was introduced in ES6
let that is used to create variables. let was introduced in ES6. 
Older versions of JS used var to create variables. var is still available for backward compatibility.
let is scope based and is very powerful compared to var.  

// const msg = "Welcome to JS Training"
// console.log(msg);

// let res = 13 +14;
// console.log(res)

// res = 13 * 14;
// console.log(res);
//replace the below var with let to see the advantage of using let over var. 
var example = "Sample Test";
console.log(example);
{
   var example = "Some more Test";
   console.log(example);   
}
console.log(example);
/************************Data Types in Js*************************** */
// let value = 123;
// console.log(typeof(value));

// value ="Apple in the Box";
// console.log(typeof(value));

// value = true;
// console.log(typeof(value));

// value = { name: "Phaniraj", address: "Bangalore"}
// console.log(typeof(value));

// value = ["Apples", "Mangoes", "Oranges"]
// console.log(typeof(value));

// value = null; //A state where the object has no value. 
// console.log(value);

// let example //variable which is declared but not set with any value to it is called as "UNDEFINED"
// console.log(example);

//variable that is not declared. Exception of undefined variable will be throw.  
let Apple;
console.log(Apple);//undefined.
//4 types: number, bool, string, object. 
//states: undefined, null. 